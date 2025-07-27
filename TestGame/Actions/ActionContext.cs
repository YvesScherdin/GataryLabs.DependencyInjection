using GataryLabs.DependencyInjection.Attributes;
using System;
using TestGame.Entities;

namespace TestGame.Actions
{
    [InjectionTarget]
    internal class ActionContext
    {
        [Inject]
        private void Initialize(EntityManager entityManager)
        {
            Console.WriteLine(entityManager);
        }
    }
}
