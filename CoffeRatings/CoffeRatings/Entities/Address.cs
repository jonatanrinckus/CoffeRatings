using SQLite;

namespace CoffeRatings.Entities
{
    public class Address
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return $"{Street}, nº {Number}, {Neighborhood} {City} ";
        }
    }
}
