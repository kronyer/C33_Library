using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPostCategoryRepository PostCategory { get; }
        IPostRepository Post{ get; }
        IBookCategoryRepository BookCategory { get; }
        IBookRepository Book { get; }
        IBookImageRepository BookImage { get; }

        void Save();
    }
}
