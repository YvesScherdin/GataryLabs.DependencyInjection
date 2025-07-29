using GataryLabs.DependencyInjection;
using GataryLabs.DependencyInjection.Attributes;
using System;
using TestGame.World;

namespace TestGame.Entities
{
    [InjectionTarget]
    public class EntityManager
    {
        [Inject]
        private EntityConfiguration configuration;

        [Inject(true)]
        private EntityObjectPool entityObjectPool;

        [Inject]
        public EntityDatabase Database { get; private set; }

        [Inject]
        private void Initialize(WorldContext worldContext)
        {
            Console.WriteLine("Init " + worldContext);
            Console.WriteLine("- cfg: " + configuration);
            Console.WriteLine("- db: " + Database);
            Console.WriteLine("- pool: " + entityObjectPool);
        }

        public BasicEntity Create(string type)
        {
            Console.WriteLine($"Loading type '{type}' from database '{Database}'.");

            return null;
        }
    }
}
