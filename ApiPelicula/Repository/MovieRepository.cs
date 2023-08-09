using ApiPelicula.Data;
using ApiPelicula.Models;
using ApiPelicula.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiPelicula.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DataContext _context;

        public MovieRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateMovie(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            _context.Movies.Add(movie);
            return save();
        }

        public bool DeleteMovie(Movie movie)
        {
           _context.Movies.Remove(movie);
            return save();
        }

        public bool ExistMovie(string name)
        {
            bool Movie = _context.Movies.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            
            return Movie;
        }

        public bool ExistMovie(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public ICollection<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(c => c.Name).ToList();
        }

        public Movie GetMovie(int movieId)
        {
            return _context.Movies.FirstOrDefault(c => c.Id == movieId);
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMovie(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            _context.Movies.Update(movie);
            return save();
        }

        public ICollection<Movie> GetMoviesInCategory(int categoryId)
        {
            return _context.Movies
                .Include(c => c.Category).Where(c=> c.CategoryId == categoryId).ToList();
        }

        public ICollection<Movie> SearchMovie(string name)
        {
            //INDICA QUE SE PUEDE HACER CONSULTAS QUERYS
            IQueryable<Movie> query = _context.Movies;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Name.Contains(name) || m.Description.Contains(name));
                
            }
            return query.ToList();
        }
    }
}
