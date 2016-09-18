using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assets.Lib.Ioc
{
    public class BasicIocContainer
    {
        private readonly IDictionary<Type, object> instances = new Dictionary<Type, object>();
        private readonly IDictionary<Type, Type> mappings = new Dictionary<Type, Type>();

        public void Initialize(IEnumerable<Assembly> assemblies)
        {
        }

        public T Get<T>()
        {
            return (T)this.Get(typeof(T));
        }

        public object Get(Type type)
        {
            try
            {
                object instance;

                if (!this.instances.TryGetValue(type, out instance))
                {
                    instance = this.Build(type);

                    this.instances[type] = instance;
                }

                return instance;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to load type " + type, exception);
            }
        }

        private object Build(Type type)
        {
            Type concreteType;

            if (!this.mappings.TryGetValue(type, out concreteType) || (!type.IsInterface && !type.IsAbstract))
            {
                concreteType = type;
            }

            if (concreteType != null)
            {
                var result = this.BuildConcrete(concreteType);
                this.Inject(result);

                return result;
            }
            else
            {
                return null;
            }
        }

        public T Build<T>()
        {
            return (T) this.Build(typeof(T));
        }

        private object BuildConcrete(Type concreteType)
        {
            var constructors = concreteType.GetConstructors().Where(c => !c.IsStatic);

            if (constructors.Count() > 1)
            {
                throw new Exception("Unable to build type " + concreteType.Name + ": it has more than one constructor.");
            }

            var constructor = constructors.Single();

            var parameters = constructor
                .GetParameters()
                .Select(parameter => parameter.ParameterType)
                .Select(type => this.Get(type)).ToArray();

            var builtObject = constructor.Invoke(parameters);

            this.Inject(builtObject);

            return builtObject;
        }

        public void Register<TPublicType, TImplementation>() where TImplementation : TPublicType
        {
            this.Register(typeof(TPublicType), typeof(TImplementation));
        }

        public void Register<TPublicType>() where TPublicType : class
        {
            this.Register<TPublicType, TPublicType>();
        }

        public void RegisterSingleton<TPublicType>() where TPublicType : class
        {
            this.Register<TPublicType, TPublicType>();
        }

        public void Register<TPublicType>(TPublicType @object)
        {
            this.instances[typeof(TPublicType)] = @object;
        }

        public void Register(Type publicType, Type implementationType)
        {
            this.mappings[publicType] = implementationType;
        }

        public void Inject(object item)
        {
            foreach (var property in this.GetAllProperties(item.GetType()).Where(this.MustInject))
            {
                this.InjectProperty(property, item);
            }
        }

        private void InjectProperty(PropertyInfo property, object container)
        {
            var setFunction = property.GetSetMethod();

            if (setFunction == null)
            {
                setFunction = property.GetSetMethod();
            }

            if (setFunction == null)
            {
                throw new Exception("The property " + property.DeclaringType + " of type " + property.Name + " can't be injected: it doesn't have a mutator.");
            }
            
            var value = this.Get(property.PropertyType);

            setFunction.Invoke(container, new[] { value });
        }

        private IEnumerable<PropertyInfo> GetAllProperties(Type type)
        {
            return type.GetProperties();
        }

        private bool MustInject(PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(InjectAttribute), true).Any();
        }
    }
}