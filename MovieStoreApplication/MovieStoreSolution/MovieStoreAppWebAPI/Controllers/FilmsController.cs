using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreAppWebAPI.Operations.DatabaseOperation;
using MovieStoreAppWebAPI.Operations.FilmOperation.Create;
using MovieStoreAppWebAPI.Operations.FilmOperation.Read;

namespace MovieStoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public FilmsController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            ReadFilmCommand command = new ReadFilmCommand(_context,_mapper);

            return Ok(command.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody]CreateFilmViewModel viewModel)
        {
            CreateFilmCommand command = new CreateFilmCommand(_context, _mapper)
            {
                Model = viewModel
            };

            command.Add();

            return Ok();
        }

    }
}
