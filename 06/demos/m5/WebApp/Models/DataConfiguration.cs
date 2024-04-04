namespace WebApp.Models
{
    public class DataConfiguration : System.Data.Entity.DbConfiguration
    {
        public DataConfiguration()
        {
             SetDatabaseInitializer(new DbContextInitializer());
        }
    }
}
