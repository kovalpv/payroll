using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Payroll.PayrollContext.Domain;

namespace Payroll.Tests.PayrollContext.Domain {
    public class TimeCardsTests {

        private bool IsWorkDay (DateTime date) {
            var weekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            return !weekend;
        }

        public IEnumerable<TimeCard> buildYearWorks (int year, int workHours = 8) {
            var date = new DateTime (year, 1, 1);
            var end = new DateTime (year, 12, 31);
            var timeCards = new List<TimeCard> ();
            while (date < end) {

                if (IsWorkDay (date)) {
                    timeCards.Add (new TimeCard (date.Date, workHours));
                }
                date = date.AddDays (1);
            }
            return timeCards.AsEnumerable ();
        }

        [Test]
        public void ShouldCreateTimeCard () {

            var timeCards = new TimeCards (buildYearWorks (2020));
            var period = new Period (2020, 1);
            var workHours = timeCards.RegularWorkHours (period);
            Assert.AreEqual (184, workHours);
        }

        [Test]
        public void ShouldCreateTimeCard1 () {
            var timeCards = new TimeCards (buildYearWorks (2020, 10));
            var period = new Period (2020, 1);
            var overtimeHours = timeCards.OvertimeWorkHours (period);
            Assert.AreEqual (46, overtimeHours);
        }

        [Test]
        public void ShouldReturnEmptyWhenArgumentIsNull () {
            var timeCards = new TimeCards (null);
            var period = new Period (2020, 1);
            var workHours = timeCards.RegularWorkHours (period);
            var overtimeHours = timeCards.OvertimeWorkHours (period);
            Assert.AreEqual (0, workHours);
            Assert.AreEqual (0, overtimeHours);
        }

    }
}