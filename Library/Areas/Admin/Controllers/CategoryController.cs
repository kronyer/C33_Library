using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAjax([FromBody] string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return BadRequest("Invalid category name");
            }

            var newCategory = new BookCategory
            {
                Name = categoryName
            };

            _unitOfWork.BookCategory.Add(newCategory);
            _unitOfWork.Save();

            return Ok(new { categoryId = newCategory.Id, categoryName = newCategory.Name });
        }

        #region APICalls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<BookCategory> objCategoryList = _unitOfWork.BookCategory.GetAll().ToList();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var categoryToDelete = _unitOfWork.BookCategory.Get(x => x.Id == id);
            if (categoryToDelete is null)
            {
                return Json(new { success = false, message = "Error" });
            }

            _unitOfWork.BookCategory.Remove(categoryToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Book deleted" });
        }
        #endregion
    }
}
