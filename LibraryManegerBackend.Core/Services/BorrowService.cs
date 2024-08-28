using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Services;

public class BorrowService : IBorrowService
{
    private readonly IRepository _repository;

    public BorrowService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<Borrow> Add(Borrow borrow)
    {
        return _repository.Add(borrow);
    }

    public Task<Borrow> Update(Borrow borrow)
    {
        return _repository.Update(borrow);
    }

    public IEnumerable<Borrow> GetAll(int page, int size)
    {
        if (page <= 0)
            page = 1;
        
        return _repository.GetAll<Borrow>().Skip((page - 1) * size).Take(size).ToList();
    }

    public Task Delete(int id)
    {
        return _repository.Delete<Borrow>(id);
    }

    public Task<Borrow> FindById(int id)
    {
        return _repository.GetById<Borrow>(id);
    }
}