using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Interfaces;

public interface IUserService
{
    Task<User> Login(string username, string password);

    Task<User> Register(User user);

    Task Delete(int id);

    Task<User> Update(User user);

    IEnumerable<User> GetAll();

    Task<User> FindById(int id);

}
    