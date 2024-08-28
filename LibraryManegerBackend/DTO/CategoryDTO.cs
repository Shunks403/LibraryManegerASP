using System.ComponentModel.DataAnnotations;

namespace MessangerBackend.DTO;

public class CategoryDTO
{
    [Required]
    public string Name { get; set; }
    
   
}