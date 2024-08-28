using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Interfaces;

public interface IAuthorService
{
    Task<Author> Add(Author book);
    
    Task<Author> Update(Author book);
    
    IEnumerable<Author> GetAll(int page, int size);
    
    Task Delete(int id);

    Task<Author> FindById(int id);
}