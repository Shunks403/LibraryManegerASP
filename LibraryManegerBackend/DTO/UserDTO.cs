using System.ComponentModel.DataAnnotations;

namespace MessangerBackend.DTO;

public class UserDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    
    public string Role { get; set; } = "Client"; 
}