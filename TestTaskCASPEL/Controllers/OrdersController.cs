using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskCASPEL.DTO.Order;
using TestTaskCASPEL.Repository.IRepository;

namespace TestTaskCASPEL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            if (orders == null)
            {
                return NoContent();
            }

            var ordersDTO = _mapper.Map<OrderDTO>(orders);

            return Ok(ordersDTO);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByID(int id)
        {
            var orders = _orderRepository.GetOdersByNumber(id);

            if (orders == null)
            {
                return NoContent();
            }

            var ordersDTO = _mapper.Map<OrderDTO>(orders);

            return Ok(ordersDTO);
        }
    }
}
