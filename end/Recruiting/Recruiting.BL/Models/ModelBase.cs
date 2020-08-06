using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Recruiting.BL.Models
{
    public abstract class ModelBase<T> : IEquatable<T> where T : class
    {
        public virtual bool Equals([AllowNull] T other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            return Equals((T)obj);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(T left, T right)
        {
            return EqualityComparer<T>.Default.Equals(left, right);
        }

        public static bool operator !=(T left, T right)
        {
            return !(left == right);
        }
    }
}
