﻿using Microsoft.AspNetCore.Mvc;

namespace EndProject.Controllers.Pages
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
