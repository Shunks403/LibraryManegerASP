using Azure.Core;
using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository _repository;

    public CategoryService(IRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Category> Add(Category category)
    {
        
        return _repository.Add(category);
    }

    public Task<Category> Update(Category category)
    {
        return _repository.Update(category);
    }

    public IEnumerable<Category> GetAll(int page, int size)
    {
        return _repository.GetAll<Category>().Skip((page - 1) * size).Take(size).ToList();
        
    }

    public Task Delete(int id)
    {
        return _repository.Delete<Category>(id);
    }

    public Task<Category> FindById(int id)
    {
        return _repository.GetById<Category>(id);
    }
}