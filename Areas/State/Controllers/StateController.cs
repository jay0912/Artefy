using Artefy.Areas.Country.Models;
using Artefy.Areas.State.Models;
using Artefy.BAL;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.State.Controllers
{
    [CheckAccess]
    [Area("State")]
    [Route("State/[Controller]/[action]")]
    public class StateController : Controller
    {

        LOC_DAL dalLOC = new LOC_DAL();
        StateModel modelState = new StateModel();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.State_SelectAll();
            return View("StateList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int StateID)
        {
            if (Convert.ToBoolean(dalLOC.State_Delete(StateID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? StateID)
        {

            #region DropDown

            
            DataTable dtCountry = dalLOC.Country_SelectByDropdownList();

            List<CountryDropDown> countrydropdown = new List<CountryDropDown>();

            foreach (DataRow dr in dtCountry.Rows)
            {
                CountryDropDown dropdown = new CountryDropDown();
                dropdown.CountryID = Convert.ToInt32(dr["CountryID"]);
                dropdown.CountryName = dr["CountryName"].ToString();
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;
            #endregion 

            #region Record Select by Pk
            if (StateID != null)
            {

                StateModel modelState = dalLOC.StateSelectByPk((int)StateID);
                return View("StateAddEdit", modelState);

            }
            #endregion

            return View("StateAddEdit");

        }
        
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(StateModel modelState)
        {

            //insert and update

            if (ModelState.IsValid)
            {
                if (modelState.StateID == null)
                {
                    if (Convert.ToBoolean(dalLOC.StateInsert(modelState)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.StateUpdate(modelState)))
                        return RedirectToAction("Index");
                }
            }
        
            return RedirectToAction("Add");
            
        }
        #endregion
    }
}
