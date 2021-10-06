using AutoMapper;

using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookstoreAppWebAPI.Operations.WriterOperations.Create;
using BookstoreAppWebAPI.Operations.WriterOperations.Delete;
using BookstoreAppWebAPI.Operations.WriterOperations.Read;
using BookstoreAppWebAPI.Operations.WriterOperations.Update;

using FluentValidation;

using Microsoft.AspNetCore.Mvc;

namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public WritersController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var commands = new ReadWriterCommands(_context,_mapper);

            return Ok(commands.GetAllClearly());
        }


        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            ReadWriterCommands commands = new ReadWriterCommands(_context, _mapper)
            {
                Model = new ReadWriterViewModel() {Id = id}
            };

            ReadWriterValidator validator = new ReadWriterValidator();
            validator.ValidateAndThrow(commands.Model);

            return Ok(commands.GetWriterById());
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] CreateWriterViewModel newWriter)
        {

            CreateWriterCommands commands = new CreateWriterCommands(_context,_mapper) {Model = newWriter};

            CreateWriterValidator validator = new CreateWriterValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.AddWriter();


            return Ok();
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateWriterViewModel viewModel)
        {

            UpdateWriterCommands commands = new UpdateWriterCommands(_context) {Model = viewModel};


            UpdateWriterValidator validator = new UpdateWriterValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.UpdateWriter();


            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            DeleteWriterCommands commands = new DeleteWriterCommands(_context)
            {
                Model = new DeleteWriterViewModel() {Id = id}
            };

            DeleteWriterValidator validator = new DeleteWriterValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.DeleteBook();

            return Ok();
        }
    }
}
