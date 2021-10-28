using BookStore.Core.Models;
using BookStore.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreDbContext context) : base(context)
        {}

        private BookStoreDbContext BookStoreDbContext
        {
            get { return context as BookStoreDbContext; }
        }

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await BookStoreDbContext.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author> GetWithBooksByIdAsync(int id)
        {
            return await BookStoreDbContext.Authors
                .Include(a => a.Books)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
