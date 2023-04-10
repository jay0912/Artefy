using Artefy.BAL;
using Microsoft.AspNetCore.Mvc;

namespace Artefy.Areas.Admin.Controllers
{
    [CheckAccess]
    [Area("Admin")]
    [Route("Admin/[Controller]/[action]")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("Dashboard");
        }
    }
}
