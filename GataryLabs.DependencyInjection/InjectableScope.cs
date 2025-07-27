using GataryLabs.DependencyInjection.Abstractions.Exceptions;
using System;
using System.Collections.Generic;

namespace GataryLabs.DependencyInjection
{
    public class InjectableScope : IDisposable
    {
        private Dictionary<Type, InjectableInfo> instancesByType;
        private Injector injector;

        private InjectableScope parentScope;

        public InjectableScope()
        {
            instancesByType = new Dictionary<Type, InjectableInfo>();
            injector = new Injector();
        }

        public void Dispose()
        {
            instancesByType = null;
            injector = null;
        }

        public InjectableScope CreateScope()
        {
            InjectableScope childScope = new InjectableScope();
            childScope.parentScope = this;

            return childScope;
        }

        internal bool Contains(Type keyType)
        {
            return instancesByType.ContainsKey(keyType);
        }

        internal void Register(InjectableInfo info)
        {
            instancesByType[info.keyType] = info;
        }
        
        public void Unregister(Type type)
        {
            instancesByType.Remove(type);
        }

        public void Unregister(Type type, object instance)
        {
            if (!instancesByType.ContainsKey(type))
                return;

            instancesByType[type].instances.Remove(instance);
        }

        public object[] ResolveInstancesFromTypes(Type[] keyTypes)
        {
            List<object> list = new List<object>();

            foreach(Type type in keyTypes)
            {
                object instance = ResolveInstance(type);
                list.Add(instance);
            }

            return list.ToArray();
        }

        public object ResolveInstance(Type keyType)
        {
            if (!instancesByType.ContainsKey(keyType))
                return null;

            InjectableInfo info = instancesByType[keyType];

            switch (info.injectionType)
            {
                case InjectionType.Scoped:    return ResolveScopedInstance(info);
                case InjectionType.Singleton: return ResolveSingletonInstance(info);
                case InjectionType.Transient: return ResolveTransientInstance(info);

                default:
                    throw new DependencyInjectionException($"Unknown injection type: '{info.injectionType}' for type '{keyType}'.");
            }
        }

        private object ResolveTransientInstance(InjectableInfo info)
        {
            object newInstance = CreateNewInstance(info, this);

            if (newInstance == null && parentScope != null)
            {
                return parentScope.ResolveInstance(info.keyType);
            }

            return newInstance;
        }

        private object ResolveSingletonInstance(InjectableInfo info)
        {
            if (info.instances != null
                && info.instances.Count != 0
                && info.instances[0] != null)
            {
                return info.instances[0];
            }

            object newInstance = CreateNewInstance(info, this);

            if (newInstance == null)
            {
                if (parentScope != null)
                    return parentScope.ResolveInstance(info.keyType);
            }
            else if (info.injectionType != InjectionType.Transient)
            {
                info.instances = new List<object>
                {
                    newInstance
                };
            }

            return newInstance;
        }

        private object ResolveScopedInstance(InjectableInfo info)
        {
            object newInstance = CreateNewInstance(info, this);
            return newInstance;
        }

        private static object CreateNewInstance(InjectableInfo info, InjectableScope scope)
        {
            if (info.factoryMethod != null)
            {
                object newInstance = info.factoryMethod();
                scope.injector.CheckInjection(newInstance, info.instanceType, scope);
                return newInstance;
            }
            else
            {
                object newInstance = Construct(info.instanceType, scope);
                scope.injector.CheckInjection(newInstance, info.instanceType, scope);
                return newInstance;
            }
        }

        private static object Construct(Type type, InjectableScope scope)
        {
            Type[] injectableConstructoreTypes = scope.injector.FindInjectableConstructorParameters(type);

            if (injectableConstructoreTypes != null && injectableConstructoreTypes.Length != 0)
            {
                object[] argumentInstances = scope.ResolveInstancesFromTypes(injectableConstructoreTypes);
                object instance = Activator.CreateInstance(type, argumentInstances);
                return instance;
            }
            else
            {
                object instance = Activator.CreateInstance(type);
                return instance;
            }
        }
    }
}
