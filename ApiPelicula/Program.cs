using ApiPelicula.Data;
using ApiPelicula.PeliculasMaper;
using ApiPelicula.Repository;
using ApiPelicula.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//SE CONFIGURA LA CADENA DE CONEXION A LA BASE DE DATOS
builder.Services.AddDbContext<DataContext>(options =>

 options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionSql"))

);

//SE AGREGAN LOS REPOSITORIOS OSEA LAS INTERFACES
builder.Services.AddScoped<ICategoriaRepository, CategoryRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

//SE AGREGA EL AUTOMAPPER
builder.Services.AddAutoMapper(typeof(PeliculasMapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
