using GataryLabs.DependencyInjection;
using GataryLabs.DependencyInjection.Extensions;
using System;
using TestGame.Entities;
using TestGame.World;

namespace CustomDITestApp
{
    /// <summary>
    /// An integration test for the custom dependency framework.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            TestImaginaryScenario();
        }

        static private void TestImaginaryScenario()
        {
            InjectableScope scope = new InjectableScope();

            scope.RegisterAsSingleton<WorldContext>();
            scope.RegisterAsSingleton<EntityConfiguration>();
            scope.RegisterAsSingleton<EntityDatabase>();
            scope.RegisterAsSingleton<EntityManager>();

            EntityManager entityManager = scope.ResolveInstance<EntityManager>();

            Console.WriteLine("Entity manager resolved: " + entityManager);
        }

    }
}
