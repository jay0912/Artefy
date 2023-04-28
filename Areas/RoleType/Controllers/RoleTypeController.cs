using Artefy.Areas.RoleType.Models;
using Artefy.BAL;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.RoleType.Controllers
{
    [CheckAccess]
    [Area("RoleType")]
    [Route("RoleType/[Controller]/[action]")]
    public class RoleTypeController : Controller
    {

        //SEC_DAL Object
        SEC_DAL dalSEC = new SEC_DAL();


        #region SelectAll
        public IActionResult Index()
        {
            DataTable dtRoleType = dalSEC.RoleType_SelectAll();
            return View("RoleTypeList", dtRoleType);
        }

        #endregion


        #region Delete
        public IActionResult Delete(int RoleTypeID)
        {

            if (Convert.ToBoolean(dalSEC.RoleType_Delete(RoleTypeID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion


        #region Add
        public IActionResult Add(int? RoleTypeID)
        {

            #region Record Select by Pk
            if (RoleTypeID != null)
            {

                RoleTypeModel modelRoleType = dalSEC.RoleTypeSelectByPk((int)RoleTypeID);
                return View("RoleTypeAddEdit", modelRoleType);

            }
            #endregion
            return View("RoleTypeAddEdit");
        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult Save(RoleTypeModel modelRoleType)
        {

            if (ModelState.IsValid)
            {
                if (modelRoleType.RoleTypeID == null)
                {
                    if (Convert.ToBoolean(dalSEC.RoleTypeInsert(modelRoleType)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalSEC.RoleTypeUpdate(modelRoleType)))
                        return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Add");
        }
        #endregion


    }
}
