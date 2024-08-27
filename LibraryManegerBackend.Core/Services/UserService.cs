using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Services;

public class UserService: IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public  Task<User> Login(string username, string password)
    {
        var user = _repository.GetAll<User>()
            .Where(u => u.Username == username && u.Password == password)
            .SingleOrDefault();

        return Task.FromResult(user);
    }

    public Task<User> Register(User user)
    {
        return _repository.Add(user);
    }

    public Task Delete(int id)
    {
        return _repository.Delete<User>(id);
    }

    public Task<User> Update(User user)
    {
        return _repository.Update(user);
    }

    public IEnumerable<User> GetAll()
    {
        return _repository.GetAll<User>().ToList();
    }

    public Task<User> FindById(int id)
    {
        return _repository.GetById<User>(id);
    }
}