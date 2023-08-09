using System.ComponentModel.DataAnnotations;

namespace ApiPelicula.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(60, ErrorMessage ="El numero maximo de caracteres es de 60")]
        public string Name { get; set; }

    }
}
