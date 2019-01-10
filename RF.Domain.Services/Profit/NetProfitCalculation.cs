using RF.Domain.Models.Taxes;
using System.Collections.Generic;
using System.Linq;

namespace RF.Domain.Services.Profit
{
    public class NetProfitCalculation : IProfitCalculation
    {
        private readonly IEnumerable<ITaxablePolicy<TaxableIncome>> taxPolicies;

        public NetProfitCalculation(IEnumerable<ITaxablePolicy<TaxableIncome>> policies)
        {
            taxPolicies = policies;
        }

        public decimal CalculateProfit(decimal amount)
        {
            if (amount <= 0) return 0;

            var taxIncome = new TaxableIncome(amount);

            var applicableTaxPolicies = taxPolicies.Where(tp => tp.IsSatisfied(taxIncome));

            decimal taxes = applicableTaxPolicies.Sum(x => x.CalculateTax(taxIncome));

            return amount - taxes;
        }

        public bool IsSatisfied(ProfitOperationType type)
        {
            return type == ProfitOperationType.Net;
        }
    }
}
