using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
