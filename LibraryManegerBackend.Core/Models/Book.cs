using System.ComponentModel.DataAnnotations;

namespace LibraryManegerBackend.Core.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Borrow> Borrows { get; set; }
}