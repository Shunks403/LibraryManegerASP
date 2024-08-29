using System.Collections;
using AutoMapper;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;
using MessangerBackend.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Authorize]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] int page , [FromQuery] int size)
    {
        var books =  _bookService.GetAllBooks(page,size);
        return Ok(_mapper.Map<IEnumerable<BookResponse>>(books));
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatBook([FromBody] BookRequest bookRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _bookService.AddBook(_mapper.Map<Book>(bookRequest));
            return Ok(bookRequest);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookRequest bookRequest)
    {
        var book = _mapper.Map<Book>(bookRequest);

        var existingBook = await _bookService.FindBookById(id);
        if (existingBook == null)
            return NotFound();

        existingBook.Title = book.Title;
        existingBook.AuthorId = book.AuthorId;
        existingBook.CategoryId = book.CategoryId;

        try
        {
            await _bookService.UpdateBook(existingBook);
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
            await _bookService.DeleteBook(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
   
}