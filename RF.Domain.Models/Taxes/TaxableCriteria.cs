namespace RF.Domain.Models.Taxes
{
    public class TaxableRate
    {
        public decimal MinThreshold { get; private set; }

        public decimal MaxThreshold { get; private set; }

        public decimal Rate { get; private set; }

        public TaxableRate(
            decimal rate,
            decimal minThreshold,
            decimal maxThreshold
            )
        {
            Rate = rate;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }
    }
}
