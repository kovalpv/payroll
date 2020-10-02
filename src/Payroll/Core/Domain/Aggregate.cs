namespace Payroll.Core.Domain {
    public interface AggregateRoot<T>
        where T : Entity {
            T Root { get; }
        }
}