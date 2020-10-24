using DockerCoffee.Shared.Contracts;
using DockerCoffee.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerCoffee.Shared.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly CoffeeDbContext _coffeeDbContext;

        public OrderService(ILogger<OrderService> logger, CoffeeDbContext coffeeDbContext)
        {
            _logger = logger;
            _coffeeDbContext = coffeeDbContext;
        }

        public List<Order> GetAll()
        {
            return _coffeeDbContext.Orders
                .Include(o => o.Beverage)
                .ToList();
        }

        public bool PlaceOrder(int beverageId, string customer)
        {
            try
            { 
                var beverage = _coffeeDbContext.Beverages.Find(beverageId);
                if (beverage == null || beverage.Stock <= 0) return false;

                beverage.Stock--;

                _coffeeDbContext.Orders.Add(new Order()
                {
                    Beverage = beverage,
                    Customer = customer
                });

                _coffeeDbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to place order.");
                return false;
            }
        }
    }
}
