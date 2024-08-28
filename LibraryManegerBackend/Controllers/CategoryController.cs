using AutoMapper;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Route("api/category")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] int page , [FromQuery] int size)
    {
        var categories =  _categoryService.GetAll(page,size);
        return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
    }
    
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _categoryService.Add(_mapper.Map<Category>(categoryDto));
            return Ok(categoryDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Author>(categoryDto);
        if (id != category.Id)
            return BadRequest("Category ID mismatch");

        var existingCategory = await _categoryService.FindById(id);
        if (existingCategory == null)
            return NotFound();

        existingCategory.Name = category.Name;
        existingCategory.Id = category.Id;
        existingCategory.Books = category.Books;

        try
        {
            await _categoryService.Update(existingCategory);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    
    
}