using SQLite;
using System;

namespace CoffeRatings.Entities
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }

        public string GetDescription => string.IsNullOrEmpty(Address?.Name) ? Description : $"{Description} on {Address.Name}";

        private DateTime _consumptionDateTime;
        public DateTime ConsumptionDateTime
        {
            get { return _consumptionDateTime.ToLocalTime(); }
            set { _consumptionDateTime = value; }
        }

        public int AddressId { get; set; }

        [Ignore]
        public Address Address { get; set; }


        public int ImageId { get; set; }

        [Ignore]
        public File Image { get; set; }
    }
}
