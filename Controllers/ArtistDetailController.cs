using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Controllers
{
	public class ArtistDetailController : Controller
	{
        SEC_DAL dalSEC = new SEC_DAL();
        public IActionResult Index(int? UserID)
        {
            #region Record Select by Pk
            if (UserID != null)
            {

                DataTable dt = dalSEC.Artist_Detail((int)UserID);

                return View("ArtistViewDetail", dt);

            }
            #endregion
            return View("ArtistViewDetail");
        }
    }
}
