using GataryLabs.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestGame.Simple;

namespace GataryLabs.DependencyInjection.Tests
{
    [TestClass]
    public class InjectableScopeTests
    {
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
