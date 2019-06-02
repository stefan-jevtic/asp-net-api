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
    public class BookService : IBookService
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 

        public int Insert(BookDTO dto)
        {
            var book = new Book()
            {
                Title = dto.Title,
                Description = dto.Description,
                Pages = dto.Pages,
                Price = dto.Price,
                CreatedAt = DateTime.Now,
                CategoryId = dto.CategoryId,
                AuthorId = dto.AuthorId,
                Image = dto.ImageUrl
            };
            _unitOfWork.Book.Add(book);
            _unitOfWork.Save();
            return book.Id;
        }

        public void Update(BookDTO dto, int id)
        {
            var book = _unitOfWork.Book.Get(id);
            book.Title = dto.Title;
            book.Description = dto.Description;
            book.Price = dto.Price;
            book.Pages = dto.Pages;
            book.CategoryId = dto.CategoryId;
            book.AuthorId = dto.AuthorId;
            book.ModifiedAt = DateTime.Now;
            if (dto.ImageUrl != null)
            {
                book.Image = dto.ImageUrl;   
            }
            _unitOfWork.Save();
        }

        public void Delete(BookDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            var book = _unitOfWork.Book.Get(id);
            _unitOfWork.Book.Remove(book);
            _unitOfWork.Save();
        }

        public BookDTO GetById(int id)
        {
            var book = _unitOfWork.Book.FindByExp(d => d.Id == id).Select(d => new BookDTO()
            {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                Pages = d.Pages,
                Price = d.Price,
                CategoryName = d.Category.Name,
                AuthorName = d.Author.FullName,
                ImageUrl = d.Image
            }).FirstOrDefault();
            return book;
        }

        public IQueryable<BookDTO> GetAll()
        {
            var bookes = _unitOfWork.Book.GetAll().Select(d => new BookDTO() {
                Id = d.Id,
                Title = d.Title,
                Description = d.Description,
                Pages = d.Pages,
                Price = d.Price,
                CategoryName = d.Category.Name,
                AuthorName = d.Author.FullName,
                ImageUrl = d.Image
            });
            return bookes;
        }

        public PageResponse<BookDTO> Execute(BookSearch request)
        {
            var query = _unitOfWork.Book.GetAll();
            
            if(request.MinPrice.HasValue)
            {
                query = query.Where(d => d.Price >= request.MinPrice);
            }
            if(request.MaxPrice.HasValue)
            {
                query = query.Where(d => d.Price <= request.MaxPrice);
            }
            if(request.MinPages.HasValue)
            {
                query = query.Where(d => d.Pages >= request.MinPages);
            }
            if(request.MaxPages.HasValue)
            {
                query = query.Where(d => d.Pages <= request.MaxPages);
            }
            if(request.Title != null)
            {
                var keyword = request.Title.ToLower();
                query = query.Where(d => d.Title.ToLower().Contains(keyword));
            }
            if(request.CategoryId != null)
            {
                query = query.Where(d => d.CategoryId == request.CategoryId);
            }
            if(request.AuthorId != null)
            {
                query = query.Where(d => d.AuthorId == request.AuthorId);
            }
            
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);
            
            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);
            var response = new PageResponse<BookDTO>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pagesCount,
                Data = query.Select(d => new BookDTO()
                {
                    Id = d.Id,
                    Title = d.Title,
                    Price = d.Price,
                    Description = d.Description,
                    Pages = d.Pages,
                    CategoryName = d.Category.Name,
                    AuthorName = d.Author.FullName,
                    ImageUrl = d.Image
                })
            };
            return response;
        }
    }
}