using Payroll.PayrollContext.Domain.Exceptions;

namespace Payroll.PayrollContext.Domain {
    public class Salary {

        public Salary (double value, Currency currency) {
            Value = value;
            Currency = currency;
        }

        public double Value { get; }
        public Currency Currency { get; }

        public Salary Add (Salary added) {
            ThrowIfCurrencyIsNotEqual (added, "different added currency");
            return new Salary (value: Value + added.Value, currency: Currency);
        }

        private void ThrowIfCurrencyIsNotEqual (Salary added, string message) {
            if (added.Currency != Currency) {
                throw new SalaryOperationException (message);
            }
        }

        public Salary Substract (Salary substracted) {
            ThrowIfCurrencyIsNotEqual (substracted, "different substracted currency");
            return new Salary (value: Value - substracted.Value, currency: Currency);
        }

        public Salary Multiply(double multiply)
        {
            return new Salary (value: multiply * Value, currency: Currency);
        }

        public override string ToString()
        {
            return $"Salary: {Value} {Currency}";
        }
    }
}