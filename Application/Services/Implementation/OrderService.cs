using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int Insert(OrderDTO entity)
        {
            var order = new Order()
            {
                CreatedAt = DateTime.Now,
                Description = entity.Description,
                Total = entity.Total,
                UserId = entity.UserId
            };
            _unitOfWork.Order.Add(order);
            return order.Id;
        }

        public void Update(OrderDTO entity, int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(OrderDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public OrderDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<OrderDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PageResponse<OrderDTO> Execute(OrderSearch request)
        {
            var query = _unitOfWork.Order.Find(o => o.UserId == request.UserId);
            
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