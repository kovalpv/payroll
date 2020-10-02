using System;

namespace Payroll.PayrollContext.Domain.Exceptions
{
    public class SalaryOperationException : Exception
    {
        public SalaryOperationException(string message) : base(message)
        {
        }
    }
}