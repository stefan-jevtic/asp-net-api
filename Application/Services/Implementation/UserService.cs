using System;
using System.Linq;
using Application.DTO;
using Application.Responses;
using Application.Searches;
using Application.Services.Interfaces;
using Domain;
using Microsoft.Extensions.Configuration;
using Repository.UnitOfWork;

namespace Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        
        public int Insert(AuthDTO data)
        {
            if (String.IsNullOrEmpty(data.FirstName))
            {
                throw new Exception("First name field is required!");
            }
            
            if (String.IsNullOrEmpty(data.LastName))
            {
                throw new Exception("Last name field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Email))
            {
                throw new Exception("Email field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Password))
            {
                throw new Exception("Password field is required!");
            }

            if (!data.Email.Contains("@"))
            {
                throw new Exception("Enter valid email!");
            }

            data.Password = AuthMiddleware.ComputeSha256Hash(data.Password);
            var user = new User()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = data.Password,
                RoleId = 2
            };
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            var wallet = new Wallet()
            {
                Balance = 0,
                UserId = user.Id
            };
            _unitOfWork.Wallet.Add(wallet);
            _unitOfWork.Save();
            return user.Id;
        }

        public void Update(AuthDTO dto, int id)
        {
            var user = _unitOfWork.User.Get(id);
            
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
            if (dto.IsDeleted == 0 || dto.IsDeleted == 1)
            {
                user.IsDeleted = dto.IsDeleted;
            }
            user.ModifiedAt = DateTime.Now;
            _unitOfWork.Save();
        }

        public void Delete(AuthDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var user = _unitOfWork.User.Get(id);
            user.IsDeleted = 1;
            user.ModifiedAt = DateTime.Now;
            _unitOfWork.Save();
        }

        public AuthDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AuthDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PageResponse<TransactionDTO> Execute(TransactionSearch request)
        {
            var query = _unitOfWork.Transaction.Find(t => t.WalletId == request.WalletId);
            
            if(request.MinAmount.HasValue)
            {
                query = query.Where(t => t.Amount >= request.MinAmount);
            }
            if(request.MaxAmount.HasValue)
            {
                query = query.Where(t => t.Amount<= request.MaxAmount);
            }
            if(request.Type != null)
            {
                var keyword = request.Type.ToLower();
                query = query.Where(d => d.Type.ToLower().Contains(keyword));
            }
            
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var response = new PageResponse<TransactionDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(t => new TransactionDTO()
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Type = t.Type
                })
            };
            return response;
        }

        public PageResponse<TransactionDTO> GetTransactions(TransactionSearch search, int userId)
        {
            var wallet = _unitOfWork.Wallet.Find(w => w.UserId == userId).FirstOrDefault();
            search.WalletId = wallet.Id;
            var transactions = Execute(search);
            return transactions;
        }

        public string Login(AuthDTO data, IConfiguration config)
        {
            var token = "No token!";
            
            if (String.IsNullOrEmpty(data.Email))
            {
                throw new Exception("Email field is required!");
            }
            
            if (String.IsNullOrEmpty(data.Password))
            {
                throw new Exception("Password field is required!");
            }
            
            if (!data.Email.Contains("@"))
            {
                throw new Exception("Enter valid email!");
            }

            var pass = AuthMiddleware.ComputeSha256Hash(data.Password);
            var user = _unitOfWork.User.Find(u => u.Email == data.Email && u.Password == pass && u.IsDeleted == 0).FirstOrDefault();
            
            if (user != null)
            {
                token = AuthMiddleware.GenerateJsonWebToken(user, config);
                return token;
            }
            throw new Exception("User not found!");
        }
    }
}