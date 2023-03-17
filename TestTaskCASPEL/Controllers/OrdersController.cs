using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskCASPEL.DTO.Order;
using TestTaskCASPEL.Models;
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
            
            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(ordersDTO);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByID(int id)
        {
            var orders = await _orderRepository.GetOdersByNumber(id);

            if (orders == null)
            {
                return NoContent();
            }

            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(ordersDTO);
        }

        [HttpGet("{date:Datetime}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByDate(DateTime date)
        {
            var orders = await _orderRepository.GetOrdersByDate(date);
            if (orders == null)
            {
                return NoContent();
            }

            var ordersDTO = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateOrder([FromBody] int[] booksIds)
        {
            var order = await _orderRepository.CreateOrderByBooksId(booksIds);
            var response = _mapper.Map<OrderDTO>(order);
            return CreatedAtAction("GetOrdersById", new { id = response.ID }, response);
        }
    }
}
