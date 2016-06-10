
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Logging;
namespace VigiothCapital.QuantTrader.Util
{
    /// <summary>
    /// Controller type used to schedule <see cref="IParallelRunnerWorkItem"/> instances
    /// to run on dedicated runner threads
    /// </summary>
    public class ParallelRunnerController : IDisposable
    {
        private Thread _processQueueThread;
        private readonly int _threadCount;
        private readonly object _sync = new object();
        private readonly ManualResetEvent _waitHandle;
        private readonly ParallelRunnerWorker[] _workers;
        private readonly BlockingCollection<IParallelRunnerWorkItem> _holdQueue;
        private readonly BlockingCollection<IParallelRunnerWorkItem> _processQueue;
        /// <summary>
        /// Gets a wait handle that can be used to wait for this controller
        /// to finish all scheduled work
        /// </summary>
        public WaitHandle WaitHandle
        {
            get { return _waitHandle; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParallelRunnerController"/> class
        /// </summary>
        /// <param name="threadCount">The number of dedicated threads to spin up</param>
        public ParallelRunnerController(int threadCount)
        {
            _threadCount = threadCount;
            _waitHandle = new ManualResetEvent(false);
            _workers = new ParallelRunnerWorker[threadCount];
            _holdQueue = new BlockingCollection<IParallelRunnerWorkItem>();
            _processQueue = new BlockingCollection<IParallelRunnerWorkItem>();
        }
        /// <summary>
        /// Schedules the specified work item to run
        /// </summary>
        /// <param name="workItem">The work item to schedule</param>
        public void Schedule(IParallelRunnerWorkItem workItem)
        {
            if (workItem.IsReady) _processQueue.Add(workItem);
            else _holdQueue.Add(workItem);
        }
        /// <summary>
        /// Starts this instance of <see cref="ParallelRunnerController"/>.
        /// This method is indempotent
        /// </summary>
        /// <param name="token">The cancellation token</param>
        public void Start(CancellationToken token)
        {
            WaitHandle[] waitHandles;
            lock (_sync)
            {
                if (_workers[0] != null) return;
                for (int i = 0; i < _threadCount; i++)
                {
                    var worker = new ParallelRunnerWorker(this, _processQueue);
                    worker.Start(token);
                    _workers[i] = worker;
                }
                waitHandles = _workers.Select(x => x.WaitHandle).ToArray();
            }
            Task.Run(() =>
            {
                WaitHandle.WaitAll(waitHandles);
                _waitHandle.Set();
                foreach (var worker in _workers)
                {
                    worker.Dispose();
                }
            }, CancellationToken.None);
            _processQueueThread = new Thread(() => ProcessHoldQueue(token));
            _processQueueThread.Start();
        }
        /// <summary>
        /// Processes the internal hold queue checking to see if work
        /// items are ready to run
        /// </summary>
        /// <param name="token">The cancellation token</param>
        private void ProcessHoldQueue(CancellationToken token)
        {
            try
            {
                foreach (var workItem in _holdQueue.GetConsumingEnumerable(token))
                {
                    if (workItem.IsReady)
                    {
                        _processQueue.Add(workItem, token);
                    }
                    else
                    {
                        _holdQueue.Add(workItem, token);
                    }
                }
            }
            catch (OperationCanceledException err)
            {
                if (!token.IsCancellationRequested)
                {
                    Log.Error(err);
                }
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            lock (_sync)
            {
                if (_holdQueue != null) _holdQueue.Dispose();
                if (_processQueue != null) _processQueue.Dispose();
                if (_processQueueThread != null && _processQueueThread.IsAlive) _processQueueThread.Abort();
                foreach (var worker in _workers)
                {
                    worker.Dispose();
                }
                if (_waitHandle != null)
                {
                    _waitHandle.Set();
                    _waitHandle.Dispose();
                }
            }
        }
    }
}