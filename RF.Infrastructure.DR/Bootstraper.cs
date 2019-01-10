using RF.App.Calculator;
using RF.App.Operations;
using RF.App.Operations.Net;
using RF.Domain.Models.Taxes;
using RF.Domain.Services;
using RF.Domain.Services.Profit;
using RF.Domain.Services.Taxes.Income;
using RF.Domain.Services.Taxes.Social;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace RF.Infrastructure.DR
{
    public static class Bootstraper
    {
        public static readonly Container Container;

        static Bootstraper()
        {
            Container = new Container();
        }

        public static void Initiate()
        {
            Container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            Container.Register<ITaxableCriteria<IncomeTaxablePolicy>, IncomeTaxableCriteria>();
            Container.Register<ITaxableCriteria<SocialTaxablePolicy>, SocialTaxableCriteria>();

            Container.Collection.Register(typeof(ITaxablePolicy<>),
                new[]
            {
                    typeof(IncomeTaxablePolicy),
                    typeof(SocialTaxablePolicy)
            });

            Container.Collection.Register(typeof(IProfitCalculation), typeof(IProfitCalculation).Assembly);

            Container.Register<IProfitCalculationContainer, ProfitCalculationContainer>();

            Container.Register<IOperationQueryHandler<NetOperationQuery, NetOperationResult>, NetOperationQueryHandler>();

            Container.Register<IProfitCalculator, ProfitCalculator>();

            Container.Verify();
        }
    }
}
