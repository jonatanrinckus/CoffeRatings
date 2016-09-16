using CoffeRatings.Droid.Services;
using CoffeRatings.Interfaces;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteDroid))]

namespace CoffeRatings.Droid.Services
{
    public class SqliteDroid : ISqlite
    {
        public SqliteDroid()
        {
            
        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Coffee.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            
            // Return the database connection
            return conn;
        }
    }
}
