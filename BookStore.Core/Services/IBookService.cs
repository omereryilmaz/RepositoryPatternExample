using BookStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> CreateBook(Book newBook);
        Task UpdateABook(Book bookToBeUpdated, Book book);
        Task DeleteBook(Book book);
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();
        Task<Book> GetWithAuthorByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId);
    }
}
