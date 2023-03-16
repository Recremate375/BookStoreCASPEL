using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskCASPEL.DTO.Book;
using TestTaskCASPEL.Models;
using TestTaskCASPEL.Repository.IRepository;

namespace TestTaskCASPEL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper)
        {
            _bookRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAll();
            if (books == null)
            {
                return NoContent();
            }
            var booksDTO = _mapper.Map<List<BookDTO>>(books);

            return Ok(booksDTO);
        }

        [HttpGet]
        [Route("BooksByName")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksByName([FromQuery]string name)
        {
            var books = await _bookRepository.GetBooksByName(name);
            if (books == null)
            {
                return NoContent();
            }

            var booksDTO = _mapper.Map<List<BookDTO>>(books);

            return Ok(booksDTO);
        }

        [HttpGet("{date:DateTime}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooksByDate(DateTime date)
        {
            var books = await _bookRepository.GetBooksByDate(date);
            if (books == null)
            {
                return NoContent();
            }

            var booksDTO = _mapper.Map<List<BookDTO>>(books);

            return Ok(booksDTO);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDTO>> GetBookByID(int id)
        {
            var book = await _bookRepository.GetByID(id);
            var bookDTO = _mapper.Map<BookDTO>(book);
            if (book == null)
            {
                return NoContent();
            }

            return Ok(bookDTO);
        }
    }
}
