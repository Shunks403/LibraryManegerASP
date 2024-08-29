using System.ComponentModel.DataAnnotations;
using LibraryManegerBackend.Core.Models;

namespace MessangerBackend.DTO;

public class BookRequest
{
    
    public string Title { get; set; }
    
    public int AuthorId { get; set; }
    
    public int CategoryId { get; set; }
    
   
}