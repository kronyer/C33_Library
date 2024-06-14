using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Library.Models.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Customer.Controllers;

[Area("Customer")]
public class PostController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PostController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Post> posts = _unitOfWork.Post.GetAll(includeProperties: "Category").OrderBy(x => x.PublishDate).Reverse().ToList();

        return View(posts);
    }
}
