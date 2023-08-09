using ApiPelicula.Models.Dtos;
using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[peliculas]")] //SE PONE LA RUTA POR SI CAMBIA EL NOMBRE DEL CONTROLLER
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //LOS CODIGOS QUE DEVUELVE LA FUNCION
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMovies()
        {

            var movies = _movieRepository.GetMovies();
            var moviesDto = new List<MovieDto>();
            foreach (var list in movies)
            {
                moviesDto.Add(_mapper.Map<MovieDto>(list));
            }
            return Ok(moviesDto);
        }


        [HttpGet("{movieId:int}", Name = "GetMovie")]
        //LOS CODIGOS QUE DEVUELVE LA FUNCION
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMovie(int movieId)
        {

            var itemMovie = _movieRepository.GetMovie(movieId);

            if (itemMovie == null)
            {
                return NotFound();
            }

            var itemMovieDto = _mapper.Map<MovieDto>(itemMovie);
            return Ok(itemMovieDto);
        }
    }
}
