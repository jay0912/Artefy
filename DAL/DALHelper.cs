namespace Artefy.DAL
{
    public class DALHelper
    {
        #region DataBase Connection String

        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");

        #endregion
    }
}
