using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Repositories
{
    public abstract class SpecializedRepository
    {
    }

    public class SpecializedRepository<T> : SpecializedRepository, IQueryable<T> where T : IWorldObject
    {
        private readonly IDictionary<string, T> items = new Dictionary<string, T>();

        public T GetById(string id)
        {
            return items[id];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType { get { return typeof(T); } }
        public Expression Expression { get { return items.Values.AsQueryable().Expression; } }
        public IQueryProvider Provider { get { return items.Values.AsQueryable().Provider; } }

        public void Create(T item)
        {
            this.items.Add(item.Id, item);
        }
    }
}