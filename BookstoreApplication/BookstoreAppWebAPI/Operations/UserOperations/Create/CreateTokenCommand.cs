using System;
using System.Linq;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.TokenOperations;
using Microsoft.Extensions.Configuration;

namespace BookstoreAppWebAPI.Operations.UserOperations.Create
{
    public class CreateTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenViewModel Model { get; set; }
        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token CreateToken()
        {
            User searchedUser = _context.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (searchedUser == null)
                throw new InvalidOperationException("Böyle bir kullanıcı yok");

            if (searchedUser.Password != Model.Password)
            {
                throw new InvalidOperationException("Email veya şifreniz yanlış");
            }

            TokenHandler handler = new TokenHandler(_configuration);

            Token token = handler.CreateAccessToken(searchedUser);

            searchedUser.RefreshToken = token.RefreshToken;
            searchedUser.RefreshTokenExpirationDate = token.ExpirationDate.AddMinutes(5);

            _context.SaveChanges();

            return token;

        }

    }

    public class CreateTokenViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
