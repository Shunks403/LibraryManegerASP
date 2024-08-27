using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Authorize]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] int page , [FromQuery] int size)
    {
        var books =  _bookService.GetAllBooks(page,size);
        return Ok(books);
    }


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatBook([FromQuery] Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _bookService.AddBook(book);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest("Book ID mismatch");

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