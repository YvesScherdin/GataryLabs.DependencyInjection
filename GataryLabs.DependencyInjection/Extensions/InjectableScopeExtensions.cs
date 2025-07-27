using GataryLabs.DependencyInjection.Abstractions.Exceptions;
using System;
using System.Collections.Generic;

namespace GataryLabs.DependencyInjection.Extensions
{
    public static class InjectableScopeExtensions
    {
        // resolving

        public static TTarget ResolveInstance<TTarget>(this InjectableScope scope) where TTarget : new()
        {
            object instance = scope.ResolveInstance(typeof(TTarget));

            return instance != null ? (TTarget)instance : default;
        }

        // unregistration

        public static void Unregister<TInsance>(this InjectableScope scope)
        {
            scope.Unregister(typeof(TInsance));
        }

        public static void Unregister<TInsance>(this InjectableScope scope, object instance)
        {
            scope.Unregister(typeof(TInsance), instance);
        }

        // registration

        // transient

        public static void RegisterAsTransient<TTargetAndInstance>(this InjectableScope scope) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, null, InjectionType.Transient);

        public static void RegisterAsTransient<TTarget, TInstance>(this InjectableScope scope) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, null, InjectionType.Transient);

        public static void RegisterAsTransient<TTargetAndInstance>(this InjectableScope scope, Func<object> factoryMethod) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, factoryMethod, InjectionType.Transient);

        public static void RegisterAsTransient<TTarget, TInstance>(this InjectableScope scope, Func<object> factoryMethod) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, factoryMethod, InjectionType.Transient);

        // scoped

        public static void RegisterAsScoped<TTargetAndInstance>(this InjectableScope scope) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, null, InjectionType.Scoped);

        public static void RegisterAsScoped<TTarget, TInstance>(this InjectableScope scope) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, null, InjectionType.Scoped);

        public static void RegisterAsScoped<TTargetAndInstance>(this InjectableScope scope, object instance) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), instance, null, InjectionType.Scoped);

        public static void RegisterAsScoped<TTarget, TInstance>(this InjectableScope scope, object instance) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), instance, null, InjectionType.Scoped);

        public static void RegisterAsScoped<TTargetAndInstance>(this InjectableScope scope, Func<object> factoryMethod) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, factoryMethod, InjectionType.Scoped);

        public static void RegisterAsScoped<TTarget, TInstance>(this InjectableScope scope, Func<object> factoryMethod) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, factoryMethod, InjectionType.Scoped);

        // singleton

        public static void RegisterAsSingleton<TTargetAndInstance>(this InjectableScope scope) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, null, InjectionType.Singleton);
        
        public static void RegisterAsSingleton<TTarget, TInstance>(this InjectableScope scope) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, null, InjectionType.Singleton);

        public static void RegisterAsSingleton<TTargetAndInstance>(this InjectableScope scope, object instance) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), instance, null, InjectionType.Singleton);
        
        public static void RegisterAsSingleton<TTarget, TInstance>(this InjectableScope scope, object instance) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), instance, null, InjectionType.Singleton);
        
        public static void RegisterAsSingleton<TTargetAndInstance>(this InjectableScope scope, Func<object> factoryMethod) where TTargetAndInstance : new()
            => scope.Register(typeof(TTargetAndInstance), typeof(TTargetAndInstance), null, factoryMethod, InjectionType.Singleton);
        
        public static void RegisterAsSingleton<TTarget, TInstance>(this InjectableScope scope, Func<object> factoryMethod) where TInstance : TTarget, new()
            => scope.Register(typeof(TTarget), typeof(TInstance), null, factoryMethod, InjectionType.Singleton);

        private static void Register(
            this InjectableScope scope,
            Type keyType, Type instanceType,
            object instance, Func<object> factoryMethod,
            InjectionType injectionType)
        {
            if (scope.Contains(keyType))
            {
                throw new DependencyInjectionException($"Already registered: '{keyType}'");
            }

            InjectableInfo info = new InjectableInfo
            {
                keyType = keyType,
                instanceType = instanceType,
                injectionType = injectionType,
                factoryMethod = factoryMethod,
                instances = new List<object>()
            };

            if (instance != null)
            {
                if (injectionType == InjectionType.Transient)
                    throw new DependencyInjectionException($"Cannot provide injectable instance for transient injectables.");

                info.instances.Add(instance);
            }

            scope.Register(info);
        }
    }
}
