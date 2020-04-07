using Microsoft.AspNetCore.Mvc;
using REST.Dto;
using System.Collections.Generic;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks(string title = null, string author = null)
        {
            List<BookDto> books = BookRepository.FindBooks(title, author);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook([FromForm]BookDto book)
        {
            var created = BookRepository.CreateBook(book.Title, book.Author);
            if (created == null)
            {
                return NotFound();
            }
            return Ok(created);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var deleted = BookRepository.DeleteBook(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromForm]BookDto book)
        {
            var updated = BookRepository.UpdateBook(id, book.Title, book.Author);
            if (updated == null)
            {
                return NotFound();
            }
            return Ok(updated);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            BookDto book = BookRepository.FindBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}