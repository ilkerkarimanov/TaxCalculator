namespace RF.App.Operations
{
    public interface IOperationQueryHandler<in TQuery, TResult> where TQuery : IOperationQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
