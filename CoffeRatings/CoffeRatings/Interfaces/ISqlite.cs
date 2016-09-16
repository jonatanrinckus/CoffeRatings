using SQLite;

namespace CoffeRatings.Interfaces
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
