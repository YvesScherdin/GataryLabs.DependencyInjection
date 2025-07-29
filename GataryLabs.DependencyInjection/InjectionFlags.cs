namespace GataryLabs.DependencyInjection
{
    /// <summary>
    /// Flags with which the injection can be customized.
    /// </summary>
    public enum InjectionFlags
    {
        /// <summary>
        /// Includes no members.
        /// </summary>
        None = 0,

        /// <summary>
        /// Includes fields decorated with inject attribute.
        /// </summary>
        Fields = 1,

        /// <summary>
        /// Includes properties decorated with inject attribute.
        /// </summary>
        Properties = 2,

        /// <summary>
        /// Includes methods decorated within this type with the inject attribute (lacking those decorated in the base class)
        /// </summary>
        Methods = 4,

        /// <summary>
        /// Includes the first constructor that is decorated with the inject attribute.
        /// </summary>
        Constructors = 8,

        // composite presets

        /// <summary>
        /// Composite flags, including just fields and properties.
        /// </summary>
        Simple = Fields | Properties,

        /// <summary>
        /// Composite that lacks only methods.
        /// </summary>
        AllButMethods = Fields | Properties | Constructors,

        /// <summary>
        /// Composite that lacks only methods. For performance reasons, this is default.
        /// Many methods are resolved from even a class without custom methods.
        /// </summary>
        Default = AllButMethods,

        /// <summary>
        /// All.
        /// </summary>
        All = Fields | Properties | Methods | Constructors
    }
}
