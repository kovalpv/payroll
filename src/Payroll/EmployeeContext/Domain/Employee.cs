using Payroll.Core.Domain;

namespace Payroll.EmployeeContext.Domain {
    public class Employee : Payroll.Core.Domain.Generic.Entity<EmployeeId>, AggregateRoot<Employee> {
        public Employee (EmployeeId id, Address address) {
            Id = id;
            Address = address;
        }

        public Address Address { get; }

        public Employee Root { get { return this; } }

        public override string ToString () {
            return $"Employee: ({Id}, {Address})";
        }
    }
}