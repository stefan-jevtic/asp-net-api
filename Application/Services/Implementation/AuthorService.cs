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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        public int Insert(AuthorDTO entity)
        {
            var author = new Author()
            {
                FullName = entity.FullName,
                CreatedAt = DateTime.Now
            };
            _unitOfWork.Author.Add(author);
            _unitOfWork.Save();
            return author.Id;
        }

        public void Update(AuthorDTO entity, int id)
        {
            var author = _unitOfWork.Author.Find(c => c.Id == id).FirstOrDefault();
            author.FullName = entity.FullName;
            author.ModifiedAt = DateTime.Now;
            _unitOfWork.Save();
        }

        public void Delete(AuthorDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var author = _unitOfWork.Author.Find(c => c.Id == id).FirstOrDefault();
            _unitOfWork.Author.Remove(author);
            _unitOfWork.Save();
        }

        public AuthorDTO GetById(int id)
        {
            var author = _unitOfWork.Author.Find(c => c.Id == id).Select(c => new AuthorDTO()
            {
                Id = c.Id,
                FullName = c.FullName,
                CreatedAt = c.CreatedAt
            }).FirstOrDefault();
            return author;
        }

        public IQueryable<AuthorDTO> GetAll()
        {
            var authors = _unitOfWork.Author.GetAll().Select(d => new AuthorDTO() {
                Id = d.Id,
                FullName = d.FullName,
                CreatedAt = d.CreatedAt
            });
            return authors;
        }

        public PageResponse<AuthorDTO> Execute(AuthorSearch request)
        {
            throw new System.NotImplementedException();
        }
    }
}