using Library.Models.Models;

namespace Library.DataAccess.Repository.IRepository;

public interface IBookCategoryRepository : IRepository<BookCategory>
{
    void Update(BookCategory category);
}
