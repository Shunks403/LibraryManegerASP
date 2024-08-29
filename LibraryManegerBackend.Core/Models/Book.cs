using System.ComponentModel.DataAnnotations;

namespace LibraryManegerBackend.Core.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    [Required]
    public virtual int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
}