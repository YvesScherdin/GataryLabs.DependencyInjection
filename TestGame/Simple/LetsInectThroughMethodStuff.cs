using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    [InjectionTarget]
    public class LetsInectThroughMethodStuff
    {
        public SimpleStuffToInjectA Stuff { get; private set; }

        [Inject]
        private void InjectStuff(SimpleStuffToInjectA stuff)
        {
            this.Stuff = stuff;
        }
    }

    [InjectionTarget]
    public class LetsInectThroughMethodStuffSpecific : LetsInectThroughMethodStuffBase
    {
    }

    public class LetsInectThroughMethodStuffBase
    {
        public SimpleStuffToInjectA Stuff { get; private set; }

        [Inject]
        private void InjectStuff(SimpleStuffToInjectA stuff)
        {
            this.Stuff = stuff;
        }
    }
}
