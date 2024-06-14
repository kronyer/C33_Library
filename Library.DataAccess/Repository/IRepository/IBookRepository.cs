using Library.Models.Models;

namespace Library.DataAccess.Repository.IRepository;

public interface IBookRepository : IRepository<Book>
{
    void Update(Book book);
}
