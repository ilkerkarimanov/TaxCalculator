using RF.Domain.Models.Taxes;

namespace RF.Domain.Services.Taxes.Social
{
    public class SocialTaxableCriteria : ITaxableCriteria<SocialTaxablePolicy>
    {
        public TaxableRate GetRate()
        {
            return new TaxableRate(15, 1000, 3000);
        }
    }
}
