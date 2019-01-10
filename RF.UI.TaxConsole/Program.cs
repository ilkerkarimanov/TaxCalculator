using RF.App.Calculator;
using RF.Infrastructure.DR;
using System;

namespace RF.UI.TaxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstraper.Initiate();
            
            while (true)
            {
                Console.WriteLine("Enter income:");
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }

                decimal.TryParse(line, out decimal amount);

                var container = Bootstraper.Container;

                IProfitCalculator profitCalculator = container.GetInstance<IProfitCalculator>();

                var profit = profitCalculator.CalculateNet(new ProfitQuery() { Amount = amount });

                Console.WriteLine($"Your profit: {profit.Amount}");
            }            
        }
    }
}
