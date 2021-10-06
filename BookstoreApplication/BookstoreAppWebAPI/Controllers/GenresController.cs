using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BookstoreAppWebAPI.DbOperations;
using BookstoreAppWebAPI.Operations.DbOperations;
using BookstoreAppWebAPI.Operations.GenreOperations.Create;
using BookstoreAppWebAPI.Operations.GenreOperations.Delete;
using BookstoreAppWebAPI.Operations.GenreOperations.Read;
using BookstoreAppWebAPI.Operations.GenreOperations.Update;
using FluentValidation;

namespace BookstoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var commands = new ReadGenreCommand(_context,_mapper);

            return Ok(commands.GetAllClearly());
        }


        [Route("getById/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            ReadGenreCommand commands = new ReadGenreCommand(_context, _mapper)
            {
                Model = new ReadGenreViewModel() {Id = id}
            };

            ReadGenreValidator validator = new ReadGenreValidator();
            validator.ValidateAndThrow(commands.Model);

            return Ok(commands.GetGenreById());
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreViewModel newGenre)
        {

            CreateGenreCommand commands = new CreateGenreCommand(_context) {Model = newGenre};

            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.AddGenre();


            return Ok();
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateGenreViewModel viewModel)
        {

            UpdateGenreCommand commands = new UpdateGenreCommand(_context);

            commands.Model = viewModel;

            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.UpdateGenre();


            return Ok();
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            DeleteGenreCommand commands = new DeleteGenreCommand(_context);
            commands.Model = new DeleteGenreViewModel()
            {
                Id = id
            };

            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(commands.Model);

            commands.DeleteBook();

            return Ok();
        }
    }
}
