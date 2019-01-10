using RF.Domain.Models.Taxes;

namespace RF.Domain.Services.Taxes.Income
{
    public class IncomeTaxableCriteria : ITaxableCriteria<IncomeTaxablePolicy>
    {
        public TaxableRate GetRate()
        {
            return new TaxableRate(10, 1000, decimal.MaxValue);
        }
    }
}
