using System;
using NUnit.Framework;
using Payroll.PayrollContext.Domain;

namespace Payroll.Tests.PayrollContext.Domain {
    public class TimeCardTests {

        [Test]
        public void ShouldCreateTimeCard () {
            var timeCard = new TimeCard (new DateTime (2020, 2, 1, 10, 0, 0), 8);
            Assert.AreEqual (new DateTime (2020, 2, 1), timeCard.WorkDate);
        }

        [Test]
        public void ShouldReturnTrueWhenHasOvertime () {
            var timeCard = new TimeCard (new DateTime (2020, 2, 1, 10, 0, 0), 10);
            Assert.IsTrue (timeCard.IsOvertime ());
        }

        [Test]
        public void ShouldReturnFalseWhenNoOvertime () {
            var timeCard = new TimeCard (new DateTime (2020, 2, 1, 10, 0, 0), 8);
            Assert.IsFalse (timeCard.IsOvertime ());
        }

        [Test]
        public void ShouldReturnTrueWhenIsInPeriod () {
            var timeCard = new TimeCard (new DateTime (2020, 2, 1, 10, 0, 0), 8);
            var period = new Period (2020, 2);
            Assert.IsTrue (timeCard.IsIn (period));
        }

        [Test]
        public void ShouldReturnFalseWhenIsInPeriod () {
            var timeCard = new TimeCard (new DateTime (2020, 2, 1, 10, 0, 0), 8);
            var period = new Period (2020, 1);
            Assert.IsFalse (timeCard.IsIn (period));
        }
    }
}