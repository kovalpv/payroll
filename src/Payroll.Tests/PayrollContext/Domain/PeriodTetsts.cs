using System;
using NUnit.Framework;
using Payroll.PayrollContext.Domain;
using Payroll.PayrollContext.Domain.Exceptions;

namespace Payroll.Tests.PayrollContext.Domain {
    public class PeriodTests {
        [Test]
        public void ShouldReturn2020January () {
            var period = new Period (2020, 1);
            Assert.AreEqual (new DateTime(2020, 1, 1), period.Begin);
            Assert.AreEqual (new DateTime(2020, 1, 31), period.End);
        }

        [Test]
        public void ShouldReturn2020Feb () {
            var period = new Period (2020, 2);
            Assert.AreEqual (new DateTime(2020, 2, 1), period.Begin);
            Assert.AreEqual (new DateTime(2020, 2, 29), period.End);
        }

        [Test]
        public void ShouldReturnExceptionWhenMonthEqualsZero () {
            var ex = Assert.Throws<InvalidDateException> (() => new Period (2020, 0));
        }

        [Test]
        public void ShouldReturnExceptionWhenMonthEqualsThirteen () {
            var ex = Assert.Throws<InvalidDateException> (() => new Period (2020, 13));
        }

        [Test]
        public void ShouldReturnTrueWhenDateIsInPeriod() {
            var period = new Period (2020, 2);
            Assert.IsTrue(period.Contains(new DateTime(2020, 2, 1)));
            Assert.IsTrue(period.Contains(new DateTime(2020, 2, 14)));
            Assert.IsTrue(period.Contains(new DateTime(2020, 2, 15)));
            Assert.IsTrue(period.Contains(new DateTime(2020, 2, 29, 23, 59, 59)));
        }

        
        [Test]
        public void ShouldReturnFalseWhenDateIsNotInPeriod() {
            var period = new Period (2020, 2);
            Assert.IsFalse(period.Contains(new DateTime(2020, 1, 31)));
            Assert.IsFalse(period.Contains(new DateTime(2020, 1, 31, 23, 59, 59)));
            Assert.IsFalse(period.Contains(new DateTime(2020, 3, 1)));
        }
    }
}