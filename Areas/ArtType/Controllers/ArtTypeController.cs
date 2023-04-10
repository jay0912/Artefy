using Artefy.Areas.ArtType.Models;
using Artefy.Areas.PaymentMode.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.ArtType.Controllers
{
    [Area("ArtType")]
    [Route("ArtType/[Controller]/[action]")]
    public class ArtTypeController : Controller
    {

        //BUY_DAL Object
        ART_DAL dalART = new ART_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dtArtType = dalART.ArtType_SelectAll();
            return View("ArtTypeList", dtArtType);
        }

        #endregion


        #region Delete
        public IActionResult Delete(int ArtTypeID)
        {

            if (Convert.ToBoolean(dalART.ArtType_Delete(ArtTypeID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion


        #region Add
        public IActionResult Add(int? ArtTypeID)
        {

            #region Record Select by Pk
            if (ArtTypeID != null)
            {

                ArtTypeModel modelArtType = dalART.ArtTypeSelectByPk((int)ArtTypeID);
                return View("ArtTypeAddEdit", modelArtType);

            }
            #endregion
            return View("ArtTypeAddEdit");
        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult Save(ArtTypeModel modelArtType)
        {

            if (ModelState.IsValid)
            {
                if (modelArtType.ArtTypeID == null)
                {
                    if (Convert.ToBoolean(dalART.ArtTypeInsert(modelArtType)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalART.ArtTypeUpdate(modelArtType)))
                        return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Add");
        }
        #endregion


    }
}
