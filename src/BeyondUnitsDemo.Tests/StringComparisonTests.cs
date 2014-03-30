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
            Approvals.Verify("apple");
        }
    }
}
