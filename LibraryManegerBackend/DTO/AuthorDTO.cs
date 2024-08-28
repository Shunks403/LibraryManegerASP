using System.ComponentModel.DataAnnotations;
using LibraryManegerBackend.Core.Models;

namespace MessangerBackend.DTO;

public class AuthorDTO
{
    [Required]
    public string Name { get; set; }
   
}