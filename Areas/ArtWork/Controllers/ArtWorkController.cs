using Artefy.Areas.ArtWork.Models;
using Artefy.Areas.ArtSubType.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using static Artefy.Areas.ArtType.Models.ArtTypeModel;
using Artefy.Areas.RoleType.Models;
using Artefy.Areas.User.Models;

namespace Artefy.Areas.ArtWork.Controllers
{
    [Area("ArtWork")]
    [Route("ArtWork/[Controller]/[action]")]
    public class ArtWorkController : Controller
    {

        private IConfiguration Configuration;

        public ArtWorkController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        ART_DAL dalART = new ART_DAL();
        ArtWorkModel modelArtWork = new ArtWorkModel();


        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalART.ArtWork_SelectAll();
            return View("ArtWorkList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ArtWorkID)
        {

            if (Convert.ToBoolean(dalART.ArtWork_Delete(ArtWorkID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? ArtWorkID)
        {

            #region DropDown

            #region UserDD


            DataTable dtUser = dalART.User_SelectByDropdownList();

            List<UserDropDown> userdropdown = new List<UserDropDown>();

            foreach (DataRow dr in dtUser.Rows)
            {
                UserDropDown dropdown = new UserDropDown();
                dropdown.UserID = (int)dr["UserID"];
                dropdown.UserName = (string)dr["UserName"];
                userdropdown.Add(dropdown);
            }
            ViewBag.UserList = userdropdown;
            #endregion

            #region ArtTypeDD

            DataTable dtArtType = dalART.ArtType_SelectByDropdownList();

            List<ArtTypeDropDown> ArtTypedropdown = new List<ArtTypeDropDown>();

            foreach (DataRow dr in dtArtType.Rows)
            {
                ArtTypeDropDown dropdown = new ArtTypeDropDown();
                dropdown.ArtTypeID = Convert.ToInt32(dr["ArtTypeID"]);
                dropdown.ArtTypeName = dr["ArtTypeName"].ToString();
                ArtTypedropdown.Add(dropdown);

            }
            ViewBag.ArtTypeList = ArtTypedropdown;
            #endregion

            #region ArtSubTypeDD

            List<ArtSubTypeDropDown> ArtSubTypedropdown = new List<ArtSubTypeDropDown>();
            ViewBag.ArtSubTypeList = ArtSubTypedropdown;

            #endregion


            #endregion


            #region Record Select by Pk
            if (ArtWorkID != null)
            {

                ArtWorkModel modelArtWork = dalART.ArtWorkSelectByPk((int)ArtWorkID);
                DropDownByArtType(modelArtWork.ArtTypeID);
                return View("ArtWorkAddEdit", modelArtWork);

            }
            #endregion

            return View("ArtWorkAddEdit");
        } 
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult Save(ArtWorkModel modelArtWork)
        {

            if (modelArtWork.File != null)
            {
                string FilePath = "wwwroot\\ArtWorkImage";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelArtWork.File.FileName);
                modelArtWork.Image = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelArtWork.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelArtWork.File.CopyTo(stream);
                }
            }


            //if (ModelState.IsValid)
            //{
                if (modelArtWork.ArtWorkID == null)
                {
                    if (Convert.ToBoolean(dalART.ArtWorkInsert(modelArtWork)))

                        TempData["Msg"] = "Record Inserted Successfully";

                }
                else
                {
                    if (Convert.ToBoolean(dalART.ArtWorkUpdate(modelArtWork)))
                        return RedirectToAction("Index");
                }
            //}

            return RedirectToAction("Add");

        }
        #endregion

        #region DropDownByArtType
        public IActionResult DropDownByArtType(int? ArtTypeID)
        {
            string str = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_ArtSubType_SelectDropDownByArtTypeID";
            cmd.Parameters.Add("@ArtTypeID", SqlDbType.Int).Value = ArtTypeID;
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();

            dt.Load(sdr);
            conn.Close();

            List<ArtSubTypeDropDown> list = new List<ArtSubTypeDropDown>();

            foreach (DataRow dr in dt.Rows)
            {
                ArtSubTypeDropDown dropdown = new ArtSubTypeDropDown();
                dropdown.ArtSubTypeID = Convert.ToInt32(dr["ArtSubTypeID"]);
                dropdown.ArtSubTypeName = dr["ArtSubTypeName"].ToString();
                list.Add(dropdown);
            }
            ViewBag.ArtSubTypeList = list;
            var vModel = list;
            return Json(vModel);
        }
        #endregion

    }
}
