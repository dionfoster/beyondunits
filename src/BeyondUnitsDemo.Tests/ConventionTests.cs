using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApprovalTests;
using ApprovalTests.Reporters;
using BeyondUnitsDemo.Attributes;
using BeyondUnitsDemo.Controllers;
using BeyondUnitsDemo.Tests.Helpers;
using NUnit.Framework;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class ConventionTests
    {
        Assembly assembly;

        [SetUp]
        public void SetUp()
        {
            assembly = typeof(Controller).Assembly;
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void Only_admin_controllers_should_have_an_authorize_attribute()
        {
            var adminControllers = GetAdminControllers();

            var adminControllerReport = new CollectionApprovalReport<Type>
                                        {
                                            Header = "Admin Controller Types:",
                                            Body = adminControllers.WithAttribute<AuthorizeAttribute>()
                                        };

            var someonesStuffedUpReport = new CollectionApprovalReport<Type>
                                              {
                                                  Header = "These should not be authorized!!!",
                                                  Body = GetTypesWithAttribute<AuthorizeAttribute>().Except(adminControllers)
                                              };

            Approvals.Verify(adminControllerReport + Environment.NewLine + someonesStuffedUpReport);
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void All_administration_controllers_have_an_authorize_attribute()
        {
            var adminControllerReport = new CollectionApprovalReport<Type>
                                            {
                                                Header = "Authorized admin controllers:",
                                                Body = GetAdminControllers().WithAttribute<AuthorizeAttribute>()
                                            };

            var authorizeControllersReport = new CollectionApprovalReport<Type>
                                                 {
                                                     Header = "Controllers that need an authorize attribute:",
                                                     Body = GetAdminControllers().WithoutAttribute<AuthorizeAttribute>()
                                                 };

            Approvals.Verify(adminControllerReport + Environment.NewLine + authorizeControllersReport);
        }

        IEnumerable<Type> GetTypesWithAttribute<T>()
            where T : Attribute
        {
            return assembly
                        .GetTypesWithBaseType<Controller>()
                        .WithAttribute<T>();
        }

        IEnumerable<Type> GetAdminControllers()
        {
            return assembly
                .GetTypesWithBaseType<Controller>()
                .Where(t => t.Namespace.EndsWith("Admin"));
        }
    }
}