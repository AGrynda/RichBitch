using Autofac;

namespace RichBitch
{
    public static class DIService
    {
        public static IContainer Container { get; set; }

        static DIService()
        {
            Initialize();
        }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BalanceManager>();
            builder.RegisterType<CurrencyConverter>();

            Container = builder.Build();
        }
    }
}