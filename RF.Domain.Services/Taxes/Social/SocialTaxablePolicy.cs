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

            decimal maxTaxableAmount = rate.MaxThreshold - rate.MinThreshold;
            decimal taxableAmount = 0m;

            if(income.Amount > rate.MaxThreshold)
            {
                taxableAmount = maxTaxableAmount;
            }
            else
            {
                taxableAmount = income.Amount - rate.MinThreshold;
            }

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
