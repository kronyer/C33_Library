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
    internal class BookImageRepository : Repository<BookImage>, IBookImageRepository
    {
        private readonly LibraryDbContext _db;
        public BookImageRepository(LibraryDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BookImage bookImage)
        {
            _db.BookImages.Update(bookImage);
        }
    }
}
