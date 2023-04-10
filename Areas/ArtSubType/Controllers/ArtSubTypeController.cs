using Artefy.Areas.ArtSubType.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static Artefy.Areas.ArtType.Models.ArtTypeModel;

namespace Artefy.Areas.ArtSubType.Controllers
{
    [Area("ArtSubType")]
    [Route("ArtSubType/[Controller]/[action]")]
    public class ArtSubTypeController : Controller
    {

        ART_DAL dalART = new ART_DAL();
        ArtSubTypeModel modelArtSubType = new ArtSubTypeModel();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalART.ArtSubType_SelectAll();
            return View("ArtSubTypeList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ArtSubTypeID)
        {
            if (Convert.ToBoolean(dalART.ArtSubType_Delete(ArtSubTypeID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? ArtSubTypeID)
        {

            #region DropDown


            DataTable dtArtType = dalART.ArtType_SelectByDropdownList();

            List<ArtTypeDropDown> artTypedropdown = new List<ArtTypeDropDown>();

            foreach (DataRow dr in dtArtType.Rows)
            {
                ArtTypeDropDown dropdown = new ArtTypeDropDown();
                dropdown.ArtTypeID = Convert.ToInt32(dr["ArtTypeID"]);
                dropdown.ArtTypeName = dr["ArtTypeName"].ToString();
                artTypedropdown.Add(dropdown);
            }
            ViewBag.ArtTypeList = artTypedropdown;
            #endregion 

            #region Record Select by Pk
            if (ArtSubTypeID != null)
            {

                ArtSubTypeModel modelArtSubType = dalART.ArtSubTypeSelectByPk((int)ArtSubTypeID);
                return View("ArtSubTypeAddEdit", modelArtSubType);

            }
            #endregion

            return View("ArtSubTypeAddEdit");

        }

        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(ArtSubTypeModel modelArtSubType)
        {

            //insert and update

            if (ModelState.IsValid)
            {
                if (modelArtSubType.ArtSubTypeID == null)
                {
                    if (Convert.ToBoolean(dalART.ArtSubTypeInsert(modelArtSubType)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalART.ArtSubTypeUpdate(modelArtSubType)))
                        return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Add");

        }
        #endregion

    }
}
