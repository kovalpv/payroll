using System;

namespace Payroll.PayrollContext.Domain.Exceptions
{
    public class NegativeWorkHoursException : Exception
    {
        public NegativeWorkHoursException(int workHours) : base($"Negative work time {workHours}")
        {
        }
    }
}