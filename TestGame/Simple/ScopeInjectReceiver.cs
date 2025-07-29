using GataryLabs.DependencyInjection;
using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    [InjectionTarget]
    public class ScopeInjectReceiver
    {
        [Inject]
        public InjectableScope Scope { get; set; }
    }
}
