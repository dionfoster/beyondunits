using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class StringComparisonTests
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void An_apple_is_an_apple()
        {
            var fruit = "apple";

            Approvals.Verify(fruit);
        }
    }
}
