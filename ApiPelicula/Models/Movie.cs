using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPelicula.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public enum TypeClasification { Siete, Trece, Diecisite, Dieciocho } //TIPO DE ENUMERACION

        public TypeClasification Clasification { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
