using AutoMapper;

using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;
using BookstoreAppWebAPI.Operations.UserOperations.Create;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UsersController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("createuser")]
        public IActionResult CreateUser([FromBody] CreateUserViewModel viewModel)
        {
            CreateUserCommand command = new CreateUserCommand(_context, _mapper) {Model = viewModel};
            command.CreateUser();

            return Ok();
        }

        //[HttpPost]
        //[Route("createtoken")]
        //public ActionResult<Token> CreateToken([FromBody] CreateTokenViewModel viewModel)
        //{
        //    CreateTokenCommand command = new CreateTokenCommand(_context, _mapper,_configuration) {Model = viewModel};

        //    var token = command.CreateToken();

        //    return token;
        //}

        [HttpPost]
        [Route("createtoken")]
        public IActionResult CreateToken([FromBody] CreateTokenViewModel viewModel)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration) { Model = viewModel };

            var token = command.CreateToken();

            return Ok(token);
        }
    }
}
