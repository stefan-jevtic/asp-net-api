using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.DTO;
using Application.Services;
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

        public int RegisterUser(AuthDTO dto)
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
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(AuthDTO dto, int userId)
        {
            var user = Get(userId);
            
            if (!String.IsNullOrEmpty(dto.Email))
            {
                user.Email = dto.Email;
            }
            if (!String.IsNullOrEmpty(dto.FirstName))
            {
                user.FirstName = dto.FirstName;
            }
            if (!String.IsNullOrEmpty(dto.LastName))
            {
                user.LastName = dto.LastName;
            }
            if (!String.IsNullOrEmpty(dto.Password))
            {
                user.Password = AuthMiddleware.ComputeSha256Hash(dto.Password);
            }
            user.ModifiedAt = DateTime.Now;
        }

        public void SoftRemove(int id)
        {
            var user = Get(id);
            user.IsDeleted = 1;
            user.ModifiedAt = DateTime.Now;
        }
    }
}