using System;

namespace GataryLabs.DependencyInjection.Attributes
{
    public class InjectAttribute : Attribute
    {
        public bool IgnoreMissing { get; }

        public InjectAttribute(bool ignoreMissing = false)
        {
            IgnoreMissing = ignoreMissing;
        }
    }

    public class InjectionTargetAttribute : Attribute
    {
        public InjectionTargetAttribute()
        {
        }
    }
}
