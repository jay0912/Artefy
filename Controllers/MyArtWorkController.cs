using Artefy.Areas.ArtSubType.Models;
using Artefy.Areas.ArtWork.Models;
using Artefy.Areas.User.Models;
using Artefy.DAL;
using Microsoft.AspNetCore.Mvc;
using static Artefy.Areas.ArtType.Models.ArtTypeModel;
using System.Data.SqlClient;
using System.Data;
using Artefy.BAL;

namespace Artefy.Controllers
{
    [CheckAccess]
    public class MyArtWorkController : Controller
    {
        private IConfiguration Configuration;

        public MyArtWorkController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        ART_DAL dalART = new ART_DAL();
        ArtWorkModel modelArtWork = new ArtWorkModel();


        #region SelectAll
        public IActionResult Index()
        {
            DataTable dt = dalART.MyWork_SelectAll();
            return View("MyArtWorkList", dt);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ArtWorkID)
        {

            if (Convert.ToBoolean(dalART.MyWork_Delete(ArtWorkID)))
                return RedirectToAction("Index");
            return View("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? ArtWorkID)
        {

            #region DropDown

            #region ArtistDD


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

                ArtWorkModel modelArtWork = dalART.MyWorkSelectByPk((int)ArtWorkID);
                DropDownByArtType(modelArtWork.ArtTypeID);
                return View("MyArtWorkAddEdit", modelArtWork);

            }
            #endregion

            return View("MyArtWorkAddEdit");
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
                if (Convert.ToBoolean(dalART.MyWorkInsert(modelArtWork)))

                    TempData["Msg"] = "Record Inserted Successfully";

            }
            else
            {
                if (Convert.ToBoolean(dalART.MyWorkUpdate(modelArtWork)))
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
 