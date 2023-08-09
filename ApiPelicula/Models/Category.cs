using System.ComponentModel.DataAnnotations;

namespace ApiPelicula.Models
{
    public class Category
    {
        [Key] //SE RECONOCE COMO LE CLAVE PRIMARIA SE IMPORTA EL PAQUETE
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
