
using GetFood.Application.Services;
using GetFood.Models;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Net;

namespace GetFood.Api.Controllers
{
    [ApiController]
    [Route("api/v1/page-initial")]
    public class PageInitialController : ControllerBase
    {
        private readonly ILogger<PageInitialController> _logger;
        private readonly IPageInitialService _pageInitialService;

        public PageInitialController(IPageInitialService pageInitialService, ILogger<PageInitialController> logger)
        {
            _pageInitialService = pageInitialService;
            _logger = logger;
        }

        [HttpGet("categories")]
        [ProducesResponseType(typeof(CustomResult<PageResult<CategoryOutputModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CustomResult<PageResult<CategoryOutputModel>>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAsync(int size = 10, int index = 0)
        {
            _logger.LogInformation("Geting categories - {size}, {index}", size, index);

            return Ok(await _pageInitialService.GetCategories(size, index));
        }
    }



    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost:7000");
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
