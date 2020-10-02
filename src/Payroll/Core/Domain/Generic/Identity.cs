using System;

namespace Payroll.Core.Domain.Generic {
    public interface Identity<T> : Identity, IEquatable<Identity<T>>, IComparable<Identity<T>> {
        new T GetValue();
    }
}