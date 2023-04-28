using Artefy.Areas.Country.Models;
using Artefy.BAL;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.Country.Controllers
{
    [CheckAccess]
    [Area("Country")]
    [Route("Country/[Controller]/[action]")]
    public class CountryController : Controller
    {

        //LOC_DAL Object
        LOC_DAL dalLOC = new LOC_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dtCountry = dalLOC.Country_SelectAll();
            return View("CountryList", dtCountry);
        }

        #endregion


        #region Delete
        public IActionResult Delete(int CountryID)
        {

            if (Convert.ToBoolean(dalLOC.Country_Delete(CountryID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion


        #region Add
        public IActionResult Add(int? CountryID)
        {

            #region Record Select by Pk
            if (CountryID != null)
            {

                CountryModel modelCountry = dalLOC.CountrySelectByPk((int)CountryID);
                return View("CountryAddEdit", modelCountry);

            }
            #endregion
            return View("CountryAddEdit");
        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult Save(CountryModel modelCountry)
        {

            if (ModelState.IsValid)
            {
                if (modelCountry.CountryID == null)
                {
                    if (Convert.ToBoolean(dalLOC.CountryInsert(modelCountry)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.CountryUpdate(modelCountry)))
                        return RedirectToAction("Index");
                }
            }
      
            return RedirectToAction("Add");
        }
        #endregion

    }
}
 