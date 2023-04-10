using Artefy.Areas.Country.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Artefy.Areas.PaymentMode.Models;

namespace Artefy.DAL
{
    public class BUY_DALBase : DALHelper
    {

        #region PaymentMode

        #region PaymentMode_SelectAll
        public DataTable PaymentMode_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_SelectAll");
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

        #region PaymentMode_Delete
        public bool? PaymentMode_Delete(int PaymentModeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "PaymentModeID", SqlDbType.Int, PaymentModeID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PaymentMode SelectByPk
        public PaymentModeModel PaymentModeSelectByPk(int PaymentModeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "PaymentModeID", SqlDbType.Int, PaymentModeID);
                //sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                PaymentModeModel modelPaymentMode = new PaymentModeModel();

                foreach (DataRow drow in dt.Rows)
                {
                    modelPaymentMode.PaymentModeID = Convert.ToInt32(drow["PaymentModeID"]);
                    modelPaymentMode.PaymentModeName = drow["PaymentModeName"].ToString();
                    modelPaymentMode.Description = drow["Description"].ToString();
                    modelPaymentMode.CreationDate = Convert.ToDateTime(drow["CreationDate"]);
                    modelPaymentMode.ModificationDate = Convert.ToDateTime(drow["ModificationDate"]);

                }

                return modelPaymentMode;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region PaymentMode_Insert
        public bool? PaymentModeInsert(PaymentModeModel modelPaymentMode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_Insert");

                sqlDB.AddInParameter(dbCMD, "PaymentModeName", SqlDbType.NVarChar, modelPaymentMode.PaymentModeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelPaymentMode.Description);
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

        #region PaymentMode_Update
        public bool? PaymentModeUpdate(PaymentModeModel modelPaymentMode)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "PaymentModeID", SqlDbType.Int, modelPaymentMode.PaymentModeID);
                sqlDB.AddInParameter(dbCMD, "PaymentModeName", SqlDbType.NVarChar, modelPaymentMode.PaymentModeName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelPaymentMode.Description);
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
