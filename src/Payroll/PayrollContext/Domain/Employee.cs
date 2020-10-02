using System.Collections.Generic;
using Payroll.EmployeeContext.Domain;

namespace Payroll.PayrollContext.Domain {
    public class HourlyEmployee {
        private const double OVERTIME_FACTOR = 1.5;

        public HourlyEmployee (EmployeeId id, Salary salaryOfHour, TimeCards timeCards) {
            Id = id;
            SalaryOfHour = salaryOfHour;
            TimeCards = timeCards;
        }

        public EmployeeId Id { get; }
        public Salary SalaryOfHour { get; }
        public TimeCards TimeCards { get; }

        public Payroll CalculateSalary (Period period) {
            var regularWorkHours = TimeCards.RegularWorkHours (period);
            var regularSalary = SalaryOfHour.Multiply (regularWorkHours);
            var overtimeWorkHours = TimeCards.OvertimeWorkHours (period);
            var overtimeSalary = SalaryOfHour.Multiply (OVERTIME_FACTOR * overtimeWorkHours);
            var periodSalary = regularSalary.Add (overtimeSalary);

            var payrollDetails = new List<PayrollDetail> ();
            if (regularWorkHours > 0) {
                payrollDetails.Add (new PayrollDetail ("regular work:", $"{regularWorkHours} hours", regularSalary));
            }

            if(overtimeWorkHours >0 ) {
                payrollDetails.Add(new PayrollDetail("overtime work:", $"{overtimeWorkHours} hours", overtimeSalary));
            }

            return new Payroll (employeeId: Id,
                begin: period.Begin,
                end: period.End,
                salary: periodSalary,
                details: payrollDetails);
        }
    }
}