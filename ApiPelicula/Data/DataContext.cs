using ApiPelicula.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPelicula.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //AGREGAR TODO LOS MODELOS
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }

        //ANTES DE CREAR LA BASE DE DATOS CREAMOS INDICES
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Movie>().HasIndex("Name", "CategoryId").IsUnique();//indice compuesto, solo se tiene una pelicula con ese nombre eb esa categoria
            //modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); //INDICE COMPUESTO se tiene solo un estado por pias con ese nombre
        }
    }
}
