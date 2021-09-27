using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Operations.BookOperations.Create;
using BookstoreAppWebAPI.Operations.BookOperations.Delete;
using BookstoreAppWebAPI.Operations.BookOperations.Read;
using BookstoreAppWebAPI.Operations.BookOperations.Update;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UpdateBookValidator = BookstoreAppWebAPI.Operations.BookOperations.Update.UpdateBookValidator;

namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ReadBookCommands commands = new ReadBookCommands(_context);

            return Ok(commands.GetBooksWithDetails());
        }


        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            ReadBookCommands commands = new ReadBookCommands(_context);
            commands.Model = new ReadBookViewModel
            {
                Id = id
            };

            ReadBookValidator validator = new ReadBookValidator();
            validator.ValidateAndThrow(commands.Model);

            return Ok(commands.GetBookWithDetailsByBookId());
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] CreateBookViewModel newBook)
        {

            CreateBookCommands commands = new CreateBookCommands(_context, _mapper);
            commands.Model = newBook;

            CreateBookValidator validator = new CreateBookValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.AddBook();


            return Ok();
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateBookViewModel viewModel)
        {

            UpdateBookCommands commands = new UpdateBookCommands(_context)
            {
                Model = viewModel
            };

            UpdateBookValidator validator = new UpdateBookValidator();
            
            validator.ValidateAndThrow(commands.Model);
            
            
            commands.UpdateBook();


            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            DeleteBookCommands commands = new DeleteBookCommands(_context)
            {
                Model = new DeleteBookViewModel
                {
                    Id = id
                }
            };

            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.DeleteBook();

            return Ok();
        }
    }
}