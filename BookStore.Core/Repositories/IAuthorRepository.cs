using BookStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        Task<Author> GetWithBooksByIdAsync(int id);
    }
}
