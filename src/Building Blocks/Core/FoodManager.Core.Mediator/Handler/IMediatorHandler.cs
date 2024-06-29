using FoodManager.Core.Mediator.Messages;
using FoodManager.Core.Mediator.Results;

namespace FoodManager.Core.Mediator.Handler
{
    public interface IMediatorHandler
    {
        Task<CustomResult> SendCommand<T>(T command) where T : Command;
        //Task Publish<T>(T @event) where T : Event;
    }
}
