using RF.Domain.Models.Taxes;
using RF.Domain.Services.Taxes.Social;
using Xunit;

namespace RF.Tests
{
    public class SocialTaxablePolicyUnitTest
    {
        private readonly SocialTaxablePolicy _socialTaxablePolicy;

        public SocialTaxablePolicyUnitTest()
        {
            SocialTaxableCriteria socialTaxableCriteria = new SocialTaxableCriteria();
            _socialTaxablePolicy = new SocialTaxablePolicy(socialTaxableCriteria);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(980)]
        [InlineData(0)]
        public void ReturnZeroTaxForGivenNetIncomeLessThanOrEqual1000(decimal value)
        {
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result == 0, $"Social tax for {value} should be zero.");
        }

        [Theory]
        [InlineData(1100)]
        [InlineData(1500)]
        [InlineData(3400)]
        public void ReturnPositiveAmountForGivenNetIncomeGreaterThan1000(decimal value)
        {
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result > 0, $"Social tax for {value} should be positive.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3400)]
        public void ReturnZeroTaxForGivenNetIncomeLestThanOrEqualToZero(decimal value)
        {
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result == 0, $"Social tax for {value} should be zero.");
        }

        [Theory]
        [InlineData(980, 0)]
        [InlineData(1000, 0)]
        [InlineData(1001, 0.15)]
        [InlineData(3400, 300)]
        [InlineData(4400, 300)]
        public void ReturnExpectedTaxableAmount(decimal income, decimal tax)
        {
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(income));

            Assert.True(result == tax, $"Social tax for {income} should be {tax}.");
        }

        [Fact]
        public void ReturnTaxAmountEqualsZero()
        {
            var amount = 980;
            var tax = 0;
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(amount));
            Assert.True(result == tax);
        }

        [Fact]
        public void ReturnTaxAmountEquals300()
        {
            var amount = 3400;
            var tax = 300; 
            var result = _socialTaxablePolicy.CalculateTax(new TaxableIncome(amount));
            Assert.True(result == tax);
        }
    }
}
