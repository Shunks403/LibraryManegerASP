using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Authorize]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] int page , [FromQuery] int size)
    {
        var books =  _bookService.GetAllBooks(page,size);
        return Ok(books);
    }
    
    
}