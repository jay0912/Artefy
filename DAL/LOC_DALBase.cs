using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Artefy.Areas.Country.Models;
using Artefy.Areas.State.Models;
using Artefy.Areas.City.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace Artefy.DAL
{
    public class LOC_DALBase : DALHelper
    {
        
        #region Country

        #region Country_SelectAll
        public DataTable Country_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectAll");
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

        #region Country_Delete
        public bool? Country_Delete(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Country SelectByPk
        public CountryModel CountrySelectByPk(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                CountryModel modelCountry = new CountryModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelCountry.CountryID = Convert.ToInt32(drow["CountryID"]);
                    modelCountry.CountryName = drow["CountryName"].ToString();
                    modelCountry.CountryCode = drow["CountryCode"].ToString();
                    modelCountry.Description = drow["Description"].ToString();
                    modelCountry.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelCountry.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelCountry;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region Country_Insert
        public bool? CountryInsert(CountryModel modelCountry)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_Insert");

                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelCountry.CountryName);
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.NVarChar, modelCountry.CountryCode);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelCountry.Description);
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

        #region Country_Update
        public bool? CountryUpdate(CountryModel modelCountry)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelCountry.CountryID);
                sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelCountry.CountryName);
                sqlDB.AddInParameter(dbCMD, "CountryCode", SqlDbType.NVarChar, modelCountry.CountryCode);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelCountry.Description);
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

        #region State

        #region State_SelectAll
        public DataTable State_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectAll");
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

        #region State_Delete
        public bool? State_Delete(int StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region State_Insert
        public bool? StateInsert(StateModel modelState)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_Insert");

                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelState.StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.NVarChar, modelState.StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelState.CountryID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelState.Description);
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

        #region State_Update
        public bool? StateUpdate(StateModel modelState)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelState.StateID);
                sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelState.StateName);
                sqlDB.AddInParameter(dbCMD, "StateCode", SqlDbType.NVarChar, modelState.StateCode);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelState.CountryID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelState.Description);
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

        #region State_SelectByPK
        public StateModel StateSelectByPk(int? StateID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                StateModel modelState = new StateModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelState.StateID = Convert.ToInt32(drow["StateID"]);
                    modelState.StateName = drow["StateName"].ToString();
                    modelState.StateCode = drow["StateCode"].ToString();
                    modelState.CountryID = Convert.ToInt32(drow["CountryID"]);
                    modelState.Description = drow["Description"].ToString();
                    modelState.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelState.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelState;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region City

        #region City_SelectAll
        public DataTable City_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectAll");
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

        #region City_Delete
        public bool? City_Delete(int CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region City_Insert
        public bool? CityInsert(CityModel modelCity)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_Insert");

                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelCity.CityName);
                sqlDB.AddInParameter(dbCMD, "CityCode", SqlDbType.NVarChar, modelCity.CityCode);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelCity.StateID);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelCity.CountryID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelCity.Description);
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

        #region City_Update
        public bool? CityUpdate(CityModel modelCity)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, modelCity.CityID);
                sqlDB.AddInParameter(dbCMD, "CityName", SqlDbType.NVarChar, modelCity.CityName);
                sqlDB.AddInParameter(dbCMD, "CityCode", SqlDbType.NVarChar, modelCity.CityCode);
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, modelCity.StateID);
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, modelCity.CountryID);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelCity.Description);
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

        #region City_SelectByPK
        public CityModel CitySelectByPk(int? CityID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CityID", SqlDbType.Int, CityID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                CityModel modelCity = new CityModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelCity.CountryID = Convert.ToInt32(drow["CountryID"]);
                    modelCity.StateID = Convert.ToInt32(drow["StateID"]);
                    modelCity.CityID = Convert.ToInt32(drow["CityID"]);
                    modelCity.CityName = drow["CityName"].ToString();
                    modelCity.CityCode = drow["CityCode"].ToString();
                    modelCity.Description = drow["Description"].ToString();
                    modelCity.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelCity.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelCity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        //this is country drop down used in state and city
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

        #region State_SelectbyDropdown
        public DataTable State_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectForDropDown");
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
