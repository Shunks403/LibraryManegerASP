using System.ComponentModel.DataAnnotations;

namespace MessangerBackend.DTO;

public class BorrowDTO
{
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int BookId { get; set; }
    
    public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? ReturnedAt { get; set; }
    
    
    public string UserName { get; set; }  
    public string BookTitle { get; set; } 
}