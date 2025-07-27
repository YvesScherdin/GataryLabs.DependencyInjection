using System;

namespace GataryLabs.DependencyInjection.Attributes
{
    /// <summary>
    /// A member that shall get values injected is required to be decorated with this attribute.
    /// It can be applied to constructors, methods, (setter-) properties and fields. Those may be nonpublic, too.
    /// The class that owns such members is required to be decorated with the <see cref="InjectionTargetAttribute"/>.
    /// </summary>
    /// <seealso cref="InjectionTargetAttribute"/>
    public class InjectAttribute : Attribute
    {
        public bool IgnoreMissing { get; }

        public InjectAttribute(bool ignoreMissing = false)
        {
            IgnoreMissing = ignoreMissing;
        }
    }
}
