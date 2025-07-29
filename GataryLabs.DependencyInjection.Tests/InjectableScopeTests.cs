using GataryLabs.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestGame.Entities.Behaviours;
using TestGame.Simple;
using TestGame.World;

namespace GataryLabs.DependencyInjection.Tests
{
    [TestClass]
    public class InjectableScopeTests
    {
        [TestMethod]
        public void InjectionFlagsAll_Working()
        {
            InjectableScope scope = PrepareScopeForFlagTests();

            ClassWithInjectableMembers injectionTarget = scope.ResolveInstance<ClassWithInjectionFlagsAll>();
            
            Assert.IsNotNull(injectionTarget.FieldInjectedDirectly);
            Assert.IsNotNull(injectionTarget.PropertyInjectedDirectly);
            Assert.IsNotNull(injectionTarget.PropertyInjectedByMethod);
            Assert.IsNotNull(injectionTarget.PropertyInjectedByConstructor);
        }
        
        [TestMethod]
        public void InjectionFlagsConstructors_Working()
        {
            InjectableScope scope = PrepareScopeForFlagTests();

            ClassWithInjectableMembers injectionTarget = scope.ResolveInstance<ClassWithInjectionFlagsConstructors>();
            
            Assert.IsNull(injectionTarget.FieldInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedByMethod);
            Assert.IsNotNull(injectionTarget.PropertyInjectedByConstructor);
        }
        
        [TestMethod]
        public void InjectionFlagsMethods_Working()
        {
            InjectableScope scope = PrepareScopeForFlagTests();

            ClassWithInjectableMembers injectionTarget = scope.ResolveInstance<ClassWithInjectionFlagsMethods>();
            
            Assert.IsNull(injectionTarget.FieldInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedDirectly);
            Assert.IsNotNull(injectionTarget.PropertyInjectedByMethod);
            Assert.IsNull(injectionTarget.PropertyInjectedByConstructor);
        }

        [TestMethod]
        public void InjectionFlagsProperties_Working()
        {
            InjectableScope scope = PrepareScopeForFlagTests();

            ClassWithInjectableMembers injectionTarget = scope.ResolveInstance<ClassWithInjectionFlagsProperties>();
            
            Assert.IsNull(injectionTarget.FieldInjectedDirectly);
            Assert.IsNotNull(injectionTarget.PropertyInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedByMethod);
            Assert.IsNull(injectionTarget.PropertyInjectedByConstructor);
        }
        
        [TestMethod]
        public void InjectionFlagsFields_Working()
        {
            InjectableScope scope = PrepareScopeForFlagTests();

            ClassWithInjectableMembers injectionTarget = scope.ResolveInstance<ClassWithInjectionFlagsFields>();
            
            Assert.IsNotNull(injectionTarget.FieldInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedDirectly);
            Assert.IsNull(injectionTarget.PropertyInjectedByMethod);
            Assert.IsNull(injectionTarget.PropertyInjectedByConstructor);
        }

        private InjectableScope PrepareScopeForFlagTests()
        {
            InjectableScope scope = new InjectableScope();

            scope.RegisterAsTransient<SimpleStuffToInjectA>();
            scope.RegisterAsTransient<SimpleStuffToInjectB>();
            scope.RegisterAsTransient<SimpleStuffToInjectC>();
            scope.RegisterAsTransient<SimpleStuffToInjectD>();
            scope.RegisterAsTransient<ClassWithInjectionFlagsAll>();
            scope.RegisterAsTransient<ClassWithInjectionFlagsConstructors>();
            scope.RegisterAsTransient<ClassWithInjectionFlagsFields>();
            scope.RegisterAsTransient<ClassWithInjectionFlagsMethods>();
            scope.RegisterAsTransient<ClassWithInjectionFlagsProperties>();

            return scope;
        }

        
        [TestMethod]
        public void InjectInto_DefaultScenario_Works()
        {
            InjectableScope scope = new InjectableScope();
            FactionController factionController = new FactionController();
            scope.RegisterAsScoped<FactionController>(factionController);
            FactionOwner factionOwner = new FactionOwner();

            scope.InjectInto(factionOwner);

            Assert.AreEqual(factionController, factionOwner.factionController);
        }
        
        [TestMethod]
        public void InjectSelf_InjectionTargetRegisteredAsScoped_Works()
        {
            InjectableScope scope = new InjectableScope();
            scope.RegisterAsScoped<ScopeInjectReceiver>();
            ScopeInjectReceiver result = scope.ResolveInstance<ScopeInjectReceiver>();

            Assert.IsNotNull(result.Scope);
            Assert.AreEqual(scope, result.Scope);
        }

        [TestMethod]
        public void InjectSelf_InjectionTargetRegisteredAsTransient_Works()
        {
            InjectableScope scope = new InjectableScope();
            scope.RegisterAsTransient<ScopeInjectReceiver>();
            ScopeInjectReceiver result = scope.ResolveInstance<ScopeInjectReceiver>();

            Assert.IsNotNull(result.Scope);
            Assert.AreEqual(scope, result.Scope);
        }

        [TestMethod]
        public void InjectSelf_InjectionTargetRegisteredAsSingleton_Works()
        {
            InjectableScope scope = new InjectableScope();
            scope.RegisterAsSingleton<ScopeInjectReceiver>();
            ScopeInjectReceiver result = scope.ResolveInstance<ScopeInjectReceiver>();

            Assert.IsNotNull(result.Scope);
            Assert.AreEqual(scope, result.Scope);
        }
    }
}
