using Microsoft.AspNetCore.Mvc;
using REST.Domain.Book;
using REST.Application.Dto;
using System.Collections.Generic;
using System.Linq;

namespace REST.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks(string title = null, string author = null)
        {
            List<BookDto> books = _bookRepository
                .Find(title, author)
                .Select(x => new BookDto {
                    Id = x.Id,
                    Author = x.Author,
                    Title = x.Title
                })
                .ToList();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook([FromForm]BookDto book)
        {
            _bookRepository.Create(new Book(book.Title, book.Author));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromForm]BookDto book)
        {
            _bookRepository.Update(id, book.Title, book.Author);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            Book book = _bookRepository.GetById(id);
            return Ok(new BookDto { 
                Id = book.Id,
                Author = book.Author,
                Title = book.Title
            });
        }
    }
}