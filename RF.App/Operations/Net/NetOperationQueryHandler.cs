using RF.Domain.Services;
using RF.Domain.Services.Profit;

namespace RF.App.Operations.Net
{
    public class NetOperationQueryHandler : IOperationQueryHandler<NetOperationQuery, NetOperationResult>
    {
        private readonly IProfitCalculationContainer _calculationOperations;

        public NetOperationQueryHandler(IProfitCalculationContainer calculationOperations)
        {
            _calculationOperations = calculationOperations;
        }

        public NetOperationResult Execute(NetOperationQuery query)
        {
            IProfitCalculation profitCalculation = _calculationOperations.Create(ProfitOperationType.Net);
            decimal profit = profitCalculation.CalculateProfit(query.Amount);
            return new NetOperationResult(profit);
        }
    }
}
