using Payroll.Core.Domain.Generic;

namespace Payroll.Core.Domain {
    public class StringIdentity : Identity<string> {
        private readonly string value;

        public StringIdentity (string value) {
            this.value = value;
        }
        public string GetValue () {
            return value;
        }

        object Payroll.Core.Domain.Identity.GetValue () {
            return value;
        }

        public bool Equals (Identity<string> other) {
            if (ReferenceEquals (null, other)) return false;
            if (ReferenceEquals (this, other)) return true;
            if (other.GetType () != this.GetType ()) return false;
            return this.GetValue () == other.GetValue ();
        }

        public int CompareTo (Identity<string> other) {
            if (other == null) return 1;

            return this.value.CompareTo (other.GetValue ());
        }
        
        public override string ToString () {
            return $"StringIdentity: {GetValue()}";
        }
    }
}