namespace Payroll.Core.Domain.Generic {
    public abstract class Entity<T> : Entity
        where T : Identity {
            new public T Id { get; protected set; }
        }
}