using System;
using System.Linq;
using Application.DTO;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _order;
        private readonly ITransactionService _transaction;

        public CartService( IUnitOfWork unitOfWork, IOrderService order, ITransactionService transaction)
        {
            _unitOfWork = unitOfWork;
            _order = order;
            _transaction = transaction;
        }
        public int Insert(CartDTO entity)
        {
            if (entity.Quantity < 1)
            {
                throw new Exception("Please insert positive number for quantity!");
            }
            if (entity.DishId < 1)
            {
                throw new Exception("Please insert positive number for dish!");
            }
            var dish = _unitOfWork.Dish.Get(entity.DishId);
            if (dish == null)
            {
                throw new Exception("Dish not found! Please check our dish list then choose correct dish id!");
            }
            var cart = new Cart()
            {
                UserId = entity.UserId,
                DishId = entity.DishId,
                Quantity = entity.Quantity,
                Sum = entity.Quantity * dish.Price
            };
            _unitOfWork.Cart.Add(cart);
            _unitOfWork.Save();
            return cart.Id;
        }

        public void Update(CartDTO entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(CartDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var item = _unitOfWork.Cart.Get(id);
            _unitOfWork.Cart.Remove(item);
            _unitOfWork.Save();
        }

        public CartDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CartDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CartDTO> ListCart(int id)
        {
            var orders = _unitOfWork.Cart.FindByExp(c => c.UserId == id).Select(c => new CartDTO()
            {
                DishName = c.Dish.Title,
                DishPrice = c.Dish.Price,
                Quantity = c.Quantity,
                Sum = c.Sum
            });
            if (!orders.ToList().Any())
            {
                throw new Exception("Your cart is empty!");
            }
            return orders;
        }

        public void Purchase(int id)
        {
            var items = _unitOfWork.Cart.GetAll().Where(c => c.UserId == id).Select(c => new CartDTO()
            {
                Id = c.Id, 
                DishName = c.Dish.Title, 
                Quantity = c.Quantity, 
                DishPrice = c.Dish.Price, 
                Sum = c.Sum
            }).ToList();
            var overall = 0.0;
            var desc = "Your order: \n";
            
            if (!items.Any())
            {
                throw new Exception("Your cart is empty!");
            }
            foreach (var item in items)
            {
                overall += item.Sum;
                desc += item.DishName + ", " + item.DishPrice + " RSD x " + item.Quantity + " = " + item.Sum + " RSD\n";
            }

            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == id).FirstOrDefault();
            
            if (wallet != null && wallet.Balance < overall)
            {
                throw new Exception("You don't have enough money to pay! Please refill your account!");
            }

            foreach (var item in items)
            {
                DeleteById(item.Id);
            }

            var orderId = _order.Insert(new OrderDTO()
            {
                UserId = id,
                Description = desc,
                Total = overall
            });
            wallet.Balance -= overall;
            _transaction.Insert(new TransactionDTO()
            {
                Amount = overall,
                WalletId = wallet.Id,
                Type = "Output"
            });
            _unitOfWork.Save();
        }
    }
}