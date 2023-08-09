using ApiPelicula.Models;
using ApiPelicula.Models.Dtos;
using ApiPelicula.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelicula.Controllers
{
    [ApiController]
    [Route("api/¨[controller]")] //UNA OPCION, EN ESTE CASO TOMA EL NOMBRE DEL CONTROLLER
    //[Route("api/¨[categories]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        //LOS CODIGOS QUE DEVUELVE LA FUNCION
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCategories() {
        
            var categories = _categoriaRepository.GetCategories();
            var categoriesDto = new List<CategoryDto>();
            foreach (var list in categories)
            {
                categoriesDto.Add(_mapper.Map<CategoryDto>(list));
            }
            return Ok(categoriesDto);
        }

        [HttpGet("{categoryId:int}", Name ="GetCategory")]
        //LOS CODIGOS QUE DEVUELVE LA FUNCION
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategory( int categoryId)
        {

            var itemCategory = _categoriaRepository.GetCategory(categoryId);
           
            if (itemCategory == null)
            {
                return NotFound();
            }

            var itemCategoryDto = _mapper.Map<CategoryDto>(itemCategory);
            return Ok(itemCategoryDto);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                
            }
            if (createCategoryDto == null)
            {
                return BadRequest(ModelState);
                
            }

            if (_categoriaRepository.ExistCategory(createCategoryDto.Name))
            {
                ModelState.AddModelError("", "La categoria ya existe");
                return StatusCode(404, ModelState);
            }

            var category = _mapper.Map<Category>(createCategoryDto);

            if (!_categoriaRepository.CreateCategory(category))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el regustro {category.Name}"); //$ para devolver valores dinamicos
                return StatusCode(500, ModelState);

            }
            return CreatedAtRoute("GetCategory", new {categoryId = category.Id}, category); //se devuelve el id que se crea

        }


        [HttpPatch("{categoryId:int}", Name = "UpdatePatchCategory")]
        [ProducesResponseType(201, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatchCategory(int categoryId, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (categoryDto == null || categoryId != categoryDto.Id)
            {
                return BadRequest(ModelState);

            }

            var category = _mapper.Map<Category>(categoryDto);

            if (!_categoriaRepository.UpdateCategory(category))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el regustro {category.Name}"); //$ para devolver valores dinamicos
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }

        [HttpDelete("{categoryId:int}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoriaRepository.ExistCategory(categoryId)){
                return NotFound();

            }


            var category = _categoriaRepository.GetCategory(categoryId);

            if (!_categoriaRepository.DeleteCategory(category))
            {
                ModelState.AddModelError("", $"Algo salio mal eliminando el regustro {category.Name}"); //$ para devolver valores dinamicos
                return StatusCode(500, ModelState);

            }
            return NoContent();

        }
    }
}
