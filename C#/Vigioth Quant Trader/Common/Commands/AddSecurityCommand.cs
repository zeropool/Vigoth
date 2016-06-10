using System;
using VigiothCapital.QuantTrader.Interfaces;
using VigiothCapital.QuantTrader.Logging;
using VigiothCapital.QuantTrader.Packets;
namespace VigiothCapital.QuantTrader.Commands
{
    public class AddSecurityCommand : ICommand
    {
        public SecurityType SecurityType { get; set; }
        public string Symbol { get; set; }
        public Resolution Resolution { get; set; }
        public string Market { get; set; }
        public bool FillDataForward { get; set; }
        public decimal Leverage { get; set; }
        public bool ExtendedMarketHours { get; set; }
        public AddSecurityCommand()
        {
            Resolution = Resolution.Minute;
            Market = null;
            FillDataForward = true;
            Leverage = -1;
            ExtendedMarketHours = false;
        }
        public CommandResultPacket Run(IAlgorithm algorithm)
        {
            var security = algorithm.AddSecurity(SecurityType, Symbol, Resolution, Market, FillDataForward, Leverage, ExtendedMarketHours);
            return new Result(this, true, security.Symbol);
        }
        public class Result : CommandResultPacket
        {
            public Symbol Symbol { get; set; }
            public Result(AddSecurityCommand command, bool success, Symbol symbol)
                : base(command, success)
            {
                Symbol = symbol;
            }
        }
    }
}
