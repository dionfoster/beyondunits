using System.Diagnostics;

namespace BeyondUnitsDemo.Tests.Helpers
{
    public class MethodCalleeCollectionApprovalReport<T> : CollectionApprovalReport<T>
    {
        public MethodCalleeCollectionApprovalReport()
        {
            var stackTrace = new StackTrace();
            var methodBase = stackTrace.GetFrame(1).GetMethod();

            Header = methodBase.Name.Replace("_", " ");
        }
    }
}