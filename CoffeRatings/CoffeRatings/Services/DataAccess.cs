using CoffeRatings.Entities;
using CoffeRatings.Interfaces;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CoffeRatings.Services
{
    public class DataAccess
    {
        private readonly SQLiteConnection _db;

        public DataAccess()
        {
            _db = DependencyService.Get<ISqlite>().GetConnection();
            _db.CreateTable<Coffee>();
            _db.CreateTable<File>();
            _db.CreateTable<Address>();
        }

        public ObservableCollection<Coffee> GetAllCoffeesAsObservableCollection()
        {
            var coffes = _db.Table<Coffee>().OrderBy(c => c.ConsumptionDateTime).ToList();

            var observableCoffee = new ObservableCollection<Coffee>();

            foreach (var coffee in coffes)
            {
                coffee.Address = _db.Table<Address>().FirstOrDefault(a => a.Id == coffee.AddressId);
                coffee.Image = _db.Table<File>().FirstOrDefault(i => i.Id == coffee.ImageId);
                observableCoffee.Add(coffee);
            }

            return (observableCoffee);

        }


        public void AddCoffee(Coffee coffee)
        {
            if (coffee == null)
                return;


            if (coffee.Address != null)
            {
                _db.Insert(coffee.Address);

                coffee.AddressId = coffee.Address.Id;
            }
            if (coffee.Image != null)
            {
                _db.Insert(coffee.Image);

                coffee.ImageId = coffee.ImageId;
            }


            _db.Insert(coffee);

        }

        public Coffee GetCoffee(int id)
        {
            var coffee =
            _db.Table<Coffee>().FirstOrDefault(c => c.Id == id);

            coffee.Address = _db.Table<Address>().FirstOrDefault(a => a.Id == coffee.AddressId);
            coffee.Image = _db.Table<File>().FirstOrDefault(a => a.Id == coffee.ImageId);

            return coffee;

        }

        public int DeleteCoffee(int id)
        {
            return _db.Delete<Coffee>(id);
        }


        public ObservableCollection<Coffee> SearchCoffeeByDateTime(DateTime fromDateTime, DateTime toDateTime)
        {
            var coffes = _db.Table<Coffee>()
                .OrderBy(c => c.ConsumptionDateTime)
                .Where(c => c.ConsumptionDateTime >= fromDateTime && c.ConsumptionDateTime <= toDateTime)
                .ToList();

            var observableCoffee = new ObservableCollection<Coffee>();

            foreach (var coffee in coffes)
            {
                coffee.Address = _db.Table<Address>().FirstOrDefault(a => a.Id == coffee.AddressId);
                coffee.Image = _db.Table<File>().FirstOrDefault(i => i.Id == coffee.ImageId);
                observableCoffee.Add(coffee);
            }

            return observableCoffee;
        }

        public void UpdateCoffee(Coffee coffee)
        {
            _db.Update(coffee.Address);
            _db.Update(coffee);

        }
    }
}
