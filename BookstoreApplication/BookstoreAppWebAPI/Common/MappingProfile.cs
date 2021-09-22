using AutoMapper;
using BookstoreAppWebAPI.BookOperations.Create;
using BookstoreAppWebAPI.BookOperations.Delete;
using BookstoreAppWebAPI.BookOperations.Update;
using BookstoreAppWebAPI.Entities;

namespace BookstoreAppWebAPI.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<UpdateBookViewModel, Book>();
            CreateMap<DeleteBookViewModel, Book>();
            
        }
        
    }
}