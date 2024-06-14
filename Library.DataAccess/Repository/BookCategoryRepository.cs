using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;

namespace Library.DataAccess.Repository;

internal class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
{
    private readonly LibraryDbContext _db;
    public BookCategoryRepository(LibraryDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(BookCategory category)
    {
        _db.BookCategories.Update(category);
    }
}
