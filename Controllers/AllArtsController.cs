using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Controllers
{
    public class AllArtsController : Controller
    {
        ART_DAL dalART = new ART_DAL();
        #region
        public IActionResult Index()
        {
            DataTable dt = dalART.ArtWork_SelectAll();
            return View("AllArts", dt);
        }
        #endregion
    }
}
