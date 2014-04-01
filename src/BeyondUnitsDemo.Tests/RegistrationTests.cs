using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using Autofac;
using Autofac.Core.Registration;
using BeyondUnitsDemo.Controllers;
using BeyondUnitsDemo.Infrastructure;
using BeyondUnitsDemo.Tests.Helpers;
using NUnit.Framework;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class ComponentTests
    {
        IContainer container;

        [SetUp]
        public void SetUp()
        {
            container = new Bootstrapper().BuildContainer();
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void All_controllers_are_registered()
        {
            var controllerTypes = typeof(Controller)
                                        .Assembly
                                        .GetTypesWithBaseType<Controller>();

            var unregisteredTypes = new List<Type>();
            var registeredTypes = new List<Type>();

            foreach (var controllerConfigurationType in controllerTypes)
            {
                try
                {
                    container.Resolve(controllerConfigurationType);

                    registeredTypes.Add(controllerConfigurationType);
                }
                catch (ComponentNotRegisteredException)
                {
                    unregisteredTypes.Add(controllerConfigurationType);
                }
            }

            var registeredReport = new CollectionApprovalReport<Type>
            {
                Header = "Successfully Registered:",
                Body = registeredTypes
            };
            var unregisteredReport = new CollectionApprovalReport<Type>
            {
                Header = "Not Registered:",
                Body = unregisteredTypes
            };

            Approvals.Verify(registeredReport + Environment.NewLine + unregisteredReport);
        }
    }
}