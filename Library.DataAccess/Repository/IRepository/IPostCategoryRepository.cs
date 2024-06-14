using Library.Models.Models;

namespace Library.DataAccess.Repository.IRepository;

public interface IPostCategoryRepository : IRepository<PostCategory>
{
    void Update(PostCategory postCategory);
}
