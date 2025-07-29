using GataryLabs.DependencyInjection.Attributes;
using TestGame.Entities;

namespace TestGame.Actions
{
    [InjectionTarget]
    internal class ActionContext
    {
        private EntityManager entityManager;
        public EntityManager EntityManager => entityManager;

        [Inject]
        private void Initialize(EntityManager entityManager)
        {
            this.entityManager = entityManager;
        }
    }
}
