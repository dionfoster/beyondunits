using Autofac;
using BeyondUnitsDemo.Controllers;

namespace BeyondUnitsDemo.Infrastructure
{
    public class Bootstrapper
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ImageController>();
            builder.RegisterType<PersonController>();
            builder.RegisterType<ProjectController>();

            return builder.Build();
        }
    }
}