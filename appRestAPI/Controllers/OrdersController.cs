using appRestAPI.Contracts.Orders;
using appRestAPI.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace appRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(
            ILogger<OrdersController> logger,
            IMediator mediator,
            IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAsync([FromQuery] GetOrdersQuery query, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Getting orders with parameters: {orderParameters}", query);

            var result = await _mediator.Send(query, cancellationToken);
            if (!result.IsQueryValid)
                return BadRequest(result.InvalidityReason);

            _logger.LogInformation("Succesfully got orders {numberOfOrders}", result.Orders.Count());
            return Ok(result);
        }
    }
}