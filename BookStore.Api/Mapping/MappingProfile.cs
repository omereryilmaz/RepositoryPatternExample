using AutoMapper;
using BookStore.Api.DTO;
using BookStore.Core.Models;

namespace BookStore.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();

            // Resource to Domain
            CreateMap<BookDTO, Book>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<SaveBookDTO, Book>();
            CreateMap<SaveBookDTO, Author>();
        }
    }
}
