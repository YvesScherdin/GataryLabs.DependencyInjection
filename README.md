# GataryLabs.DependencyInjection
A lightweight dependency injection solution in C#. Made for use in Unity.

## How to

- using [GataryLabs.DependencyInjection](https://github.com/YvesScherdin/GataryLabs.DependencyInjection/tree/main/GataryLabs.DependencyInjection)
	- .csproj-file not needed, actually
- prepare class
	- annotate class that shall receive dependency injection with attribute [InjectionTarget attribute](https://github.com/YvesScherdin/GataryLabs.DependencyInjection/tree/main/GataryLabs.DependencyInjection/Attributes)
	- annotate members of class with [Inject attribute](https://github.com/YvesScherdin/GataryLabs.DependencyInjection/blob/main/GataryLabs.DependencyInjection/Attributes/InjectAttribute.cs)
		- it may be fields, setter properties or methods
		- even members with private access modifiers are considered
	- See [example of how to prepare injectable members / parameters](https://github.com/YvesScherdin/GataryLabs.DependencyInjection/blob/main/TestGame/Entities/EntityManager.cs)
- prepare injectable scope (what Microsoft would call 'ServiceCollection', or 'ServiceProvider' after being built)
	- create instance, e.g. `InjectableScope scope = new InjectableScope();`
		- a hierarchical scope structure is possible; see `CreateScope()` method of InjectableScope instances, which creates a sub scope
	- register injectable stuff, e.g. `scope.RegisterAsTransient<MyClassThatWillBeInstantiatedWhenAskedFor>();`
		- factory methods are also possible
		- Transient, Scoped and Singleton are the supported ways to resolve instances
- resolve first instance
	- directly resolve instances from the same scope where you registered the dependency
		- e.g. `EntityManager myEntityManager = scope.ResolveInstance<EntityManager>();`
	- lean back and see how the dependencies get injected
	
## Not supported yet

- Lazy<>-Wrapper and resolver
- cyclic redundancy check - so just watch what you do
- real abstraction project GataryLabs.DependencyInjection.Abstractions, with interfaces like IInjectionScope

## Example

See below, or [here](https://github.com/YvesScherdin/GataryLabs.DependencyInjection/blob/main/CustomDITestApp/Program.cs#L45).

```
// class entity manager
[InjectionTarget]
public class EntityManager
{
	[Inject] private EntityConfiguration configuration;
	[Inject(true)] private EntityObjectPool entityObjectPool;
	[Inject] public EntityDatabase Database { get; private set; }
	
	[Inject]
	private void Initialize(WorldContext worldContext)
	{
		// do stuff with injected parameter 'worldContext'
	}
}

// Program.cs
InjectableScope scope = new InjectableScope();

scope.RegisterAsSingleton<WorldContext>();
scope.RegisterAsSingleton<EntityConfiguration>();
scope.RegisterAsSingleton<EntityDatabase>();
scope.RegisterAsSingleton<EntityManager>();

EntityManager entityManager = scope.ResolveInstance<EntityManager>();
```