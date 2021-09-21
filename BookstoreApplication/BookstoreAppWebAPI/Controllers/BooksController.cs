

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using BookstoreAppWebAPI.BookOperations.Create;
using BookstoreAppWebAPI.BookOperations.Delete;
using BookstoreAppWebAPI.BookOperations.Read;
using BookstoreAppWebAPI.BookOperations.Update;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Entities;


namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookStoreDbContext _context;
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ReadCommands commands = new ReadCommands(_context);

            return Ok(commands.GetBooks());
        }
        

        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute]int id)
        {
            ReadCommands commands = new ReadCommands(_context);
            commands.Model = new ReadBookViewModel()
            {
                Id = id
            };

            return Ok(commands.GetBookByBookId());
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] CreateBookViewModel newBook)
        {
            try
            {
                CreateCommands commands = new CreateCommands(_context);
                commands.Model = newBook;

                commands.AddBook();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCommands.UpdateBookViewModel viewModel)
        {
            try
            {
                UpdateCommands commands = new UpdateCommands(_context);

                commands.Model = viewModel;
                commands.UpdateBook();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }  

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                DeleteCommands commands = new DeleteCommands(_context);
                commands.Model = new DeleteBookViewModel()
                {
                    Id = id
                };

                commands.DeleteBook();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


    }


}
