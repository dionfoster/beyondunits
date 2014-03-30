using ApprovalTests;
using ApprovalTests.Reporters;
using BeyondUnitsDemo.Tests.Helpers;
using NUnit.Framework;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class CollectionTests
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void People_are_ordered_by_firstname()
        {
            var people = new Data().GetPeopleOrderedByFirstName();

            var report = new MethodCalleeCollectionApprovalReport<Person>
                             {
                                 Body = people,
                                 BodyFormatter = o => string.Format("{0} {1}", o.Firstname, o.Surname)
                             };
            
            Approvals.Verify(report);
        }
    }
}
