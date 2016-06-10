

using VigiothCapital.QuantTrader.Brokerages;
using VigiothCapital.QuantTrader.Data.Market;
using VigiothCapital.QuantTrader.Securities;

namespace VigiothCapital.QuantTrader.Algorithm.CSharp
{
    /// <summary>
    /// This algorithm shows how to set a custom security initializer.
    /// A security initializer is run immediately after a new security object
    /// has been created and can be used to security models and other settings,
    /// such as data normalization mode
    /// </summary>
    public class CustomSecurityInitializerAlgorithm : QCAlgorithm
    {
        public override void Initialize()
        {
            // set our initializer to our custom type
            SetBrokerageModel(BrokerageName.TradierBrokerage);
            SetSecurityInitializer(new CustomSecurityInitializer(BrokerageModel, DataNormalizationMode.Raw));

            SetStartDate(2012, 01, 01);
            SetEndDate(2013, 01, 01);

            AddSecurity(SecurityType.Equity, "SPY", Resolution.Hour);
        }

        public void OnData(TradeBars data)
        {
            if (!Portfolio.Invested)
            {
                SetHoldings("SPY", 1);
            }
        }

        /// <summary>
        /// Our custom initializer that will set the data normalization mode.
        /// We sub-class the <see cref="BrokerageModelSecurityInitializer"/>
        /// so we can also take advantage of the default model/leverage setting
        /// behaviors
        /// </summary>
        class CustomSecurityInitializer : BrokerageModelSecurityInitializer
        {
            private readonly DataNormalizationMode _dataNormalizationMode;

            /// <summary>
            /// Initializes a new instance of the <see cref="CustomSecurityInitializer"/> class
            /// with the specified normalization mode
            /// </summary>
            /// <param name="brokerageModel">The brokerage model used to get fill/fee/slippage/settlement models</param>
            /// <param name="dataNormalizationMode">The desired data normalization mode</param>
            public CustomSecurityInitializer(IBrokerageModel brokerageModel, DataNormalizationMode dataNormalizationMode)
                : base(brokerageModel)
            {
                _dataNormalizationMode = dataNormalizationMode;
            }

            /// <summary>
            /// Initializes the specified security by setting up the models
            /// </summary>
            /// <param name="security">The security to be initialized</param>
            public override void Initialize(Security security)
            {
                // first call the default implementation
                base.Initialize(security);

                // now apply our data normalization mode
                security.SetDataNormalizationMode(_dataNormalizationMode);
            }
        }
    }
}
