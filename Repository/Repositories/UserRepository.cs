using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTO;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RestaurantContext context) : base(context)
        {
            
        }

        public RestaurantContext RestaurantContext
        {
            get { return _context as RestaurantContext; }
        }

        public void RegisterUser(AuthDTO dto)
        {
            var user = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                RoleId = 2
            };

            _context.Add(user);
        }
    }
}