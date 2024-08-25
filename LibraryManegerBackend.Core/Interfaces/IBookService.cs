using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Interfaces;

public interface IBookService
{
    Task<Book> AddBook(Book book);
    Task<Book> UpdateBook(Book book);
    IEnumerable<Book> GetAllBooks(int page, int size);
    Task DeleteBook(int id);
    
    
}