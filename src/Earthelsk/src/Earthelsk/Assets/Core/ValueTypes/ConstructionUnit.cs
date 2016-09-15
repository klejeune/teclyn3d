using System;

namespace Assets.Core.ValueTypes
{
    public struct ConstructionUnit : IComparable<ConstructionUnit>, IComparable
    {
        private readonly decimal amount;

        public decimal Amount { get { return this.amount; } }

        public ConstructionUnit(decimal amount)
        {
            this.amount = amount;
        }

        public static decimal operator /(ConstructionUnit c1, ConstructionUnit c2)
        {
            return c1.Amount / c2.Amount;
        }

        public static ConstructionUnit operator +(ConstructionUnit c1, ConstructionUnit c2)
        {
            return new ConstructionUnit(c1.Amount + c2.Amount);
        }
        public static ConstructionUnit operator -(ConstructionUnit c1, ConstructionUnit c2)
        {
            return new ConstructionUnit(c1.Amount - c2.Amount);
        }

        public int CompareTo(ConstructionUnit other)
        {
            return this.amount.CompareTo(other.amount);
        }

        public override bool Equals(object obj)
        {
            return this.amount == ((ConstructionUnit)obj).amount;
        }

        public override int GetHashCode()
        {
            return this.amount.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo((ConstructionUnit)obj);
        }
    }
}