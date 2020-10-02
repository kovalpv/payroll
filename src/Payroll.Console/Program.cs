using System;
using Payroll.EmployeeContext.Domain;
using Payroll.PayrollContext.Domain;

namespace Payroll.console {
    class Program {
        static void Main (string[] args) {
            
            var year = 2020;
            var month = 1;
            var emmployees = new [] {
                CreateEmployee01 (year, month),
                CreateEmployee02 (year, month)
            };

            foreach (var employee in emmployees) {
                System.Console.WriteLine (employee.CalculateSalary (new Period (year, month)));
            }

        }

        private static HourlyEmployee CreateEmployee01 (int year, int month) {
            var empId = new EmployeeId ("employee-01");

            var salaryOfHour = new Salary (8, Currency.Dollar);
            var employee = new HourlyEmployee (
                id: empId,
                salaryOfHour: salaryOfHour,
                timeCards: new TimeCards (new [] { new TimeCard (new DateTime (year, month, 1), 8) })
            );
            return employee;
        }

        private static HourlyEmployee CreateEmployee02 (int year, int month) {
            var empId = new EmployeeId ("employee-02");

            var salaryOfHour = new Salary (8, Currency.Dollar);
            var employee = new HourlyEmployee (
                id: empId,
                salaryOfHour: salaryOfHour,
                timeCards: new TimeCards (new [] { new TimeCard (new DateTime (year, month, 1), 10) })
            );
            return employee;
        }
    }
}