using RF.Domain.Models.Taxes;
using RF.Domain.Services.Profit;
using RF.Domain.Services.Taxes.Income;
using RF.Domain.Services.Taxes.Social;
using System.Collections.Generic;
using Xunit;

namespace RF.Tests
{
    public class NetProfitCalculationUnitTest
    {
        private readonly NetProfitCalculation _netProfitCalculation;

        public NetProfitCalculationUnitTest()
        {
            IncomeTaxableCriteria incomeTaxableCriteria = new IncomeTaxableCriteria();
            IncomeTaxablePolicy incomeTaxablePolicy = new IncomeTaxablePolicy(incomeTaxableCriteria);

            SocialTaxableCriteria socialTaxableCriteria = new SocialTaxableCriteria();
            SocialTaxablePolicy socialTaxablePolicy = new SocialTaxablePolicy(socialTaxableCriteria);

            IEnumerable<ITaxablePolicy<TaxableIncome>> taxablePolicies = new List<ITaxablePolicy<TaxableIncome>>()
            {
                incomeTaxablePolicy,
                socialTaxablePolicy
            };

            _netProfitCalculation = new NetProfitCalculation(taxablePolicies);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        [InlineData(-3400)]
        public void ReturnZeroProfitForGivenZeroOrNegativeAmount(decimal value)
        {
            var result = _netProfitCalculation.CalculateProfit(value);

            Assert.True(result == 0, $"Profit for {value} should be zero.");
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(1100)]
        [InlineData(3400)]
        public void ReturnPositiveTaxForGivenPositiveAmount(decimal value)
        {
            var result = _netProfitCalculation.CalculateProfit(value);

            Assert.True(result > 0, $"Profit for {value} should be positive.");
        }

        [Fact]
        public void ReturnTaxAmountEqualsZero()
        {
            var amount = 0;
            var profit = 0;
            var result = _netProfitCalculation.CalculateProfit(amount);
            Assert.True(result == profit);
        }

        [Fact]
        public void ReturnTaxAmountEquals980()
        {
            var amount = 980;
            var profit = 980;
            var result = _netProfitCalculation.CalculateProfit(amount);
            Assert.True(result == profit);
        }

        [Fact]
        public void ReturnTaxAmountEquals2860()
        {
            var amount = 3400;
            var profit = 2860; 
            var result = _netProfitCalculation.CalculateProfit(amount);
            Assert.True(result == profit);
        }
    }
}
