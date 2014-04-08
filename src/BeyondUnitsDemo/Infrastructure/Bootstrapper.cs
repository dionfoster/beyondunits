using Autofac;
using BeyondUnitsDemo.Controllers;

namespace BeyondUnitsDemo.Infrastructure
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (Controller).Assembly)
                   .Where(t => t.BaseType == typeof (Controller));

            return builder.Build();
        }
    }
}