using Library.Models.Models;

namespace Library.DataAccess.Repository.IRepository;

public interface IBookImageRepository : IRepository<BookImage>
{
    void Update(BookImage bookImage);
}
