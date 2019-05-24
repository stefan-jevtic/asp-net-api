using System;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public void InsertOrder(int id, string desc, double total)
        {
            var order = new Order()
            {
                CreatedAt = DateTime.Now,
                Description = desc,
                Total = total,
                UserId = id
            };
            _context.Add(order);
        }
    }

}