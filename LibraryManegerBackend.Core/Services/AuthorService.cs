using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Services;

public class AuthorService : IAuthorService
{
    private readonly IRepository _repository;

    public AuthorService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<Author> Add(Author author)
    {
        return _repository.Add(author);
    }

    public Task<Author> Update(Author author)
    {
        return _repository.Update(author);
    }

    public IEnumerable<Author> GetAll(int page, int size)
    {
        if (page <= 0)
            page = 1;
        return _repository.GetAll<Author>().Skip((page - 1) * size).Take(size).ToList();
        
    }

    public Task Delete(int id)
    {
        return _repository.Delete<Author>(id);
    }

    public Task<Author> FindById(int id)
    {
        return _repository.GetById<Author>(id);
    }
}