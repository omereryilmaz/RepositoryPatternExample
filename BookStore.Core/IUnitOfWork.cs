using BookStore.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace BookStore.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        Task<int> CommitAsync();
    }
}
