using Artefy.Areas.SEC_User.Models;
using Artefy.BAL;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Artefy.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[Controller]/[action]")]
    public class SEC_UserController : Controller
    {
        public IActionResult Index()
        {
            return View("LoginPage");
        }

        [HttpPost]

        public IActionResult Login(SEC_UserModel modelSEC_User)
        {

            string error = null;

            if (modelSEC_User.UserName == null)
            {
                error += "User Name is Required";
            }
            if (modelSEC_User.Password == null)
            {
                error += "<br/>Password is Required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                RedirectToAction("LoginPage");
            }
            else
            {
                SEC_DAL dalSEC = new SEC_DAL();
                DataTable dt = dalSEC.PR_SEC_User_SelectByUserNamePassword(modelSEC_User.UserName, modelSEC_User.Password);
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("RoleTypeID", dr["RoleTypeID"].ToString());
                        //HttpContext.Session.SetString("ProfilePic", dr["ProfilePic"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        //HttpContext.Session.SetString("BirthDate", dr["BirthDate"].ToString());
                        //HttpContext.Session.SetString("Address", dr["Address"].ToString());
                        //HttpContext.Session.SetString("CountryID", dr["CountryID"].ToString());
                        //HttpContext.Session.SetString("StateID", dr["StateID"].ToString());
                        //HttpContext.Session.SetString("CityID", dr["CityID"].ToString());
                        //HttpContext.Session.SetString("Phone", dr["Phone"].ToString());
                        //HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        //HttpContext.Session.SetString("Gender", dr["Gender"].ToString());
                        //HttpContext.Session.SetString("Description", dr["Description"].ToString());
                        HttpContext.Session.SetString("CreationDate", dr["CreationDate"].ToString());
                        HttpContext.Session.SetString("ModificationDate", dr["ModificationDate"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is inviald!";
                    return RedirectToAction("LoginPage");
                }

                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    if(CV.RoleTypeID() == "1")
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }



            }

            return RedirectToAction("LoginPage");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult OpenSignUp()
        {
            return View("SignUpPage");
        }


    }
}
