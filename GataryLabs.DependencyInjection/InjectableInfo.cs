using System;
using System.Collections.Generic;

namespace GataryLabs.DependencyInjection
{
    internal class InjectableInfo
    {
        internal Type keyType;
        internal Type instanceType;
        internal List<object> instances = new List<object>();
        internal Func<object> factoryMethod;
        internal InjectionType injectionType;
    }
}
