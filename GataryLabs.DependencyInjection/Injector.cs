using GataryLabs.DependencyInjection.Abstractions.Exceptions;
using GataryLabs.DependencyInjection.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace GataryLabs.DependencyInjection
{
    internal class Injector
    {
        internal void CheckInjection(object instance, Type type, InjectableScope injectableScope)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.SetField
                | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic;

            InjectionTargetAttribute injectionTargetAttribute = type.GetCustomAttribute<InjectionTargetAttribute>();

            if (injectionTargetAttribute != null)
            {
                FieldInfo[] fields = type.GetFields(flags);

                foreach (FieldInfo field in fields)
                {
                    InjectAttribute injectAttribute = field.GetCustomAttribute<InjectAttribute>();

                    if (injectAttribute != null)
                    {
                        Type typeOfInstanceToResolve = field.FieldType;
                        object valueToInject = injectableScope.ResolveInstance(typeOfInstanceToResolve);

                        if (valueToInject != null)
                            field.SetValue(instance, valueToInject);
                        else if (!injectAttribute.IgnoreMissing)
                            throw new DependencyInjectionException(
                                $"Cannot resolve instance '{field.Name}' of type '{field.FieldType}'.");
                    }
                }

                PropertyInfo[] properties = type.GetProperties(flags);

                foreach (PropertyInfo property in properties)
                {
                    InjectAttribute injectAttribute = property.GetCustomAttribute<InjectAttribute>();

                    if (injectAttribute != null)
                    {
                        Type typeOfInstanceToResolve = property.PropertyType;
                        object valueToInject = injectableScope.ResolveInstance(typeOfInstanceToResolve);

                        if (valueToInject != null)
                        {
                            MethodInfo setterMethod = property.GetSetMethod() ?? property.GetSetMethod(true);
                            setterMethod.Invoke(instance, new object[] { valueToInject });
                        }
                        else if (!injectAttribute.IgnoreMissing)
                            throw new DependencyInjectionException(
                                $"Cannot resolve instance '{property.Name}' of type '{property.PropertyType}'.");
                    }
                }

                MethodInfo[] methods = type.GetMethods(flags);

                foreach (MethodInfo method in methods)
                {
                    InjectAttribute injectAttribute = method.GetCustomAttribute<InjectAttribute>();

                    if (injectAttribute != null)
                    {
                        ParameterInfo[] parameterInfos = method.GetParameters();
                        object[] methodParameters = new object[parameterInfos.Length];

                        for (int i = 0; i < parameterInfos.Length; i++)
                        {
                            object valueToInject = injectableScope.ResolveInstance(parameterInfos[i].ParameterType);

                            if (valueToInject != null)
                                methodParameters[i] = valueToInject;
                            else if (!injectAttribute.IgnoreMissing)
                                throw new DependencyInjectionException(
                                    $"Cannot resolve instance of method parameter '{parameterInfos[i].Name}' of type '{parameterInfos[i].ParameterType}'.");
                        }

                        method.Invoke(instance, methodParameters);
                    }
                }
            }
        }

        internal Type[] FindInjectableConstructorParameters(Type type)
        {
            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                InjectAttribute requiredAttribute = constructor.GetCustomAttribute<InjectAttribute>();

                if (requiredAttribute != null)
                {
                    Type[] parameterTypes = constructor.GetParameters()
                        .Select(parameterInfo => parameterInfo.ParameterType)
                        .ToArray();

                    return parameterTypes;
                }
            }

            return new Type[0];
        }
    }
}
