namespace RF.Domain.Models
{
    public class Amount
    {
        public decimal Value { get; private set; }

        public Amount(decimal value)
        {
            Value = value;
        }
    }
}
