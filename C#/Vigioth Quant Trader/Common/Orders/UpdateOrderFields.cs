namespace VigiothCapital.QuantTrader.Orders
{
    public class UpdateOrderFields
    {
        public int? Quantity { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public string Tag { get; set; }
    }
}