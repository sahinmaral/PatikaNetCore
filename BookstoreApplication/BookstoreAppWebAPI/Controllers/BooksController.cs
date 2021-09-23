using System;
using System.Linq;

using AutoMapper;

using BookstoreAppWebAPI.BookOperations.Create;
using BookstoreAppWebAPI.BookOperations.Delete;
using BookstoreAppWebAPI.BookOperations.Read;
using BookstoreAppWebAPI.BookOperations.Update;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;

using FluentValidation;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var commands = new ReadCommands(_context);

            return Ok(commands.GetBooksWithDetails());
        }


        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            var commands = new ReadCommands(_context);
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

            CreateCommands commands = new CreateCommands(_context, _mapper);
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

            var commands = new UpdateCommands(_context);

            commands.Model = viewModel;

            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.UpdateBook();


            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var commands = new DeleteCommands(_context);
            commands.Model = new DeleteBookViewModel
            {
                Id = id
            };

            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.DeleteBook();

            return Ok();
        }
    }
}