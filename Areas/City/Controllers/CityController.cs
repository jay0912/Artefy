using Artefy.Areas.City.Models;
using Artefy.Areas.Country.Models;
using Artefy.Areas.State.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Artefy.Areas.City.Controllers
{
    [Area("City")]
    [Route("City/[Controller]/[action]")]
    public class CityController : Controller
    {
        private IConfiguration Configuration;

        public CityController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        LOC_DAL dalLOC = new LOC_DAL();
        CityModel modelCity = new CityModel();

        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalLOC.City_SelectAll();
            return View("CityList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CityID)
        {

            if (Convert.ToBoolean(dalLOC.City_Delete(CityID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? CityID)
        {
            
            #region DropDown

            #region CountryDD

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

            #region StateDD

            List<StateDropDown> statedropdown = new List<StateDropDown>();
            ViewBag.StateList = statedropdown;

            #endregion


            #endregion


            #region Record Select by Pk
            if (CityID != null)
            {

                CityModel modelCity = dalLOC.CitySelectByPk((int)CityID);
                DropDownByCountry(modelCity.CountryID);
                return View("CityAddEdit", modelCity);

            }
            #endregion

            return View("CityAddEdit");
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(CityModel modelCity)
        {

            if (ModelState.IsValid)
            {
                if (modelCity.CityID == null)
                {
                    if (Convert.ToBoolean(dalLOC.CityInsert(modelCity)))
                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalLOC.CityUpdate(modelCity)))
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

    }
}
