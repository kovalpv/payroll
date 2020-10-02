namespace Payroll.PayrollContext.Domain
{
    public class PayrollDetail
    {
        public PayrollDetail(string name, string description, Salary salary)
        {
            Name = name;
            Description = description;
            Salary = salary;
        }

        public string Name { get; }
        public string Description { get; }
        public Salary Salary { get; }

        public override string ToString() {
            return $"{Name} {Description} {Salary}";
        }
    }
}