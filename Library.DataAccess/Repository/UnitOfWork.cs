using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _db;
        public IPostRepository Post { get; private set; }
        public IPostCategoryRepository PostCategory { get; private set; }
        public IBookRepository Book { get; private set; }
        public IBookCategoryRepository BookCategory { get; private set; }
        public UnitOfWork(LibraryDbContext db)
        {
            _db = db;
            Post = new PostRepository(_db);
            PostCategory = new PostCategoryRepository(_db);
            Book = new BookRepository(_db);
            BookCategory = new BookCategoryRepository(_db);
        }

       


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
