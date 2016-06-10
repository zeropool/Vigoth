

using System;
using System.Collections.Generic;
using VigiothCapital.QuantTrader.Configuration;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Packets;
using VigiothCapital.QuantTrader.Util;

namespace VigiothCapital.QuantTrader.Brokerages.Oanda
{
    /// <summary>
    /// Provides an implementations of <see cref="IBrokerageFactory"/> that produces a <see cref="OandaBrokerage"/>
    /// </summary>
    public class OandaBrokerageFactory: BrokerageFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OandaBrokerageFactory"/> class.
        /// </summary>
        public OandaBrokerageFactory() 
            : base(typeof(OandaBrokerage))
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
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
                    { "oanda-environment", Config.Get("oanda-environment") },
                    { "oanda-access-token", Config.Get("oanda-access-token") },
                    { "oanda-account-id", Config.Get("oanda-account-id") }
                };
            }
        }

        /// <summary>
        /// Gets a new instance of the <see cref="OandaBrokerageModel"/>
        /// </summary>
        public override IBrokerageModel BrokerageModel
        {
            get { return new OandaBrokerageModel(); }
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
            var environment = Read<Environment>(job.BrokerageData, "oanda-environment", errors);
            var accessToken = Read<string>(job.BrokerageData, "oanda-access-token", errors);
            var accountId = Read<int>(job.BrokerageData, "oanda-account-id", errors);

            if (errors.Count != 0)
            {
                // if we had errors then we can't create the instance
                throw new Exception(string.Join(System.Environment.NewLine, errors));
            }

            var brokerage = new OandaBrokerage(algorithm.Transactions, algorithm.Portfolio, environment, accessToken, accountId);
            Composer.Instance.AddPart<IDataQueueHandler>(brokerage);

            return brokerage;
        }

    }
}
