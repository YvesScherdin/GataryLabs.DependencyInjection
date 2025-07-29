using GataryLabs.DependencyInjection.Attributes;

namespace TestGame.Simple
{
    [InjectionTarget]
    public class LetsInjectThroughMethodStuff
    {
        public SimpleStuffToInjectA Stuff { get; private set; }

        [Inject]
        private void InjectStuff(SimpleStuffToInjectA stuff)
        {
            this.Stuff = stuff;
        }
    }

    [InjectionTarget]
    public class LetsInjectThroughMethodStuffSpecific : LetsInjectThroughMethodStuffBase
    {
    }

    public class LetsInjectThroughMethodStuffBase
    {
        public SimpleStuffToInjectA Stuff { get; private set; }

        [Inject]
        private void InjectStuff(SimpleStuffToInjectA stuff)
        {
            this.Stuff = stuff;
        }
    }
}
