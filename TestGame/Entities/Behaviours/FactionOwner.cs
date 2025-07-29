using GataryLabs.DependencyInjection.Attributes;
using TestGame.World;

namespace TestGame.Entities.Behaviours
{
    [InjectionTarget]
    internal class FactionOwner
    {
        [Inject]
        public FactionController factionController;
    }
}
