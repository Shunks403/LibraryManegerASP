using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Interfaces;

public interface ICategoryService
{
    Task<Category> Add(Category category);
    
    Task<Category> Update(Category category);
    
    IEnumerable<Category> GetAll(int page, int size);
    
    Task Delete(int id);

    Task<Category> FindById(int id);
}