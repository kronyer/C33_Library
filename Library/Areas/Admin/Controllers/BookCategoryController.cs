using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class BookCategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BookCategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Upsert(int? id)
    {
        if (id is null || id == 0)
        {
            //para create retorna num novo
            return View(new BookCategory());
        }
        else
        {
            //para update retorna os campos populadors
            BookCategory bookCategory = _unitOfWork.BookCategory.Get(x => x.Id == id);
            return View(bookCategory);
        }
    }

    [HttpPost]
    public IActionResult Upsert(BookCategory bookCategory)
    {
        if (bookCategory.Id == 0)
        {
            _unitOfWork.BookCategory.Add(bookCategory);
        }
        else
        {
            _unitOfWork.BookCategory.Update(bookCategory);
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
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
