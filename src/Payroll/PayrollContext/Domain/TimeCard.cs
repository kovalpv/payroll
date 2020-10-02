using System;
using Payroll.PayrollContext.Domain.Exceptions;

namespace Payroll.PayrollContext.Domain {
    public class TimeCard {
        private const int MAX_WORK_HOURS = 8;
        private int workHours;
        private int regularWorkHours;
        private int overtimeWorkHours;

        public TimeCard (DateTime workDate, int workHours) {
            WorkHours = workHours;
            WorkDate = workDate.Date;

        }

        public int WorkHours {
            get { return workHours; }
            private set {
                workHours = value;
                if (value < 0) throw new NegativeWorkHoursException (value);
                regularWorkHours = value > MAX_WORK_HOURS ? MAX_WORK_HOURS : value;
                overtimeWorkHours = value > MAX_WORK_HOURS ? value - MAX_WORK_HOURS : 0;
            }
        }
        public DateTime WorkDate { get; }

        public int RegularWorkHours {
            get { return regularWorkHours; }
        }

        public int OvertimeWorkHours { get => overtimeWorkHours; }

        public bool IsOvertime () {
            return workHours > MAX_WORK_HOURS;
        }

        public bool IsIn (Period period) {
            return period.Contains (WorkDate);
        }
    }
}