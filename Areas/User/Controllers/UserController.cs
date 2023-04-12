using Artefy.Areas.City.Models;
using Artefy.Areas.State.Models;
using Artefy.Areas.User.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Artefy.Areas.Country.Models;
using Artefy.Areas.RoleType.Models;

namespace Artefy.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[Controller]/[action]")]
    public class UserController : Controller
    {

        private IConfiguration Configuration;

        public UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        SEC_DAL dalSEC = new SEC_DAL();
        UserModel modelUser = new UserModel();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalSEC.User_SelectAll();
            return View("UserList", dt);
        }
        #endregion

        #region Customer SelectAll
        public IActionResult Customer()
        {
            DataTable dt = dalSEC.Customer_SelectAll();
            return View("CustomerList", dt);
        }
        #endregion

        #region Artist SelectAll
        public IActionResult Artist()
        {
            DataTable dt = dalSEC.Artist_SelectAll();
            return View("ArtistList", dt);
        }
        #endregion


        #region Delete
        public IActionResult Delete(int UserID)
        {
            if (Convert.ToBoolean(dalSEC.User_Delete(UserID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? UserID)
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

            #region Record Select by Pk
            if (UserID != null)
            {

                UserModel modelUser = dalSEC.UserSelectByPk((int)UserID);
                DropDownByCountry(modelUser.CountryID);
                DropDownByState(modelUser.StateID);
                return View("UserAddEdit", modelUser);

            }
            #endregion

        
            return View("UserAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(UserModel modelUser)
        {

            if (modelUser.File != null)
            {
                string FilePath = "wwwroot\\ProfilePic";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelUser.File.FileName);
                modelUser.ProfilePic = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelUser.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelUser.File.CopyTo(stream);
                }
            }


            if (ModelState.IsValid)
            {
                if (modelUser.UserID == null)
                {
                    if (Convert.ToBoolean(dalSEC.UserInsert(modelUser)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalSEC.UserUpdate(modelUser)))
                        return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Add");
            
        }
        #endregion

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


        #region SignUpAdd
        public IActionResult SignUpAdd()
        {
            UserModel modelUser = new UserModel();

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
            
            DropDownByCountry(modelUser.CountryID);
            DropDownByState(modelUser.StateID);


            return View("SignUpPage");
        }
        #endregion

    }
}
