using ApiPelicula.Data;
using ApiPelicula.Models;
using ApiPelicula.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiPelicula.Repository
{
    public class CategoryRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateCategory(Category category)
        {
            category.DateCreated = DateTime.Now;
            _context.Categories.Add(category);
            return save();
        }

        public bool DeleteCategory(Category category)
        {
           _context.Categories.Remove(category);
            return save();
        }

        public bool ExistCategory(string name)
        {
            bool category = _context.Categories.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            
            return category;
        }

        public bool ExistCategory(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == CategoryId);
        }

        public bool save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            category.DateCreated = DateTime.Now;
            _context.Categories.Update(category);
            return save();
        }
    }
}
