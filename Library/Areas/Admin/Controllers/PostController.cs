using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Library.Models.Models.ViewModels;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
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

    public IActionResult PostList()
    {
        return View();
    }

    public IActionResult Upsert(int? id)
    {
        PostVM postVM = new PostVM()
        {
            CategoriesList = _unitOfWork.PostCategory.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }),
            Post = new Post()
        };

        if (id is null || id == 0)
        {
            //para create retorna num novo
            return View(postVM);
        }
        else
        {
            //para update retorna os campos populadors
            postVM.Post = _unitOfWork.Post.Get(x => x.Id == id);
            return View(postVM);
        }
    }

    [HttpPost]
    public IActionResult Upsert(PostVM obj)
    {
        if (obj.Post.Id == 0)
        {
            obj.Post.LastEdited = DateTime.Now;
            obj.Post.PublishDate = DateTime.Now;
            _unitOfWork.Post.Add(obj.Post);
        }
        else
        {
            obj.Post.LastEdited = DateTime.Now;
            _unitOfWork.Post.Update(obj.Post);
        }
        _unitOfWork.Save();
        return RedirectToAction("Index", "Post", new { area = "Customer" });

    }


    #region APICalls
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Post> objPostList = _unitOfWork.Post.GetAll(includeProperties: "Category").ToList();
        return Json(new { data = objPostList });
    }

    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var postToDelete = _unitOfWork.Post.Get(x => x.Id == id);
        if (postToDelete is null)
        {
            return Json(new { success = false, message = "Error" });
        }

        _unitOfWork.Post.Remove(postToDelete);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Book deleted" });
    }
    #endregion
}
