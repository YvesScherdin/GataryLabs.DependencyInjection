using GataryLabs.DependencyInjection;
using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    [InjectionTarget(InjectionFlags.All)]
    public class ClassWithInjectionFlagsAll : ClassWithInjectableMembers
    {
        [Inject]
        public ClassWithInjectionFlagsAll(SimpleStuffToInjectD stuff)
        {
            this.PropertyInjectedByConstructor = stuff;
        }

        public ClassWithInjectionFlagsAll()
        {
        }

        [Inject]
        private void MethodToInjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.PropertyInjectedByMethod = stuff;
        }
    }
    
    [InjectionTarget(InjectionFlags.Methods)]
    public class ClassWithInjectionFlagsMethods : ClassWithInjectableMembers
    {
        [Inject]
        public ClassWithInjectionFlagsMethods(SimpleStuffToInjectD stuff)
        {
            this.PropertyInjectedByConstructor = stuff;
        }

        public ClassWithInjectionFlagsMethods()
        {
        }

        [Inject]
        private void MethodToInjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.PropertyInjectedByMethod = stuff;
        }
    }
    
    [InjectionTarget(InjectionFlags.Fields)]
    public class ClassWithInjectionFlagsFields : ClassWithInjectableMembers
    {
        [Inject]
        public ClassWithInjectionFlagsFields(SimpleStuffToInjectD stuff)
        {
            this.PropertyInjectedByConstructor = stuff;
        }

        public ClassWithInjectionFlagsFields()
        {
        }

        [Inject]
        private void MethodToInjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.PropertyInjectedByMethod = stuff;
        }
    }
    
    [InjectionTarget(InjectionFlags.Properties)]
    public class ClassWithInjectionFlagsProperties : ClassWithInjectableMembers
    {
        [Inject]
        public ClassWithInjectionFlagsProperties(SimpleStuffToInjectD stuff)
        {
            this.PropertyInjectedByConstructor = stuff;
        }
        
        public ClassWithInjectionFlagsProperties()
        {
        }

        [Inject]
        private void MethodToInjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.PropertyInjectedByMethod = stuff;
        }
    }
    
    [InjectionTarget(InjectionFlags.Constructors)]
    public class ClassWithInjectionFlagsConstructors : ClassWithInjectableMembers
    {
        [Inject]
        public ClassWithInjectionFlagsConstructors(SimpleStuffToInjectD stuff)
        {
            this.PropertyInjectedByConstructor = stuff;
        }
        
        public ClassWithInjectionFlagsConstructors()
        {
        }

        [Inject]
        private void MethodToInjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.PropertyInjectedByMethod = stuff;
        }
    }

    public class ClassWithInjectableMembers
    {
        [Inject] public SimpleStuffToInjectA FieldInjectedDirectly;

        [Inject] public SimpleStuffToInjectB PropertyInjectedDirectly { get; set; }

        public SimpleStuffToInjectC PropertyInjectedByMethod { get; protected set; }

        public SimpleStuffToInjectD PropertyInjectedByConstructor { get; protected set; }

        public ClassWithInjectableMembers()
        {
        }
    }
}
