using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Artefy.Areas.ArtType.Models;
using Artefy.Areas.ArtSubType.Models;
using Artefy.Areas.ArtWork.Models;

namespace Artefy.DAL
{
    public class ART_DALBase : DALHelper
    {

        #region ArtWork

        #region ArtWork_SelectAll
        public DataTable ArtWork_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_SelectAll");
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

        #region ArtWork_Delete
        public bool? ArtWork_Delete(int ArtWorkID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ArtWorkID", SqlDbType.Int, ArtWorkID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ArtWork_Insert
        public bool? ArtWorkInsert(ArtWorkModel modelArtWork)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_Insert");

                sqlDB.AddInParameter(dbCMD, "Image", SqlDbType.NVarChar, modelArtWork.Image);
                sqlDB.AddInParameter(dbCMD, "Title", SqlDbType.NVarChar, modelArtWork.Title);
                sqlDB.AddInParameter(dbCMD, "ArtNo", SqlDbType.NVarChar, modelArtWork.ArtNo);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, modelArtWork.UserID);
                sqlDB.AddInParameter(dbCMD, "Height", SqlDbType.NVarChar, modelArtWork.Height);
                sqlDB.AddInParameter(dbCMD, "Width", SqlDbType.NVarChar, modelArtWork.Width);
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, modelArtWork.ArtTypeID);
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeID", SqlDbType.Int, modelArtWork.ArtSubTypeID);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.NVarChar, modelArtWork.Price);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtWork.Description);
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

        #region ArtWork_Update
        public bool? ArtWorkUpdate(ArtWorkModel modelArtWork)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "ArtWorkID", SqlDbType.Int, modelArtWork.ArtWorkID);
                sqlDB.AddInParameter(dbCMD, "Image", SqlDbType.NVarChar, modelArtWork.Image);
                sqlDB.AddInParameter(dbCMD, "Title", SqlDbType.NVarChar, modelArtWork.Title);
                sqlDB.AddInParameter(dbCMD, "ArtNo", SqlDbType.NVarChar, modelArtWork.ArtNo);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, modelArtWork.UserID);
                sqlDB.AddInParameter(dbCMD, "Height", SqlDbType.NVarChar, modelArtWork.Height);
                sqlDB.AddInParameter(dbCMD, "Width", SqlDbType.NVarChar, modelArtWork.Width);
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, modelArtWork.ArtTypeID);
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeID", SqlDbType.Int, modelArtWork.ArtSubTypeID);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.NVarChar, modelArtWork.Price);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtWork.Description);
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

        #region ArtWork_SelectByPK
        public ArtWorkModel ArtWorkSelectByPk(int? ArtWorkID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ArtWorkID", SqlDbType.Int, ArtWorkID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                ArtWorkModel modelArtWork = new ArtWorkModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelArtWork.Image = drow["Image"].ToString();
                    modelArtWork.Title = drow["Title"].ToString();
                    modelArtWork.ArtNo = drow["ArtNo"].ToString();
                    modelArtWork.UserID = Convert.ToInt32(drow["UserID"]);
                    modelArtWork.Height = Convert.ToDecimal(drow["Height"]);
                    modelArtWork.Width = Convert.ToDecimal(drow["Width"]);
                    modelArtWork.ArtTypeID = Convert.ToInt32(drow["ArtTypeID"]);
                    modelArtWork.ArtSubTypeID = Convert.ToInt32(drow["ArtSubTypeID"]);
                    modelArtWork.Price = Convert.ToDecimal(drow["Price"]);
                    modelArtWork.Description = drow["Description"].ToString();
                    modelArtWork.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelArtWork.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelArtWork;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion


        #region ArtType

        #region ArtType_SelectAll
        public DataTable ArtType_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_SelectAll");
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

        #region ArtType_Delete
        public bool? ArtType_Delete(int ArtTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, ArtTypeID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ArtType SelectByPk
        public ArtTypeModel ArtTypeSelectByPk(int ArtTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, ArtTypeID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                ArtTypeModel modelArtType = new ArtTypeModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelArtType.ArtTypeID = Convert.ToInt32(drow["ArtTypeID"]);
                    modelArtType.ArtTypeName = drow["ArtTypeName"].ToString();
                    modelArtType.Description = drow["Description"].ToString();
                    modelArtType.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelArtType.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelArtType;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region ArtType_Insert
        public bool? ArtTypeInsert(ArtTypeModel modelArtType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_Insert");

                sqlDB.AddInParameter(dbCMD, "ArtTypeName", SqlDbType.NVarChar, modelArtType.ArtTypeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtType.Description);
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

        #region ArtType_Update
        public bool? ArtTypeUpdate(ArtTypeModel modelArtType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, modelArtType.ArtTypeID);
                sqlDB.AddInParameter(dbCMD, "ArtTypeName", SqlDbType.NVarChar, modelArtType.ArtTypeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtType.Description);
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


        #region ArtSubType

        #region ArtSubType_SelectAll
        public DataTable ArtSubType_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtSubType_SelectAll");
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

        #region ArtSubType_Delete
        public bool? ArtSubType_Delete(int ArtSubTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtSubType_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeID", SqlDbType.Int, ArtSubTypeID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region ArtSubType_Insert
        public bool? ArtSubTypeInsert(ArtSubTypeModel modelArtSubType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtSubType_Insert");

                sqlDB.AddInParameter(dbCMD, "ArtSubTypeName", SqlDbType.NVarChar, modelArtSubType.ArtSubTypeName);
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, modelArtSubType.ArtTypeID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtSubType.Description);
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

        #region ArtSubType_Update
        public bool? ArtSubTypeUpdate(ArtSubTypeModel modelArtSubType)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtSubType_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeID", SqlDbType.Int, modelArtSubType.ArtSubTypeID);
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeName", SqlDbType.NVarChar, modelArtSubType.ArtSubTypeName);
                sqlDB.AddInParameter(dbCMD, "ArtTypeID", SqlDbType.Int, modelArtSubType.ArtTypeID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelArtSubType.Description);
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

        #region ArtSubType_SelectByPK
        public ArtSubTypeModel ArtSubTypeSelectByPk(int? ArtSubTypeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtSubType_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ArtSubTypeID", SqlDbType.Int, ArtSubTypeID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                ArtSubTypeModel modelArtSubType = new ArtSubTypeModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelArtSubType.ArtSubTypeID = Convert.ToInt32(drow["ArtSubTypeID"]);
                    modelArtSubType.ArtSubTypeName = drow["ArtSubTypeName"].ToString();
                    modelArtSubType.ArtTypeID = Convert.ToInt32(drow["ArtTypeID"]);
                    modelArtSubType.Description = drow["Description"].ToString();
                    modelArtSubType.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelArtSubType.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelArtSubType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion


        #region ArtType_SelectbyDropdown
        public DataTable ArtType_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtType_SelectForDropDown");
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


        #region User_SelectbyDropdown
        public DataTable User_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_User_SelectForDropDown");
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


        #region ArtWork_ViewDetail
        public DataTable ArtWork_ViewDetail(int? ArtWorkID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ArtWork_ViewDetail");
                sqlDB.AddInParameter(dbCMD, "ArtWorkID", SqlDbType.Int, ArtWorkID);
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
    }
}
