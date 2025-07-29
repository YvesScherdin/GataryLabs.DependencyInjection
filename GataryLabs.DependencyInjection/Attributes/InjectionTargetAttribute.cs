using System;

namespace GataryLabs.DependencyInjection.Attributes
{
    public class InjectionTargetAttribute : Attribute
    {
        public InjectionFlags Flags { get; private set; }

        public InjectionTargetAttribute(InjectionFlags flags = InjectionFlags.All)
        {
            this.Flags = flags;
        }
    }
}
