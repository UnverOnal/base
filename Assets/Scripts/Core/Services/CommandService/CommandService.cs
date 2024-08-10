using Services.PoolingService;
using VContainer;

namespace Services.CommandService
{
    public class CommandService : ICommandService
    {
        private readonly ObjectPool<CommandInvoker> _invokerPool;

        [Inject]
        public CommandService(IPoolService poolService)
        {
            _invokerPool = poolService.GetPool(() => new CommandInvoker(), "CommandPool");
        }

        public CommandInvoker GetCommandInvoker()
        {
            return _invokerPool.Get();
        }

        public void ReturnInvoker(CommandInvoker invoker)
        {
            invoker.Reset();
            _invokerPool.Return(invoker);
        }
    }
}