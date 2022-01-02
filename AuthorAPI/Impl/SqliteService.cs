using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorAPI.Data;
using AuthorAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AuthorAPI.Impl
{
    public class SqliteService
    {

        private DBContext _dbContext = new DBContext();
        
        public SqliteService(DBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public async Task<IList<Author>> GetAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }
        
        public async Task<Author> addAuthor(Author author)
        {
            EntityEntry<Author> newAuthor = await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
            return newAuthor.Entity;
        }
        
        
        public async Task<IList<Book>> GetBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }
        
        public async Task<Book> addBook(Book book)
        {
            EntityEntry<Book> newBook = await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return newBook.Entity;
        }
        
        public async Task RemoveBook(int id)
        {
            Book bookToRemove = await _dbContext.Books.FirstAsync(adult => adult.ISBN == id);
            if (bookToRemove != null)
            {
                _dbContext.Books.Remove(bookToRemove);
                _dbContext.SaveChangesAsync();
            }

        }
        
        
        
        
        
        
        
        
    }
}