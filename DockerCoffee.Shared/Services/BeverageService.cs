using DockerCoffee.Shared.Contracts;
using DockerCoffee.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerCoffee.Shared.Services
{
    public class BeverageService : IBeverageService
    {
        private readonly CoffeeDbContext _coffeeDbContext;

        public BeverageService(CoffeeDbContext coffeeDbContext)
        {
            _coffeeDbContext = coffeeDbContext;
        }

        public List<Beverage> GetAll()
        {
            return _coffeeDbContext.Beverages.ToList();
        }
    }
}
