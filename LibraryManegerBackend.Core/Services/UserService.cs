using LibraryManegerBackend.Core.Interfaces;
using LibraryManegerBackend.Core.Models;
using MessangerBackend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManegerBackend.Core.Services;

public class UserService: IUserService
{
    private readonly IRepository _repository;
    private readonly IPasswordHasher _passwordHasher;
    public UserService(IRepository repository , IPasswordHasher passwordHasher)
    {
        _repository = repository;
        _passwordHasher = passwordHasher;
    }

    public  Task<User> Login(string username, string password)
    {
        if (username == null || string.IsNullOrEmpty(username.Trim()) || 
            password == null || string.IsNullOrEmpty(password.Trim()))
        {
            throw new ArgumentNullException();
        }
        
        var user = _repository.GetAll<User>()
            .Where(u => u.Username == username)
            .SingleOrDefault();

        if (user != null && _passwordHasher.Verify(password, user.Password))
        {
            return Task.FromResult(user);
        }
        else
        {
            throw new InvalidOperationException("User not found or incorrect password.");
        }
        
        
    }

    public async Task<User> Register(User user)
    {
        var existingUser = await _repository.GetAll<User>()
            .AnyAsync(u => u.Username == user.Username);

        if (existingUser)
        {
            throw new InvalidOperationException("A user with this username already exists.");
        }
        user.Password = _passwordHasher.Generate(user.Password);
        return await _repository.Add(user);
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