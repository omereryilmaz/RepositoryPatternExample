using BookStore.Core;
using BookStore.Core.Models;
using BookStore.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Book> CreateBook(Book newBook)
        {
            newBook.CreateAt = System.DateTime.Now;
            await unitOfWork.Books.AddAsync(newBook);
            await unitOfWork.CommitAsync();
            return newBook;
        }

        public async Task DeleteBook(Book book)
        {
            unitOfWork.Books.Remove(book);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await unitOfWork.Books.GetAllAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync()
        {
            return await unitOfWork.Books.GetAllWithAuthorAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId)
        {
            return await unitOfWork.Books.GetAllWithAuthorByAuthorIdAsync(authorId);
        }

        public async Task<Book> GetBookById(int id)
        {
            return await unitOfWork.Books.GetByIdAsync(id);
        }

        public async Task<Book> GetWithAuthorByIdAsync(int id)
        {
            return await unitOfWork.Books.GetWithAuthorByIdAsync(id);
        }

        public async Task UpdateABook(Book bookToBeUpdated, Book book)
        {
            bookToBeUpdated.Title = book.Title;
            bookToBeUpdated.AuthorId = book.AuthorId;
            await unitOfWork.CommitAsync();
        }
    }
}
