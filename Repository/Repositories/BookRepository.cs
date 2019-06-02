using System;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        {
        }
        
        public LibraryContext LibraryContext
        {
            get { return _context as LibraryContext; }
        }
    }
}