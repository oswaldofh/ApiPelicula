using ApiPelicula.Models;
using ApiPelicula.Models.Dtos;
using AutoMapper;

namespace ApiPelicula.PeliculasMaper
{
    public class PeliculasMapper : Profile
    {
        public PeliculasMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();

        }
    }
}
