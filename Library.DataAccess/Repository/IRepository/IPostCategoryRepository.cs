using Library.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository.IRepository
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        void Update(PostCategory postCategory);
    }
}
