using RF.Domain.Services.Profit;
using System.Collections.Generic;
using System.Linq;

namespace RF.Domain.Services
{
    public class ProfitCalculationContainer : IProfitCalculationContainer
    {
        private readonly IEnumerable<IProfitCalculation> _calculations;

        public ProfitCalculationContainer(IEnumerable<IProfitCalculation> calculations)
        {
            _calculations = calculations;
        }

        public IProfitCalculation Create(ProfitOperationType type)
        {
            try {
                return _calculations.First(c => c.IsSatisfied(type));
            } catch {
                throw new System.Exception("Cannot create profit calculation.");
            }
        }
    }
}
