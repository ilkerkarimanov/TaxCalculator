using RF.Domain.Services.Profit;

namespace RF.Domain.Services
{
    public interface IProfitCalculationContainer
    {
        IProfitCalculation Create(ProfitOperationType type);
    }
}
