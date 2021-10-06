using System;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAppWebAPI.Operations.UserOperations.Create
{
    public class CreateUserCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateUserViewModel Model { get; set; }
        public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateUser()
        {
            User searchedUser = _context.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (searchedUser != null)
                throw new InvalidOperationException("Kullanıcı zaten mevcut");

            searchedUser = _mapper.Map<User>(Model);

            _context.Users.Add(searchedUser);

            _context.SaveChanges();
        }

    }

    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDate { get; set; }
    }
}
