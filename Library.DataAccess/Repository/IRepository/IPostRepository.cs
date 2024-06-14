using Library.Models.Models;

namespace Library.DataAccess.Repository.IRepository;

public interface IPostRepository : IRepository<Post>
{
    void Update(Post post);
}
