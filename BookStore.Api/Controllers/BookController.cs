using AutoMapper;
using BookStore.Api.DTO;
using BookStore.Api.Validators;
using BookStore.Core.Models;
using BookStore.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IAuthorService authorService, IMapper mapper)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get all Books with Author
        /// </summary>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="400">If the item is null</response> 
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooks()
        {
            var books = await bookService.GetAllWithAuthorAsync();
            var bookResources = mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);

            return Ok(bookResources);
        }

        /// <summary>
        /// Get Book with Author by BookId
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <response code="400">If there is no book.</response>
        [HttpGet("id")]
        public async Task<ActionResult<BookDTO>> GetBookById(int id)
        {
            var book = await bookService.GetWithAuthorByIdAsync(id);
            var bookResource = mapper.Map<Book, BookDTO>(book);

            return Ok(bookResource);
        }

        /// <summary>
        /// Create a Book
        /// </summary>
        /// <response code="400">If there is no Author.</response>
        [HttpPost("")]
        public async Task<ActionResult<BookDTO>> CreateBook([FromBody] SaveBookDTO saveBookResource)
        {
            var validator = new SaveBookResourceValidator();
            var validatorResult = await validator.ValidateAsync(saveBookResource);

            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            var author = await authorService.GetAuthorById(saveBookResource.AuthorId);

            if (author == null)
            {
                return BadRequest("Author not found!");
            }

            var bookToCreate = mapper.Map<SaveBookDTO, Book>(saveBookResource);
            var newBook = await bookService.CreateBook(bookToCreate);

            var book = await bookService.GetWithAuthorByIdAsync(newBook.Id);
            var bookResource = mapper.Map<Book, BookDTO>(book);

            return Ok(bookResource);
        }
    }
}
