using ETrade.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ETrade.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ETrade.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly RemoveOrderDetailHandler _removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailHandler _updateOrderDetailCommandHandler;

        public OrderDetailsController(CreateOrderDetailCommandHandler createOrderDetailCommandHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, RemoveOrderDetailHandler removeOrderDetailCommandHandler, UpdateOrderDetailHandler updateOrderDetailCommandHandler)
        {
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handler(new GetOrderDetailByIdQueries(id));
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handler();
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handler(new RemoveOrderDetailCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handler(command);
            return Ok();
        }
    }
}
