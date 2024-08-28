using LibraryManegerBackend.Core.Models;

namespace LibraryManegerBackend.Core.Interfaces;

public interface IBorrowService
{
    Task<Borrow> Add(Borrow borrow);
    
    Task<Borrow> Update(Borrow borrow);
    
    IEnumerable<Borrow> GetAll(int page, int size);
    
    Task Delete(int id);

    Task<Borrow> FindById(int id);
}