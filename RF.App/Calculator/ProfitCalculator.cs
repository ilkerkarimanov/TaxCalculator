using RF.App.Operations;
using RF.App.Operations.Net;

namespace RF.App.Calculator
{
    public class ProfitCalculator : IProfitCalculator
    {
        private readonly IOperationQueryHandler<NetOperationQuery, NetOperationResult> _netOperationHandler;

        public ProfitCalculator(IOperationQueryHandler<NetOperationQuery, NetOperationResult> netOperationHandler)
        {
            _netOperationHandler = netOperationHandler;
        }

        public ProfitResult CalculateNet(ProfitQuery query)
        {
            NetOperationQuery netRequest = new NetOperationQuery(query.Amount);

            NetOperationResult netResult = _netOperationHandler.Execute(netRequest);

            return new ProfitResult() { Amount = netResult.Amount };
        }
    }
}
