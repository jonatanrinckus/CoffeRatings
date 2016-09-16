using CoffeRatings.Interfaces;
using CoffeRatings.UWP.Services;
using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteUwp))]

namespace CoffeRatings.UWP.Services
{
    public class SqliteUwp : ISqlite
    {
        public SqliteUwp()
        {
            
        }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Coffee.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
