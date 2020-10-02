using System;
using System.Collections.Generic;
using NUnit.Framework;
using Payroll.EmployeeContext.Domain;
using Payroll.PayrollContext.Domain;

namespace Payroll.Tests.PayrollContext.Domain {
    public class HourlyEmployeeTests {
        [Test]
        public void ShouldCalculateOnlyRegularJanuar2020Salary () {
            var employeeId = new EmployeeId ("emp-01");
            var salary = new Salary (100, Currency.Dollar);
            var employee = new HourlyEmployee (employeeId, salary, buildYearWorks (2020, 8));

            var januar2020Salary = employee.CalculateSalary (new Period (2020, 1));
            Assert.AreEqual (18400, januar2020Salary.Salary.Value);
            Assert.AreEqual (Currency.Dollar, januar2020Salary.Salary.Currency);
            Assert.AreEqual (new DateTime(2020, 1, 1), januar2020Salary.Begin);
            Assert.AreEqual (new DateTime(2020, 1, 31), januar2020Salary.End);
        }

        [Test]
        public void ShouldCalculateWithOvertimeJanuar2020Salary () {
            var employeeId = new EmployeeId ("emp-02");
            var salary = new Salary (100, Currency.Dollar);
            var employee = new HourlyEmployee (employeeId, salary, buildYearWorks (2020, 10));

            var januar2020Salary = employee.CalculateSalary (new Period (2020, 1));
            Assert.AreEqual (18400 + 6900, januar2020Salary.Salary.Value);
            Assert.AreEqual (Currency.Dollar, januar2020Salary.Salary.Currency);
            Assert.AreEqual (new DateTime(2020, 1, 1), januar2020Salary.Begin);
            Assert.AreEqual (new DateTime(2020, 1, 31), januar2020Salary.End);
        }

        private bool IsWorkDay (DateTime date) {
            var weekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            return !weekend;
        }

        public TimeCards buildYearWorks (int year, int workHours = 8) {
            var date = new DateTime (year, 1, 1);
            var end = new DateTime (year, 12, 31);
            var timeCards = new List<TimeCard> ();
            while (date < end) {

                if (IsWorkDay (date)) {
                    timeCards.Add (new TimeCard (date.Date, workHours));
                }
                date = date.AddDays (1);
            }
            return new TimeCards (timeCards);
        }
    }
}