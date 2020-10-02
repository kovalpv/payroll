using NUnit.Framework;
using Payroll.PayrollContext.Domain;
using Payroll.PayrollContext.Domain.Exceptions;

namespace Payroll.Tests.PayrollContext.Domain {
    public class SalaryTests {

        [Test]
        public void ShouldAddSalaries () {
            var salaryA = new Salary (51, Currency.Dollar);
            var salaryB = new Salary (52, Currency.Dollar);
            var salary = salaryA.Add (salaryB);

            Assert.AreEqual (51.0, salaryA.Value);
            Assert.AreEqual (Currency.Dollar, salaryA.Currency);

            Assert.AreEqual (52.0, salaryB.Value);
            Assert.AreEqual (Currency.Dollar, salaryB.Currency);

            Assert.AreEqual (103.0, salary.Value);
            Assert.AreEqual (Currency.Dollar, salary.Currency);
        }

        [Test]
        public void ShouldThrowExceptionWhenAddDifferentCurrency () {
            var salaryA = new Salary (51, Currency.Dollar);
            var salaryB = new Salary (52, Currency.Rub);
            var exception = Assert.Throws<SalaryOperationException> (() => salaryA.Add (salaryB));
        }

        [Test]
        public void ShouldThrowExceptionWhenSubstractDifferentCurrency () {
            var salaryA = new Salary (51, Currency.Dollar);
            var salaryB = new Salary (52, Currency.Rub);
            var exception = Assert.Throws<SalaryOperationException> (() => salaryA.Substract (salaryB));
        }

        [Test]
        public void ShouldSubstractSalaries () {
            var salaryA = new Salary (103, Currency.Dollar);
            var salaryB = new Salary (52, Currency.Dollar);
            var salary = salaryA.Substract (salaryB);

            Assert.AreEqual (103, salaryA.Value);
            Assert.AreEqual (Currency.Dollar, salaryA.Currency);

            Assert.AreEqual (52, salaryB.Value);
            Assert.AreEqual (Currency.Dollar, salaryB.Currency);

            Assert.AreEqual (51, salary.Value);
            Assert.AreEqual (Currency.Dollar, salary.Currency);
        }

        [Test]
        public void ShouldMultiplySalary() {
            var salary = new Salary(100, Currency.Dollar);
            salary = salary.Multiply(5);
            Assert.AreEqual (500, salary.Value);
            Assert.AreEqual (Currency.Dollar, salary.Currency);
        }

    }
}