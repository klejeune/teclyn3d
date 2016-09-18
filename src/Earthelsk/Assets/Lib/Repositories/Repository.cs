using System;
using System.Collections.Generic;
using Assets.Lib.Ioc;
using Assets.Lib.WorldObjects;

namespace Assets.Lib.Repositories
{
    public class Repository
    {
        private readonly IDictionary<Type, SpecializedRepository> repositories = new Dictionary<Type, SpecializedRepository>();

        [Inject]
        public BasicIocContainer Container { get; set; }

        public T GetById<T>(string id) where T : IWorldObject
        {
            return this.Specialize<T>().GetById(id);
        }

        public T GetByIdOrNull<T>(string id) where T : IWorldObject
        {
            return this.Specialize<T>().GetByIdOrNull(id);
        }

        private SpecializedRepository<T> Specialize<T>() where T : IWorldObject
        {
            return this.repositories[typeof(T)] as SpecializedRepository<T>;
        }

        public void Register<T>() where T : IWorldObject
        {
            this.repositories[typeof(T)] = this.Container.Get<SpecializedRepository<T>>();
        }
    }
}