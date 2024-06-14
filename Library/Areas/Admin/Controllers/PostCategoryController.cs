using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers;

[Area("Admin")]
public class PostCategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PostCategoryController(IUnitOfWork unitOfWork)
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

        var newCategory = new PostCategory
        {
            Name = categoryName
        };

        _unitOfWork.PostCategory.Add(newCategory);
        _unitOfWork.Save();

        return Ok(new { categoryId = newCategory.Id, categoryName = newCategory.Name });
    }
}
