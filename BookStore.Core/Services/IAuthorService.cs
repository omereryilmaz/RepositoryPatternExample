using BookStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task<Author> CreateAuthor(Author newAuthor);
        Task UpdateAuthor(Author authorToBeUpdated, Author author);
        Task DeleteAuthor(Author author);
        Task<IEnumerable<Author>> GetAllWithBooksAsync();
        Task<Author> GetWithBooksByIdAsync(int id);
    }
}
