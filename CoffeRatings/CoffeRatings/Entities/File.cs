using SQLite;

namespace CoffeRatings.Entities
{
    public class File
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
