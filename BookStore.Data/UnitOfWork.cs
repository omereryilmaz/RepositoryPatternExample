using BookStore.Core;
using BookStore.Core.Repositories;
using BookStore.Data.Repositories;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreDbContext context;

        public UnitOfWork(BookStoreDbContext context)
        {
            this.context = context;
        }

        private AuthorRepository authorRepository;
        private BookRepository bookRepository;

        public IAuthorRepository Authors => authorRepository ?? new AuthorRepository(context);

        public IBookRepository Books => bookRepository ?? new BookRepository(context);


        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
