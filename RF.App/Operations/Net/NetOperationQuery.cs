namespace RF.App.Operations.Net
{
    public class NetOperationQuery : IOperationQuery<NetOperationResult>
    {
        public decimal Amount { get; }

        public NetOperationQuery(decimal amount)
        {
            Amount = amount;
        }
    }
}
