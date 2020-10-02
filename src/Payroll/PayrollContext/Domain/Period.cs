using System;
using Payroll.PayrollContext.Domain.Exceptions;

namespace Payroll.PayrollContext.Domain {
    public class Period {
        public Period (int year, int month) {
            if (month < 1 || month > 12) {
                throw new InvalidDateException ($"Invalid month value '{month}'");
            }
            var daysInMoth = DateTime.DaysInMonth (year: year, month: month);
            Begin = new DateTime (year, month, 1);
            End = new DateTime (year, month, daysInMoth);
        }
        public DateTime Begin { get; }
        public DateTime End { get; }

        public bool Contains (DateTime date) {
            return Begin <= date.Date && date.Date <= End;
        }

    }
}