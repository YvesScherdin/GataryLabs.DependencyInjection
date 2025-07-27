using GataryLabs.DependencyInjection;
using GataryLabs.DependencyInjection.Extensions;
using System;
using TestGame.Entities;
using TestGame.World;

namespace CustomDITestApp
{
    internal class Program
    {
        static void Main(string[] args)
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
