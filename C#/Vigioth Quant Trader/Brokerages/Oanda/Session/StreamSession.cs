

using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VigiothCapital.QuantTrader.Brokerages.Oanda.DataType;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda.Session
{
#pragma warning disable 1591
    /// <summary>
    /// StreamSession abstract class used to model the Oanda Events Sessions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StreamSession<T> where T : IHeartbeat
    {
        public delegate void DataHandler(T data);

        protected readonly int _accountId;
        private WebResponse _response;
        private bool _shutdown;
        private Task _runningTask;

        protected StreamSession(int accountId)
        {
            _accountId = accountId;
        }

        public event DataHandler DataReceived;

        public void OnDataReceived(T data)
        {
            var handler = DataReceived;
            if (handler != null) handler(data);
        }

        protected abstract WebResponse GetSession();

        public void StartSession()
        {
            _shutdown = false;
            _response = GetSession();

            _runningTask = Task.Run(() =>
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var reader = new StreamReader(_response.GetResponseStream());
                while (!_shutdown)
                {
                    var memStream = new MemoryStream();

                    var line = reader.ReadLine();
                    memStream.Write(Encoding.UTF8.GetBytes(line), 0, Encoding.UTF8.GetByteCount(line));
                    memStream.Position = 0;

                    var data = (T) serializer.ReadObject(memStream);

                    OnDataReceived(data);
                }
            });
        }

        public void StopSession()
        {
            _shutdown = true;

            try
            {
                // wait for task to finish
                if (_runningTask != null)
                {
                    _runningTask.Wait();
                }
            }
            catch (Exception)
            {
                // we can get here if the socket has been closed (i.e. after a long disconnection)
            }

            try
            {
                // close and dispose of previous session
                var httpResponse = _response as HttpWebResponse;
                if (httpResponse != null)
                {
                    httpResponse.Close();
                    httpResponse.Dispose();
                }
            }
            catch (Exception)
            {
                // we can get here if the socket has been closed (i.e. after a long disconnection)
            }
        }
    }
#pragma warning restore 1591
}