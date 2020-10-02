using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll.EmployeeContext.Domain;

namespace Payroll.PayrollContext.Domain {
    public class Payroll {
        public Payroll (EmployeeId employeeId, 
        DateTime begin, 
        DateTime end, 
        Salary salary, 
        IEnumerable<PayrollDetail> details = null) {
            EmployeeId = employeeId;
            Begin = begin;
            End = end;
            Salary = salary;
            Details = details != null ? details : Enumerable.Empty<PayrollDetail>();
        }

        public EmployeeId EmployeeId { get; }
        public DateTime Begin { get; }
        public DateTime End { get; }
        public Salary Salary { get; }
        public IEnumerable<PayrollDetail> Details { get; }

        public override string ToString () {
            var stringBuilder = new StringBuilder ();
            stringBuilder.AppendLine ($"Payroll: {EmployeeId} {Begin} {End} {Salary}");
            foreach (var detail in Details) {
                stringBuilder.AppendLine ($"\t - {detail.ToString ()}");
            }
            return stringBuilder.ToString ();
        }
    }
}