using System.ComponentModel.DataAnnotations;

namespace ApiPelicula.Models.Dtos
{
    public class CreateCategoryDto
    {
        //SE MARCA COMO REQUERIDO
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo de caracteres es de 100")]
        public string Name { get; set; }
    }
}
