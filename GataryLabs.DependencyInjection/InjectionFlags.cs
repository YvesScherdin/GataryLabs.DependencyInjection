namespace GataryLabs.DependencyInjection
{
    public enum InjectionFlags
    {
        None = 0,

        Fields = 1,

        Properties = 2,

        Methods = 4,

        Constructors = 8,

        All = Fields | Properties | Methods | Constructors
    }
}
