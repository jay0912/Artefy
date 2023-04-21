using Artefy.Areas.ArtWork.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Controllers
{
    public class ArtDetailController : Controller
    {
        ART_DAL dalART = new ART_DAL();
        public IActionResult Index(int? ArtWorkID)
        {
            #region Record Select by Pk
            if (ArtWorkID != null)
            {

                DataTable dt = dalART.ArtWork_ViewDetail((int)ArtWorkID);
             
                return View("ArtViewDetail", dt);

            }
            #endregion
            return View("ArtViewDetail");
        }
    }
}
