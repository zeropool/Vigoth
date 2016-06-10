

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Brokerages.Fxcm
{
    /// <summary>
    /// Provides an implementation of <see cref="IBrokerageFactory"/> that produces a <see cref="FxcmBrokerage"/>
    /// </summary>
    public class FxcmBrokerageFactory : BrokerageFactory
    {
        private const string DefaultServer = "http://www.fxcorporate.com/Hosts.jsp";
        private const string DefaultTerminal = "Demo";

        /// <summary>
        /// Initializes a new instance of the <see cref="FxcmBrokerageFactory"/> class
        /// </summary>
        public FxcmBrokerageFactory()
            : base(typeof(FxcmBrokerage))
        {
        }

        /// <summary>
        /// Gets the brokerage data required to run the brokerage from configuration/disk
        /// </summary>
        /// <remarks>
        /// The implementation of this property will create the brokerage data dictionary required for
        /// running live jobs. See <see cref="IJobQueueHandler.NextJob"/>
        /// </remarks>
        public override Dictionary<string, string> BrokerageData
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "fxcm-server", Config.Get("fxcm-server", DefaultServer) },
                    { "fxcm-terminal", Config.Get("fxcm-terminal", DefaultTerminal) },
                    { "fxcm-user-name", Config.Get("fxcm-user-name") },
                    { "fxcm-password", Config.Get("fxcm-password") },
                    { "fxcm-account-id", Config.Get("fxcm-account-id") }
                };
            }
        }

        /// <summary>
        /// Gets a new instance of the <see cref="FxcmBrokerageModel"/>
        /// </summary>
        public override IBrokerageModel BrokerageModel
        {
            get { return new FxcmBrokerageModel(); }
        }

        /// <summary>
        /// Creates a new <see cref="IBrokerage"/> instance
        /// </summary>
        /// <param name="job">The job packet to create the brokerage for</param>
        /// <param name="algorithm">The algorithm instance</param>
        /// <returns>A new brokerage instance</returns>
        public override IBrokerage CreateBrokerage(LiveNodePacket job, IAlgorithm algorithm)
        {
            var errors = new List<string>();

            // read values from the brokerage data
            var server = Read<string>(job.BrokerageData, "fxcm-server", errors);
            var terminal = Read<string>(job.BrokerageData, "fxcm-terminal", errors);
            var userName = Read<string>(job.BrokerageData, "fxcm-user-name", errors);
            var password = Read<string>(job.BrokerageData, "fxcm-password", errors);
            var accountId = Read<string>(job.BrokerageData, "fxcm-account-id", errors);

            if (errors.Count != 0)
            {
                // if we had errors then we can't create the instance
                throw new Exception(string.Join(Environment.NewLine, errors));
            }

            var brokerage = new FxcmBrokerage(algorithm.Transactions, algorithm.Portfolio, server, terminal, userName, password, accountId);
            Composer.Instance.AddPart<IDataQueueHandler>(brokerage);

            return brokerage;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public override void Dispose()
        {
        }

    }
}
