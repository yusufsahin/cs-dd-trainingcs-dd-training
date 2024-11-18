using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Dtos;
using OnlineStore.BAL.Abstract;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }

        [HttpGet]   
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _mapper.Map<Category>(categoryDto);
            var addedCategory = await _categoryService.AddAsync(category);
            var result = _mapper.Map<CategoryDto>(addedCategory);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != categoryDto.Id)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryService.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> Delete(int id) { 
            var categotyToBeDeleted = await _categoryService.GetByIdAsync(id);
            if (categotyToBeDeleted == null)
            {
                return NotFound();
            }
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
