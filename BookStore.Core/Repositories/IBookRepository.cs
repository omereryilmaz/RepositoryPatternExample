using BookStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();
        Task<Book> GetWithAuthorByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId);
    }
}
