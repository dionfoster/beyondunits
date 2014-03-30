using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeyondUnitsDemo.Tests.Helpers
{
    public class CollectionApprovalReport<T>
    {
        public string Header { get; set; }
        public IEnumerable<T> Body { get; set; }
        public Func<T, string> BodyFormatter { get; set; }

        public CollectionApprovalReport()
        {
            BodyFormatter = o => o.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (Body.Any())
            {
                var border = new string('=', Header.Length);

                sb.AppendLine(border);
                sb.AppendLine(Header);
                sb.AppendLine(border);

                foreach (var o in Body)
                {
                    sb.AppendLine(BodyFormatter(o));
                }
            }

            return sb.ToString();
        }
    }
}