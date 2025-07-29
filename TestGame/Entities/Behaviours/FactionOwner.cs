using GataryLabs.DependencyInjection.Attributes;
using TestGame.World;

namespace TestGame.Entities.Behaviours
{
    [InjectionTarget]
    public class FactionOwner
    {
        [Inject]
        public FactionController factionController;
    }
}
