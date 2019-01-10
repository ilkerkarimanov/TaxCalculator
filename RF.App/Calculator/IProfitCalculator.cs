namespace RF.App.Calculator
{
    public interface IProfitCalculator
    {
        ProfitResult CalculateNet(ProfitQuery query);
    }
}
