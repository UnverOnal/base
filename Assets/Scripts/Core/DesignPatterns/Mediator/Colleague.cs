using VContainer;

namespace Core.DesignPatterns.Mediator
{
    public class Colleague
    {
        protected SthMediator sthMediator;

        public void SetMediator(SthMediator mediator) => sthMediator = mediator;
    }
}
