namespace RF.Domain.Models.Taxes
{
    public interface ITaxableCriteria<T> where T : ITaxablePolicy<TaxableIncome>
    {
        TaxableRate GetRate();
    }
}
