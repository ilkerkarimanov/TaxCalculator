namespace RF.App.Operations.Net
{
    public class NetOperationResult
    {
        public decimal Amount { get; }

        public NetOperationResult(decimal amount)
        {
            Amount = amount;
        }
    }
}
