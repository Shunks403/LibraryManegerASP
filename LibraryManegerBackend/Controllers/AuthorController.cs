using AutoMapper;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Route("api/author")]
[Authorize]
public class AuthorController: ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAuthors([FromQuery] int page , [FromQuery] int size)
    {
        var authors =  _authorService.GetAll(page,size);
        return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authors));
    }
    
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] AuthorDTO author)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _authorService.Add(_mapper.Map<Author>(author));
            return Ok(author);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAuthor(int id, AuthorDTO authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);
        

        var existingAuthor = await _authorService.FindById(id);
        if (existingAuthor == null)
            return NotFound();

        existingAuthor.Name = author.Name;
        existingAuthor.Books = author.Books;

        try
        {
            await _authorService.Update(existingAuthor);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete( int id)
    {
        try
        {
            await _authorService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}