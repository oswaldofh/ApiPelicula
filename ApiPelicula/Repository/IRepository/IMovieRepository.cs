using ApiPelicula.Models;

namespace ApiPelicula.Repository.IRepository
{
    public interface IMovieRepository
    {
        ICollection<Movie> GetMovies();
        Movie GetMovie(int movieId);
        bool ExistMovie(string name);
        bool ExistMovie(int Id);
        bool CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(Movie movie);

        //METODOS PARA BUSCAR PELICULAS EM CATEGORIA Y PELICULA POR EL NOMBRE
        ICollection<Movie> GetMoviesInCategory(int categoryId);
        ICollection<Movie> SearchMovie(string name);
        bool save();
    }
}
