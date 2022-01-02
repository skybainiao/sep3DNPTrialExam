using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Data;
using AuthorAPI.Impl;
using AuthorAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        
        private DBContext _dbContext = new DBContext();
        private IList<Author> authors = new List<Author>();
        private IList<Book> books = new List<Book>();
        private SqliteService _service;
        
        public AuthorController()
        {
            _service = new SqliteService(_dbContext);
        }
        
        
        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            try
            {
                Author added = await _service.addAuthor(author);

                return Created("https://localhost:5001/Author", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthors()
        {
            authors = await _service.GetAuthors();
            try
            {
                IList<Author> _authors = authors;
                return Ok(_authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        
    }
}