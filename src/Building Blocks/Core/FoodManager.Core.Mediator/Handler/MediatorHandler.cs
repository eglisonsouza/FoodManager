using FoodManager.Core.Mediator.Messages;
using FoodManager.Core.Mediator.Results;
using MediatR;

namespace FoodManager.Core.Mediator.Handler
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CustomResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
