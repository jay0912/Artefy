using Artefy.Areas.RoleType.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Artefy.Areas.ArtWork.Models;
using Artefy.Areas.User.Models;

namespace Artefy.DAL
{
    public class SEC_DALBase : DALHelper
    {
        public DataTable PR_SEC_User_SelectByUserNamePassword(string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByUserNamePassword");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #region User

        #region User_SelectAll
        public DataTable User_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectAll");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Customer_SelectAll
        public DataTable Customer_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Display_Customer");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
       
        #region Artist_SelectAll
        public DataTable Artist_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Display_Artist");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region User_Delete
        public bool? User_Delete(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region User_Insert
        public bool? UserInsert(UserModel modelUser)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_Insert");

                sqlDB.AddInParameter(dbCMD, "RoleTypeID", SqlDbType.Int, modelUser.RoleTypeID);
                sqlDB.AddInParameter(dbCMD, "ProfilePic", SqlDbType.NVarChar, modelUser.ProfilePic);
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelUser.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelUser.Password);
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelUser.Address);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelUser.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelUser.StateID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelUser.CityID);
                sqlDB.AddInParameter(dbCMD, "Phone", SqlDbType.NVarChar, modelUser.Phone);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelUser.Email);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelUser.Gender);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelUser.Description);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region User_Update
        public bool? UserUpdate(UserModel modelUser)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, modelUser.UserID);
                sqlDB.AddInParameter(dbCMD, "RoleTypeID", SqlDbType.Int, modelUser.RoleTypeID);
                sqlDB.AddInParameter(dbCMD, "ProfilePic", SqlDbType.NVarChar, modelUser.ProfilePic);
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelUser.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelUser.Password);
                sqlDB.AddInParameter(dbCMD, "BirthDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelUser.Address);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelUser.CountryID);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelUser.StateID);
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelUser.CityID);
                sqlDB.AddInParameter(dbCMD, "Phone", SqlDbType.NVarChar, modelUser.Phone);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelUser.Email);
                sqlDB.AddInParameter(dbCMD, "Gender", SqlDbType.NVarChar, modelUser.Gender);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelUser.Description);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region User_SelectByPK
        public UserModel UserSelectByPk(int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                UserModel modelUser = new UserModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelUser.RoleTypeID = Convert.ToInt32(drow["RoleTypeID"]);
                    modelUser.ProfilePic = drow["ProfilePic"].ToString();
                    modelUser.UserName = drow["UserName"].ToString();
                    modelUser.Password = drow["Password"].ToString();
                    modelUser.BirthDate = Convert.ToDateTime(drow["BirthDate"]);
                    modelUser.Address = drow["Address"].ToString();
                    modelUser.CountryID = Convert.ToInt32(drow["CountryID"]);
                    modelUser.StateID = Convert.ToInt32(drow["StateID"]);
                    modelUser.CityID = Convert.ToInt32(drow["CityID"]);
                    modelUser.Phone = drow["Phone"].ToString();
                    modelUser.Email = drow["Email"].ToString();
                    modelUser.Gender = drow["Gender"].ToString();
                    modelUser.Description = drow["Description"].ToString();
                    modelUser.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelUser.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Country_SelectbyDropdown
        public DataTable Country_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectForDropDown");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region RoleType_SelectbyDropdown
        public DataTable RoleType_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_SelectForDropDown");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        
        #region RoleType

        #region RoleType_SelectAll
        public DataTable RoleType_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_SelectAll");
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();

                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region RoleType_Delete
        public bool? RoleType_Delete(int RoleTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "RoleTypeID", SqlDbType.Int, RoleTypeID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region RoleType SelectByPk
        public RoleTypeModel RoleTypeSelectByPk(int RoleTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "RoleTypeID", SqlDbType.Int, RoleTypeID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                RoleTypeModel modelRoleType = new RoleTypeModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelRoleType.RoleTypeID = Convert.ToInt32(drow["RoleTypeID"]);
                    modelRoleType.RoleTypeName = drow["RoleTypeName"].ToString();
                    modelRoleType.Description = drow["Description"].ToString();
                    modelRoleType.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelRoleType.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelRoleType;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region RoleType_Insert
        public bool? RoleTypeInsert(RoleTypeModel modelRoleType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_Insert");

                sqlDB.AddInParameter(dbCMD, "RoleTypeName", SqlDbType.NVarChar, modelRoleType.RoleTypeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelRoleType.Description);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region RoleType_Update
        public bool? RoleTypeUpdate(RoleTypeModel modelRoleType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_RoleType_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "RoleTypeID", SqlDbType.Int, modelRoleType.RoleTypeID);
                sqlDB.AddInParameter(dbCMD, "RoleTypeName", SqlDbType.NVarChar, modelRoleType.RoleTypeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelRoleType.Description);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("yyyy-MM-dd"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

    }
}
