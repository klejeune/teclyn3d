using System;
using Assets.Core.Buildings;
using Assets.Core.Buildings.Models;
using Assets.Core.Buildings.Models.Saloons;
using Assets.Core.Buildings.Saloons.Models;
using Assets.Core.Engine;
using Assets.Lib.Ioc;
using Assets.Lib.Logs;
using Assets.Lib.Repositories;
using Assets.Lib.WorldObjects;

namespace Assets.Lib
{
    public class TeclynUnity
    {
        public static TeclynUnity Initialize()
        {
            var teclyn = new TeclynUnity();
            
            teclyn.IocContainer = new BasicIocContainer();
            //teclyn.IocContainer.Initialize(teclyn.Plugins.Select(plugin => plugin.GetType().GetTypeInfo().Assembly));
            teclyn.IocContainer.Register(teclyn.IocContainer);
            teclyn.IocContainer.Register(teclyn);
            teclyn.RegisterServices();

            return teclyn;
        }

        public BasicIocContainer IocContainer { get; private set; }

        public void RegisterServices()
        {
            this.IocContainer.Register<Repository>();
            this.IocContainer.Register<ILogger, DummyLogger>();

            var repository = this.Get<Repository>();
            repository.Register<IWorldObject>();
            repository.Register<IBuilding>();
            repository.Register<IUnit>();
            repository.Register<Saloon>();
        }

        public T Get<T>()
        {
            return this.IocContainer.Get<T>();
        }

        public object Get(Type type)
        {
            return this.IocContainer.Get(type);
        }
    }
}