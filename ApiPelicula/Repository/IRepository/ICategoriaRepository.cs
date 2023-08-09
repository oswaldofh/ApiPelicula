using ApiPelicula.Models;

namespace ApiPelicula.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int CategoryId);
        bool ExistCategory(string name);
        bool ExistCategory(int Id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool save();
    }
}
