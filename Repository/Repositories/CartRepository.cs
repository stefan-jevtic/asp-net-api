using System.Linq;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(DbContext context) : base(context)
        {
        }
        
        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public void InsertInCart(int userId, int dishId, int quantity, double sum)
        {
            var cart = new Cart()
            {
                UserId = userId,
                DishId = dishId,
                Quantity = quantity,
                Sum = sum
            };
            _context.Add(cart);
        }

        public int DeleteFromCart(int userId, int id)
        {
            var cart = Find(c => c.Id == id && c.UserId == userId).FirstOrDefault();
            if (cart == null)
            {
                return 0;
            }
            _context.Remove(cart);
            return 1;
        }
    }
}