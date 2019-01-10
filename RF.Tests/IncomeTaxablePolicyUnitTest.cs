using RF.Domain.Models.Taxes;
using RF.Domain.Services.Taxes.Income;
using Xunit;

namespace RF.Tests
{
    public class IncomeTaxablePolicyUnitTest
    {
        private readonly IncomeTaxablePolicy _incomeTaxablePolicy;

        public IncomeTaxablePolicyUnitTest()
        {
            IncomeTaxableCriteria incomeTaxableCriteria = new IncomeTaxableCriteria();
            _incomeTaxablePolicy = new IncomeTaxablePolicy(incomeTaxableCriteria);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(980)]
        [InlineData(0)]
        public void ReturnZeroTaxForGivenNetIncomeLessThanOrEqual1000(decimal value)
        {
            var result = _incomeTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result == 0, $"Income tax for {value} should be zero.");
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(1100)]
        [InlineData(3400)]
        public void ReturnPositiveTaxForGivenNetIncomeGreaterThan1000(decimal value)
        {
            var result = _incomeTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result > 0, $"Income tax for {value} should be positive.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3400)]
        public void ReturnZeroTaxForGivenNetIncomeLestThanOrEqualToZero(decimal value)
        {
            var result = _incomeTaxablePolicy.CalculateTax(new TaxableIncome(value));

            Assert.True(result == 0, $"Income tax for {value} should be zero.");
        }

        [Fact]
        public void ReturnTaxAmountEqualsZero()
        {
            var amount = 980;
            var tax = 0;
            var result = _incomeTaxablePolicy.CalculateTax(new TaxableIncome(amount));
            Assert.True(result == tax);
        }

        [Fact]
        public void ReturnTaxAmountEquals240()
        {
            var amount = 3400;
            var tax = 240; 
            var result = _incomeTaxablePolicy.CalculateTax(new TaxableIncome(amount));
            Assert.True(result == tax);
        }
    }
}
