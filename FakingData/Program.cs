using System;
using System.Collections.Generic;
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

                List<Book> books = new List<Book>();
                
                books.Add(new Book(){
                    Title = "Brief Answers to the Big Questions : the final book from Stephen Hawking",
                    Description = "The world-famous cosmologist and #1 bestselling author of A Brief History of Time leaves us with his final thoughts on the universe's biggest questions in this brilliant posthumous work.",
                    Price = 200.00,
                    Pages = 256,
                    AuthorId = 1,
                    Image = "as",
                    CategoryId = 1
                });
                books.Add(new Book(){
                    Title = "The Diary of a Young Girl",
                    Description = "For almost fifty years, Anne Frank's diary has moved millions with its testament to the human spirit's indestructibility, but readers have never seen the full text of this beloved book--until now. This new translation, performed by Winona Ryder, restores nearly one third of Anne's entries excised by her father in previous editions, revealing her burgeoning sexuality, her stormy relationship with her mother, and more. ",
                    Price = 250.00,
                    Pages = 283,
                    AuthorId = 2,
                    Image = "as",
                    CategoryId = 1
                });
                
                books.Add(new Book(){
                    Title = "Normal People",
                    Description = "WINNER OF THE COSTA NOVEL AWARD 2018",
                    Price = 300.00,
                    Pages = 288,
                    AuthorId = 3,
                    Image = "as",
                    CategoryId = 2
                });
                books.Add(new Book(){
                    Title = "A Gentleman in Moscow",
                    Description = "OVER A MILLION COPIES SOLD",
                    Price = 660.00,
                    Pages = 480,
                    AuthorId = 4,
                    Image = "as",
                    CategoryId = 2
                });
                
                books.Add(new Book(){
                    Title = "Midnight in Chernobyl : The Story of the World's Greatest Nuclear Disaster",
                    Description = "Early in the morning of April 26, 1986, Reactor Number Four of the Chernobyl Atomic Energy Station exploded, triggering history's worst nuclear disaster. In the thirty years since then, Chernobyl has become lodged in the collective nightmares of the world: shorthand for the spectral horrors of radiation poisoning, for a dangerous technology slipping its leash, for ecological fragility, and for what can happen when a dishonest and careless state endangers not only its own citizens, but all of humanity. ",
                    Price = 750.00,
                    Pages = 560,
                    AuthorId = 5,
                    Image = "as",
                    CategoryId = 3
                });
                books.Add(new Book(){
                    Title = "A Brief History of the Samurai",
                    Description = "From a leading expert in Japanese history, this is one of the first full histories of the art and culture of the Samurai warrior. The Samurai emerged as a warrior caste in Medieval Japan and would have a powerful influence on the history and culture of the country from the next 500 years. Clements also looks at the Samurai wars that tore Japan apart in the 17th and 18th centuries and how the caste was finally demolished in the advent of the mechanized world. ",
                    Price = 660.00,
                    Pages = 384,
                    AuthorId = 6,
                    Image = "as",
                    CategoryId = 3
                });
                
                books.Add(new Book(){
                    Title = "Dark Sacred Night : The Brand New Ballard and Bosch Thriller",
                    Description = "A MURDER HE CAN'T FORGET. A CASE ONLY SHE CAN SOLVE.",
                    Price = 350.00,
                    Pages = 544,
                    AuthorId = 7,
                    Image = "as",
                    CategoryId = 4
                });
                books.Add(new Book(){
                    Title = "Conviction",
                    Description = "From 'the woman who may be Britain's finest living crime novelist' (Daily Telegraph), Conviction stars a strong female protagonist who is obsessed by true-crime podcasts and decides, one day, to investigate one of the unsolved crimes herself.",
                    Price = 980.00,
                    Pages = 384,
                    AuthorId = 8,
                    Image = "as",
                    CategoryId = 4
                });
                
                books.Add(new Book(){
                    Title = "How to Be a Footballer",
                    Description = "You become a footballer because you love football. And then you are a footballer, and you're suddenly in the strangest, most baffling world of all.",
                    Price = 50.00,
                    Pages = 304,
                    AuthorId = 9,
                    Image = "as",
                    CategoryId = 5
                });
                books.Add(new Book(){
                    Title = "Bike Book : Complete bicycle maintenance",
                    Description = "Now in its 23rd year of publication, The Bike Book continues to be a bestseller. Compiled by a new author, this seventh edition is a major update to include all new developments in the cycling world along with a thorough check and revision of all existing material. New photography together with a refreshed page design offer the reader a user-friendly and contemporary manual - but still with the clear step-by-step approach for which Haynes is famous. ",
                    Price = 70.00,
                    Pages = 194,
                    AuthorId = 10,
                    Image = "as",
                    CategoryId = 5
                });

                foreach (var book in books)
                {
                    unitOfWork.Book.Add(book);
                }
               
                unitOfWork.Role.Add(new Role() {Name = "Admin"});
                unitOfWork.Role.Add(new Role() {Name = "Customer"});
                #endregion
                
                unitOfWork.Save();
                Console.WriteLine("Finished!");
            }
        }
    }
}