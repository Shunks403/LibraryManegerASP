using AutoMapper;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Route("api/borrow")]
[Authorize]
public class BorrowController : ControllerBase
{
    private readonly IBorrowService _borrowService;
    private readonly IMapper _mapper;


    public BorrowController(IBorrowService borrowService, IMapper mapper)
    {
        _borrowService = borrowService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBorrows([FromQuery] int page , [FromQuery] int size)
    {
        var borrows =  _borrowService.GetAll(page,size);
        return Ok(_mapper.Map<IEnumerable<Borrow>>(borrows));
    }


    [HttpPost]
    public async Task<IActionResult> CreatBorrow([FromBody] BorrowDTO borrowDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _borrowService.Add(_mapper.Map<Borrow>(borrowDto));
            return Ok(borrowDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}