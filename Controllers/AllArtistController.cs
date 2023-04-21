using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Controllers
{
    public class AllArtistController : Controller
    {
        SEC_DAL dalSEC = new SEC_DAL();

        #region Artist SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalSEC.Artist_SelectAll();
            return View("AllArtistList", dt);
        }
        #endregion
    }
}
