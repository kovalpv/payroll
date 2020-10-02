namespace Payroll.Core.Domain {
    public abstract class Entity {
        public Identity Id { get; protected set; }
    }
}