using AuthTesting2.Models.Entities;
using AuthTesting2.Models;
using LibraryAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthTesting2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BooksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //endpoint for get all the book datails
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks = dbContext.Books.ToList();
            return Ok(allBooks);
        }


        //endpoint for get a specific book using id 
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = dbContext.Books.Find(id);

            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        //endpoint for add a new book record 
        [HttpPost]
        public IActionResult AddBook(AddBookDto addBookDto)
        {
            var bookEntity = new Book()
            {
                Title = addBookDto.Title,
                Author = addBookDto.Author,
                Description = addBookDto.Description
            };

            dbContext.Books.Add(bookEntity);
            dbContext.SaveChanges();
            return Ok(bookEntity);
        }

        //endpoint for update a book record
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateBook(Guid id, UpdateBookDto updateBookDto)
        {
            var book = dbContext.Books.Find(id);

            if (book is null)
            {
                return NotFound();
            }

            book.Title = updateBookDto.Title;
            book.Author = updateBookDto.Author;
            book.Description = updateBookDto.Description;

            dbContext.SaveChanges();
            return Ok(book);

        }


        //endpoint for delete a book record
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = dbContext.Books.Find(id);

            if (book is null)
            {
                return NotFound();
            }

            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
