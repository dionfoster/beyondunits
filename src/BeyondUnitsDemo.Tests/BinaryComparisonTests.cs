﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BeyondUnitsDemo.Tests
{
    [TestFixture]
    public class BinaryComparisonTests
    {
        [Test]
        public void Can_run_a_unit_test()
        {
            Assert.That(true, Is.EqualTo(true));
        }
    }
}