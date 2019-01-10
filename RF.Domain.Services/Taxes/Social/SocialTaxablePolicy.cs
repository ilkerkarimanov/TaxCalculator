using RF.Domain.Models.Taxes;

namespace RF.Domain.Services.Taxes.Social
{
    public class SocialTaxablePolicy : ITaxablePolicy<TaxableIncome>
    {
        private readonly ITaxableCriteria<SocialTaxablePolicy> _taxableCriteria;

        public SocialTaxablePolicy(ITaxableCriteria<SocialTaxablePolicy> taxableCriteria)
        {
            _taxableCriteria = taxableCriteria;
        }

        public decimal CalculateTax(TaxableIncome income)
        {
            if (!IsSatisfied(income)) return 0;

            TaxableRate rate = _taxableCriteria.GetRate();

            decimal taxableAmount = rate.MaxThreshold - rate.MinThreshold;

            return (rate.Rate/100) * taxableAmount;
        }

        public bool IsSatisfied(TaxableIncome income)
        {
            if (income.Amount <= 0) return false;

            TaxableRate rate = _taxableCriteria.GetRate();

            return income.Amount > rate.MinThreshold;

        }
    }
}
