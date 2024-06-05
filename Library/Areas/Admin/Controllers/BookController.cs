using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Book> books = _unitOfWork.Book.GetAll(includeProperties: "Category").ToList();
            return View(books);
        }

        #region Upsert
        public IActionResult Upsert(int? id)
        {
            BookVM bookVM = new BookVM()
            {
                CategoriesList = _unitOfWork.BookCategory.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Book = new Book()
            };

            if (id is null || id == 0)
            {
                //para create retorna num novo
                return View(bookVM);
            }
            else
            {
                //para update retorna os campos populadors
                bookVM.Book = _unitOfWork.Book.Get(x => x.Id == id, includeProperties: "BookImages");
                return View(bookVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(BookVM obj, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (obj.Book.Id == 0) //create!
                {

                    _unitOfWork.Book.Add(obj.Book);
                    //ver isso depois
                    TempData["success"] = "Book created";
                }
                else // update
                {
                    _unitOfWork.Book.Update(obj.Book);
                    TempData["success"] = "Book updated";
                }
                _unitOfWork.Save();

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string bookPath = @"images\books\book-" + obj.Book.Id;
                        string finalPath = Path.Combine(wwwRootPath, bookPath);

                        if (!Directory.Exists(finalPath))
                        {
                            Directory.CreateDirectory(finalPath);
                        }

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        BookImage bookImage = new BookImage()
                        {
                            ImageUrl = @"\" + bookPath + @"\" + fileName,
                            BookId = obj.Book.Id,
                        };

                        if (obj.Book.BookImages == null)
                        {
                            obj.Book.BookImages = new List<BookImage>();
                        }

                        obj.Book.BookImages.Add(bookImage);
                    }
                    _unitOfWork.Book.Update(obj.Book);
                    _unitOfWork.Save();
                }
                TempData["success"] = "Product Created";
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Book bookToDelete = _unitOfWork.Book.Get(x => x.Id == id);
            if (bookToDelete == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(bookToDelete);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToDelete = _unitOfWork.BookImage.Get(x => x.Id == imageId);
            int productId = imageToDelete.BookId;
            if (imageToDelete != null)
            {
                if (!string.IsNullOrEmpty(imageToDelete.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToDelete.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _unitOfWork.BookImage.Remove(imageToDelete);
                _unitOfWork.Save();
                TempData["success"] = "Image deleted";
            }
            return RedirectToAction(nameof(Upsert), new { id = productId });
        }
        #endregion

        

        #region APICalls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Book> objBooksList = _unitOfWork.Book.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objBooksList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var bookToDelete = _unitOfWork.Book.Get(x => x.Id == id);
            if (bookToDelete is null)
            {
                return Json(new { success = false, message = "Error" });
            }

            string bookPath = @"images\books\book-" + id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, bookPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths = Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.Delete(finalPath);
            }

            _unitOfWork.Book.Remove(bookToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Book deleted" });

        }
        #endregion
    }
}
