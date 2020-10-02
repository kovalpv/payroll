using Payroll.Core.Domain;

namespace Payroll.EmployeeContext.Domain
{
    public class EmployeeId : StringIdentity
    {
        public EmployeeId(string value) : base(value)
        {
        }

        public override string ToString() {
            return $"EmployeeId: {GetValue()}";
        }
    }
}