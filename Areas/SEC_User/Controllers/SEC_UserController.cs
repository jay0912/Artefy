using Artefy.Areas.City.Models;
using Artefy.Areas.Country.Models;
using Artefy.Areas.RoleType.Models;
using Artefy.Areas.SEC_User.Models;
using Artefy.Areas.State.Models;
using Artefy.Areas.User.Models;
using Artefy.BAL;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Artefy.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[Controller]/[action]")]
    public class SEC_UserController : Controller
    {

        private IConfiguration Configuration;

        public SEC_UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }


        SEC_DAL dalSEC = new SEC_DAL();
        SEC_UserModel modelSEC = new SEC_UserModel();
        

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
            #region DropDown

            #region RoleTypeDD


            DataTable dtRole = dalSEC.RoleType_SelectByDropdownList();

            List<RoleTypeDropDown> roletypedropdown = new List<RoleTypeDropDown>();

            foreach (DataRow dr in dtRole.Rows)
            {
                RoleTypeDropDown dropdown = new RoleTypeDropDown();
                dropdown.RoleTypeID = Convert.ToInt32(dr["RoleTypeID"]);
                dropdown.RoleTypeName = dr["RoleTypeName"].ToString();
                roletypedropdown.Add(dropdown);
            }
            ViewBag.RoleTypeList = roletypedropdown;
            #endregion

            #region CityDD

            List<CityDropDown> citydropdown = new List<CityDropDown>();

            ViewBag.CityList = citydropdown;
            #endregion

            #region StateDD

            List<StateDropDown> statedropdown = new List<StateDropDown>();

            ViewBag.StateList = statedropdown;
            #endregion

            #region CountryDD
            DataTable dt1 = dalSEC.Country_SelectByDropdownList();

            List<CountryDropDown> countrydropdown = new List<CountryDropDown>();

            foreach (DataRow dr in dt1.Rows)
            {
                CountryDropDown dropdown = new CountryDropDown();
                dropdown.CountryID = (int)dr["CountryID"];
                dropdown.CountryName = (string)dr["CountryName"];
                countrydropdown.Add(dropdown);
            }
            ViewBag.CountryList = countrydropdown;
            #endregion

            #endregion

            return View("SignUpPage");
        }


        #region DropDownByCountry
        public IActionResult DropDownByCountry(int? CountryID)
        {

            string str = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_State_SelectDropDownByCountryID";
            cmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = CountryID;
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            conn.Close();

            List<StateDropDown> list = new List<StateDropDown>();

            foreach (DataRow dr in dt.Rows)
            {
                StateDropDown dropdown = new StateDropDown();
                dropdown.StateID = Convert.ToInt32(dr["StateID"]);
                dropdown.StateName = dr["StateName"].ToString();
                list.Add(dropdown);
            }
            ViewBag.StateList = list;
            var vModel = list;
            return Json(vModel);
        }
        #endregion

        #region DropDownByState
        public IActionResult DropDownByState(int? StateID)
        {
            string str = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_City_SelectDropDownByStateID";
            cmd.Parameters.Add("@StateID", SqlDbType.Int).Value = StateID;
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            conn.Close();

            List<CityDropDown> list = new List<CityDropDown>();

            foreach (DataRow dr in dt.Rows)
            {
                CityDropDown dropdown = new CityDropDown();
                dropdown.CityID = Convert.ToInt32(dr["CityID"]);
                dropdown.CityName = dr["CityName"].ToString();
                list.Add(dropdown);
            }
            ViewBag.CityList = list;
            var vModel = list;
            return Json(vModel);
        }
        #endregion


    }
}
