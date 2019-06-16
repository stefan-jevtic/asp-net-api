using System;
using System.Collections.Generic;
using Application.Services;
using DataAccess;
using Domain;
using Repository.UnitOfWork;

namespace FakingData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new LibraryContext()))
            {
                #region Faking data

                string[] categories = new string[] { "Biography", "Fiction", "History", "Crime & Thriller", "Sport" };
                string[] authors = new string[] { "Stephen Hawking", "Anne Frank", "Sally Rooney", "Amor Towles", "Adam Higginbotham", "Jonathan Clements", "Michael Connelly", "Denise Mina", "Peter Crouch", "James Witts" };
                foreach (var cat in categories)
                {
                    var category = new Category
                    {
                        Name = cat
                    };
                    
                    unitOfWork.Category.Add(category);
                }
                foreach (var a in authors)
                {
                    var author = new Author()
                    {
                        FullName = a
                    };
                    
                    unitOfWork.Author.Add(author);
                }
                unitOfWork.Save();
                List<Book> books = new List<Book>();
                
                books.Add(new Book(){
                    Title = "Brief Answers to the Big Questions : the final book from Stephen Hawking",
                    Description = "The world-famous cosmologist and #1 bestselling author of A Brief History of Time leaves us with his final thoughts on the universe's biggest questions in this brilliant posthumous work.",
                    Price = 200.00,
                    Pages = 256,
                    AuthorId = 1,
                    Image = "images/da12ebfb0aa48fd8ec52ecb381c0d3c87f2d1fcc2c0feca0a354816fed22b21c.jpg",
                    CategoryId = 1
                });
                books.Add(new Book(){
                    Title = "The Diary of a Young Girl",
                    Description = "For almost fifty years, Anne Frank's diary has moved millions with its testament to the human spirit's indestructibility, but readers have never seen the full text of this beloved book--until now. This new translation, performed by Winona Ryder, restores nearly one third of Anne's entries excised by her father in previous editions, revealing her burgeoning sexuality, her stormy relationship with her mother, and more. ",
                    Price = 250.00,
                    Pages = 283,
                    AuthorId = 2,
                    Image = "images/5b8c161f3152a8408015682be99d1c0d3b71791a78855a8fe4c7a5eaccef1fcf.jpg",
                    CategoryId = 1
                });
                
                books.Add(new Book(){
                    Title = "Normal People",
                    Description = "WINNER OF THE COSTA NOVEL AWARD 2018",
                    Price = 300.00,
                    Pages = 288,
                    AuthorId = 3,
                    Image = "images/4d2b62f7b0d1e808d0433d3cd172f61ee9b282a98e906982f78759e7126a9ded.jpg",
                    CategoryId = 2
                });
                books.Add(new Book(){
                    Title = "A Gentleman in Moscow",
                    Description = "OVER A MILLION COPIES SOLD",
                    Price = 660.00,
                    Pages = 480,
                    AuthorId = 4,
                    Image = "images/10f39e930aa325bb3756b7d7ddc4f76271e42baa3207814b8f9f43efce2fc150.jpg",
                    CategoryId = 2
                });
                
                books.Add(new Book(){
                    Title = "Midnight in Chernobyl : The Story of the World's Greatest Nuclear Disaster",
                    Description = "Early in the morning of April 26, 1986, Reactor Number Four of the Chernobyl Atomic Energy Station exploded, triggering history's worst nuclear disaster. In the thirty years since then, Chernobyl has become lodged in the collective nightmares of the world: shorthand for the spectral horrors of radiation poisoning, for a dangerous technology slipping its leash, for ecological fragility, and for what can happen when a dishonest and careless state endangers not only its own citizens, but all of humanity. ",
                    Price = 750.00,
                    Pages = 560,
                    AuthorId = 5,
                    Image = "images/cc04f3a8216c6c570af0f626cf743f64caae46818e04012806561cd4f85dbfd6.jpg",
                    CategoryId = 3
                });
                books.Add(new Book(){
                    Title = "A Brief History of the Samurai",
                    Description = "From a leading expert in Japanese history, this is one of the first full histories of the art and culture of the Samurai warrior. The Samurai emerged as a warrior caste in Medieval Japan and would have a powerful influence on the history and culture of the country from the next 500 years. Clements also looks at the Samurai wars that tore Japan apart in the 17th and 18th centuries and how the caste was finally demolished in the advent of the mechanized world. ",
                    Price = 660.00,
                    Pages = 384,
                    AuthorId = 6,
                    Image = "images/3ec46a399bf262b79b95200e7862fed6a56acee48b2e3e9f0b79e30163d49f14.jpg",
                    CategoryId = 3
                });
                
                books.Add(new Book(){
                    Title = "Dark Sacred Night : The Brand New Ballard and Bosch Thriller",
                    Description = "A MURDER HE CAN'T FORGET. A CASE ONLY SHE CAN SOLVE.",
                    Price = 350.00,
                    Pages = 544,
                    AuthorId = 7,
                    Image = "images/ffc682d54bcaebae7fed9c70506fc6f629cdd8d8a6b3c7159b97e3294f5a9d05.jpg",
                    CategoryId = 4
                });
                books.Add(new Book(){
                    Title = "Conviction",
                    Description = "From 'the woman who may be Britain's finest living crime novelist' (Daily Telegraph), Conviction stars a strong female protagonist who is obsessed by true-crime podcasts and decides, one day, to investigate one of the unsolved crimes herself.",
                    Price = 980.00,
                    Pages = 384,
                    AuthorId = 8,
                    Image = "images/c32cdbfb569a3ef4da8c2356f3668def517323f605ffec02f57fde9007c0e8b5.jpg",
                    CategoryId = 4
                });
                
                books.Add(new Book(){
                    Title = "How to Be a Footballer",
                    Description = "You become a footballer because you love football. And then you are a footballer, and you're suddenly in the strangest, most baffling world of all.",
                    Price = 50.00,
                    Pages = 304,
                    AuthorId = 9,
                    Image = "images/171a1d3855b4aa00a7dff07e92dd70a740439a6d876d502cac31d92ca1429c10.jpg",
                    CategoryId = 5
                });
                books.Add(new Book(){
                    Title = "Bike Book : Complete bicycle maintenance",
                    Description = "Now in its 23rd year of publication, The Bike Book continues to be a bestseller. Compiled by a new author, this seventh edition is a major update to include all new developments in the cycling world along with a thorough check and revision of all existing material. New photography together with a refreshed page design offer the reader a user-friendly and contemporary manual - but still with the clear step-by-step approach for which Haynes is famous. ",
                    Price = 70.00,
                    Pages = 194,
                    AuthorId = 10,
                    Image = "images/699b56f78d2e7f5df6f61c5cfd4bdb01473302cd28bd2e93722fd50689eb3ef2.jpg",
                    CategoryId = 5
                });

                foreach (var book in books)
                {
                    unitOfWork.Book.Add(book);
                }
               
                unitOfWork.Role.Add(new Role() {Name = "Admin", CreatedAt = DateTime.Now});
                unitOfWork.Role.Add(new Role() {Name = "Customer", CreatedAt = DateTime.Now});
                unitOfWork.Save();
                unitOfWork.User.Add(new User()
                {
                    FirstName = "Admin",
                    LastName = "Adminic",
                    Email = "admin@admin.com",
                    Password = AuthMiddleware.ComputeSha256Hash("admin123"),
                    CreatedAt = DateTime.Now,
                    RoleId = 1
                });
                unitOfWork.User.Add(new User()
                {
                    FirstName = "Korisnik",
                    LastName = "Korisnicic",
                    Email = "user@user.com",
                    Password = AuthMiddleware.ComputeSha256Hash("user123"),
                    CreatedAt = DateTime.Now,
                    RoleId = 2
                });
                unitOfWork.Save();
                unitOfWork.Wallet.Add(new Wallet()
                {
                    UserId = 1,
                    Balance = 0
                });
                unitOfWork.Wallet.Add(new Wallet()
                {
                    UserId = 2,
                    Balance = 0
                });
                #endregion
                
                unitOfWork.Save();
                Console.WriteLine("Finished!");
            }
        }
    }
}