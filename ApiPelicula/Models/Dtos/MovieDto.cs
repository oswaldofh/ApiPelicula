using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPelicula.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        //SE MARCA COMO REQUERIDO
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        public string UrlImage { get; set; }
        //SE MARCA COMO REQUERIDO
        [Required(ErrorMessage = "La descripción es obligatorio")]
        public string Description { get; set; }
        //SE MARCA COMO REQUERIDO
        [Required(ErrorMessage = "La duración es obligatorio")]
        public int Duration { get; set; }
        public enum TypeClasification { Siete, Trece, Diecisite, Dieciocho } //TIPO DE ENUMERACION

        public TypeClasification Clasification { get; set; }
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
    }
}

