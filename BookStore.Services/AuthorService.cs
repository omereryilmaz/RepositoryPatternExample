using BookStore.Core;
using BookStore.Core.Models;
using BookStore.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Author> CreateAuthor(Author newAuthor)
        {
            await unitOfWork.Authors.AddAsync(newAuthor);
            await unitOfWork.CommitAsync();
            return newAuthor;
        }

        public async Task DeleteAuthor(Author author)
        {
            unitOfWork.Authors.Remove(author);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await unitOfWork.Authors.GetAllAsync();
        }

        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await unitOfWork.Authors.GetAllWithBooksAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task<Author> GetWithBooksByIdAsync(int id)
        {
            return await unitOfWork.Authors.GetWithBooksByIdAsync(id);
        }

        public async Task UpdateAuthor(Author authorToBeUpdated, Author author)
        {
            authorToBeUpdated.Name = author.Name;
            await unitOfWork.CommitAsync();
        }
    }
}
