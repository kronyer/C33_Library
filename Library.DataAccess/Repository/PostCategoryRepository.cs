using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;

namespace Library.DataAccess.Repository;

public class PostCategoryRepository : Repository<PostCategory>, IPostCategoryRepository
{
    private readonly LibraryDbContext _db;
    public PostCategoryRepository(LibraryDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(PostCategory postCategory)
    {
        _db.PostCategories.Update(postCategory);
    }
}
