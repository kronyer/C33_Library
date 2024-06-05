using Library.DataAccess.Repository.IRepository;
using Library.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public BookController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _unitOfWork.Book.GetAll(includeProperties: "Category,BookImages");
            return View(books);
        }

    }
}
