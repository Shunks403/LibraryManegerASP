using System.ComponentModel.DataAnnotations;

namespace LibraryManegerBackend.Core.Models;

public class Borrow
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [Required]
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnedAt { get; set; }
}