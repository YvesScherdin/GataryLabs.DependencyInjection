using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    public class StuffToInjectViaMethod
    {
        public SimpleStuffToInjectA StuffA { get; set; }
        public SimpleStuffToInjectB StuffB { get; set; }
        public SimpleStuffToInjectC StuffC { get; set; }
        public SimpleStuffToInjectD StuffD { get; set; }

        [Inject]
        private void InjectStuffA(SimpleStuffToInjectA stuff)
        {
            this.StuffA = stuff;
        }

        [Inject]
        protected void InjectStuffB(SimpleStuffToInjectB stuff)
        {
            this.StuffB = stuff;
        }

        [Inject]
        internal void InjectStuffC(SimpleStuffToInjectC stuff)
        {
            this.StuffC = stuff;
        }

        [Inject]
        public void InjectStuffD(SimpleStuffToInjectD stuff)
        {
            this.StuffD = stuff;
        }
    }

    public interface IMethodCallIndicator
    {
        void CallMethodA();
        void CallMethodB();
        void CallMethodC();
    }
}
