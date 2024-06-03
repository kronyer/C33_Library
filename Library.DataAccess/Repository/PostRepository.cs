using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository
{
    internal class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly LibraryDbContext _db;
        public PostRepository(LibraryDbContext db) : base(db)
        {
            _db = db;
        }

        void IPostRepository.Update(Post post)
        {
            _db.Posts.Update(post);
        }
    }
}
