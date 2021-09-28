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
            ReadBookCommand commands = new ReadBookCommand(_context,_mapper);

            return Ok(commands.GetBooksWithDetails());
        }


        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            ReadBookCommand commands = new ReadBookCommand(_context,_mapper);
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

            CreateBookCommand commands = new CreateBookCommand(_context, _mapper);
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

            UpdateBookCommand commands = new UpdateBookCommand(_context)
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

            DeleteBookCommand commands = new DeleteBookCommand(_context)
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