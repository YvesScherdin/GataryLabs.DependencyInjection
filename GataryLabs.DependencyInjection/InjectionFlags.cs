namespace GataryLabs.DependencyInjection
{
    public enum InjectionFlags
    {
        None = 0,
        Fields = 1,
        Properties = 2,
        Methods = 4,
        Constructors = 8,

        // composite presets
        Simple = Fields | Properties,
        Default = Fields | Properties | Constructors,
        All = Fields | Properties | Methods | Constructors
    }
}
