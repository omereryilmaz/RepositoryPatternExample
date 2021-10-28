using BookStore.Core.Models;
using BookStore.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {}

        private  BookStoreDbContext BookStoreDbContext 
        {
            get { return context as BookStoreDbContext; }
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync()
        {
            return await BookStoreDbContext.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId)
        {
            return await BookStoreDbContext.Books
                .Include(b => b.Author)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Book> GetWithAuthorByIdAsync(int id)
        {
            return await BookStoreDbContext.Books
                .Include(b => b.Author)
                .SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}
