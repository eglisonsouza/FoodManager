using FoodManager.Core.Mediator.Handler;
using FoodManager.Core.Mediator.Results;
using Microsoft.AspNetCore.Mvc;
using RestaurantsFoods.Application.Commands;
using RestaurantsFoods.Application.Queries.CategoryQuery.Queries;
using System.Net;

namespace RestaurantsFoods.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IMediatorHandler _mediator;

        public CategoryController(ILogger<CategoryController> logger, IMediatorHandler mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> PostAsync(CreateCategoryCommand command)
        {
            _logger.LogInformation("Creating a new category: {@command}", command);

            var result = await _mediator.SendCommand(command);

            if (!result.IsSuccess)
            {
                _logger.LogInformation("Error creating category: {@command} - {@result}", command, result);
                return BadRequest(result);
            }

            _logger.LogInformation("Category created: {@command} - {@result}", command, result);

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync(int size = 10, int index = 0)
        {
            _logger.LogInformation("Geting categories - {size}, {index}", size, index);

            var result = await _mediator.SendCommand(new GetAllCategoryQuery(size, index));

            return Ok(result);
        }
    }
}
