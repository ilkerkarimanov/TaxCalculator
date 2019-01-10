namespace RF.Domain.Models.Taxes
{
    public interface ITaxablePolicy<T>
        where T : TaxableIncome
    {
        decimal CalculateTax(T income);
        bool IsSatisfied(T income);
    }
}
