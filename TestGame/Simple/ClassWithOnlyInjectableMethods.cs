using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    [InjectionTarget]
    public class ClassWithOnlyInjectableMethods : ClassWithInjectableMembers
    {

    }

    public class ClassWithInjectableMembers
    {
        [Inject] private SimpleStuffToInjectA FieldA;
        [Inject] private SimpleStuffToInjectB FieldB;
        [Inject] private SimpleStuffToInjectC FieldC;

        [Inject] private SimpleStuffToInjectA PropertyA { get; set; }
        [Inject] private SimpleStuffToInjectB PropertyB { get; set; }
        [Inject] private SimpleStuffToInjectC PropertyC { get; set; }

        [Inject]
        private void MethodA(SimpleStuffToInjectA stuff)
        {
        }

        [Inject]
        private void MethodB(SimpleStuffToInjectB stuff)
        {
        }

        [Inject]
        private void MethodC(SimpleStuffToInjectC stuff)
        {
        }
    }
}
