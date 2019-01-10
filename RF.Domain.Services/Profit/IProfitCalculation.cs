namespace RF.Domain.Services.Profit
{
    public interface IProfitCalculation
    {
        decimal CalculateProfit(decimal amount);
        bool IsSatisfied(ProfitOperationType type);
    }
}
