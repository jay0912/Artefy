using Artefy.Areas.PaymentMode.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.PaymentMode.Controllers
{
    [Area("PaymentMode")]
    [Route("PaymentMode/[Controller]/[action]")]
    public class PaymentModeController : Controller
    {
        //BUY_DAL Object
        BUY_DAL dalBUY = new BUY_DAL();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dtPaymentMode = dalBUY.PaymentMode_SelectAll();
            return View("PaymentModeList", dtPaymentMode);
        }

        #endregion


        #region Delete
        public IActionResult Delete(int PaymentModeID)
        {

            if (Convert.ToBoolean(dalBUY.PaymentMode_Delete(PaymentModeID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion


        #region Add
        public IActionResult Add(int? PaymentModeID)
        {

            #region Record Select by Pk
            if (PaymentModeID != null)
            {

                PaymentModeModel modelPaymentMode = dalBUY.PaymentModeSelectByPk((int)PaymentModeID);
                return View("PaymentModeAddEdit", modelPaymentMode);

            }
            #endregion
            return View("PaymentModeAddEdit");
        }
        #endregion


        #region Insert
        [HttpPost]
        public IActionResult Save(PaymentModeModel modelPaymentMode)
        {

            if (ModelState.IsValid)
            {
                if (modelPaymentMode.PaymentModeID == null)
                {
                    if (Convert.ToBoolean(dalBUY.PaymentModeInsert(modelPaymentMode)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalBUY.PaymentModeUpdate(modelPaymentMode)))
                        return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Add");
        }
        #endregion
    }
}
