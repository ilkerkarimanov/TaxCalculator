namespace RF.Domain.Models.Taxes
{
    public class TaxableIncome
    {
        public decimal Amount { get; private set; }

        public TaxableIncome(decimal amount)
        {
            Amount = amount;
        }
    }
}
