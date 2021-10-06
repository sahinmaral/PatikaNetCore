using AutoMapper;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using BookstoreAppWebAPI.Operations.BookOperations.Delete;
using BookstoreAppWebAPI.Operations.BookOperations.Update;
using BookstoreAppWebAPI.Operations.UserOperations.Create;

namespace BookstoreAppWebAPI.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<UpdateBookViewModel, Book>();
            CreateMap<DeleteBookViewModel, Book>();

            CreateMap<CreateUserViewModel, User>();

        }

    }
}