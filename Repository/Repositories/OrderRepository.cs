using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
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

        public PageResponse<OrderDTO> Execute(OrderSearch request)
        {
            var query = Find(o => o.UserId == request.UserId);
            
            if(request.MinTotal.HasValue)
            {
                query = query.Where(o => o.Total>= request.MinTotal);
            }
            if(request.MaxTotal.HasValue)
            {
                query = query.Where(o => o.Total<= request.MaxTotal);
            }
            
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var response = new PageResponse<OrderDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(o => new OrderDTO()
                {
                    Id = o.Id,
                    Total = o.Total,
                    Description = o.Description
                })
            };
            return response;
        }
    }

}