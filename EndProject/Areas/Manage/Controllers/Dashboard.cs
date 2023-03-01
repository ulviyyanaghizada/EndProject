using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EndProject.Areas.Manage.Controllers
{
    [Area("Manage")]
//    [Authorize(Roles = "SuperAdmin")]

    public class Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
