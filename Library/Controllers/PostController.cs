﻿using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
