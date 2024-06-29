using FoodManager.Core.Mediator.Results;
using MediatR;

namespace FoodManager.Core.Mediator.Messages
{
    public class Command : IRequest<CustomResult>
    { }
}
