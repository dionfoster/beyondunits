using System;
using System.IO;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Approvals = ApprovalTests.Approvals;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class ImageTests
    {
        [UseReporter(typeof(ImageReporter))]
        [Test]
        public void Test_an_image()
        {
            var imagePath = Path.Combine(Environment.CurrentDirectory, "test.jpg");

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            var imageInfo = new FileInfo(imagePath);

            ImageGenerator.Create(imagePath, "Test it!!");

            Approvals.Verify(imageInfo);
        }
    }
}