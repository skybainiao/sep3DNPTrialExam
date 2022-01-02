

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Data;
using AuthorAPI.Impl;
using AuthorAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private DBContext _dbContext = new DBContext();
        private IList<Author> authors = new List<Author>();
        private IList<Book> books = new List<Book>();
        private SqliteService _service;
        
        public BookController()
        {
            _service = new SqliteService(_dbContext);
        }

        
        [HttpPost]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> AddBook([FromRoute] Book book,int id)
        {
            try
            {
                Book added = new Book()
                {
                    ISBN = book.ISBN,
                    Title = book.Title,
                    PublicationYear = book.PublicationYear,
                    NumOfPages = book.NumOfPages,
                    Genre = book.Genre,
                    Id = id,
                    FirstName = book.FirstName,
                    LastName = book.LastName
                };

                await _service.addBook(added);

                return Created($"https://localhost:5001/Book/{id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetBooks()
        {
            books = await _service.GetBooks();
            try
            {
                IList<Book> _books = books;
                return Ok(_books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> RemoveBook([FromRoute] int id)
        {
            books = await _service.GetBooks();
            try
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Id == id)
                    {
                        _service.RemoveBook(i);
                    }
                }
                _dbContext.SaveChanges();
                Console.WriteLine("did");
                return Accepted($"https://localhost:5001/Book/{id}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        


    }
}