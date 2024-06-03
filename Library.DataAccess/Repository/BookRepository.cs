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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _db;

        public BookRepository(LibraryDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book book)
        {
            if (book != null)
            {
                _db.Books.Update(book);
            }
        }
    }
}
