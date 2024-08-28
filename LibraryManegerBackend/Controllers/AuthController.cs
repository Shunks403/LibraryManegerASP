using AutoMapper;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend;
using MessangerBackend.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManegerBackend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public AuthController(IUserService userService, IConfiguration configuration , IMapper mapper )
    {
        _userService = userService;
        _configuration = configuration;
        _mapper = mapper;
        
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> RegisterUser([FromBody] UserDTO user)
    {
        var userDb = await _userService.Register(_mapper.Map<User>(user));
        var jwt = JwtGenerator.GenerateJwt(userDb, _configuration.GetValue<string>("TokenKey")!, DateTime.UtcNow.AddMinutes(5));
        
        HttpContext.Session.SetInt32("id", userDb.Id);
        
        HttpContext.Response.Cookies.Append("token", jwt);

        return Created("token", jwt);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromQuery] string username, [FromQuery] string password)
    {
        var user = await _userService.Login(username, password);
        var jwt = JwtGenerator.GenerateJwt(user, _configuration.GetValue<string>("TokenKey")!, DateTime.UtcNow.AddMinutes(5));

        HttpContext.Response.Cookies.Append("token", jwt);
        
        return Created("token", jwt);
    }
}