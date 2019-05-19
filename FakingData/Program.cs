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
            using (var unitOfWork = new UnitOfWork(new RestaurantContext()))
            {
                #region Faking data

                string[] categories = new string[] { "Predjela", "Corbe", "Rostilj", "Salate", "Pice" };
                foreach (var cat in categories)
                {
                    var category = new Category
                    {
                        Name = cat
                    };
                    
                    unitOfWork.Category.Add(category);
                }
                List<Dish> dishes = new List<Dish>();
                
                dishes.Add(new Dish(){
                    Title = "Ruska salata",
                    Ingredients = "majonez, pavlaka, salama, grasak",
                    Price = 200.00,
                    Serving = "200gr",
                    CategoryId = 1
                });
                dishes.Add(new Dish(){
                    Title = "Rolat",
                    Ingredients = "salama, sir, majonez",
                    Price = 350.50,
                    Serving = "300gr",
                    CategoryId = 1
                });
                dishes.Add(new Dish(){
                    Title = "Njeguski prsut",
                    Ingredients = "njeguski prsut, domaci sir, urnebes, cackalica",
                    Price = 450.00,
                    Serving = "500gr",
                    CategoryId = 1
                });
                dishes.Add(new Dish(){
                    Title = "Zu Zu",
                    Ingredients = "zu zu pecivo",
                    Price = 150.00,
                    Serving = "500gr",
                    CategoryId = 1
                });
                
                dishes.Add(new Dish(){
                    Title = "Pileca corba",
                    Ingredients = "voda, pilece meso",
                    Price = 350.00,
                    Serving = "500ml",
                    CategoryId = 2
                });
                dishes.Add(new Dish(){
                    Title = "Teleca corba",
                    Ingredients = "voda, telece meso",
                    Price = 500.00,
                    Serving = "500ml",
                    CategoryId = 2
                });
                dishes.Add(new Dish(){
                    Title = "Govedja corba",
                    Ingredients = "voda, govedje meso",
                    Price = 450.00,
                    Serving = "500ml",
                    CategoryId = 2
                });
                dishes.Add(new Dish(){
                    Title = "Pileca supa iz kesice",
                    Ingredients = "voda, prasak",
                    Price = 50.00,
                    Serving = "500ml",
                    CategoryId = 2
                });
                
                dishes.Add(new Dish(){
                    Title = "Mesano meso",
                    Ingredients = "pilece belo, batak, kobasica, cevap, gurmanska, slanina",
                    Price = 1000.00,
                    Serving = "1kg",
                    CategoryId = 3
                });
                dishes.Add(new Dish(){
                    Title = "Belo meso",
                    Ingredients = "pilece belo meso",
                    Price = 700.00,
                    Serving = "1kg",
                    CategoryId = 3
                });
                dishes.Add(new Dish(){
                    Title = "Rostiljske kobasice",
                    Ingredients = "ljute rostiljske kobasice",
                    Price = 600.00,
                    Serving = "1kg",
                    CategoryId = 3
                });
                dishes.Add(new Dish(){
                    Title = "Cevapi",
                    Ingredients = "junece meso",
                    Price = 800.00,
                    Serving = "1kg",
                    CategoryId = 3
                });
                
                dishes.Add(new Dish(){
                    Title = "Kupus salata",
                    Ingredients = "svez kupus",
                    Price = 100.00,
                    Serving = "300gr",
                    CategoryId = 4
                });
                dishes.Add(new Dish(){
                    Title = "Sopska salata",
                    Ingredients = "sir, paradajz, krastavci",
                    Price = 200.00,
                    Serving = "300gr",
                    CategoryId = 4
                });
                dishes.Add(new Dish(){
                    Title = "Grska salata",
                    Ingredients = "paprika, masline, sir, paradajz, origano, krastavac",
                    Price = 300.00,
                    Serving = "300fr",
                    CategoryId = 4
                });
                dishes.Add(new Dish(){
                    Title = "Srpska salata",
                    Ingredients = "paradajz, krastavac",
                    Price = 200.00,
                    Serving = "300gr",
                    CategoryId = 4
                });
                
                dishes.Add(new Dish(){
                    Title = "Zajecarsko",
                    Ingredients = "jecam, hmelj i voda",
                    Price = 100.00,
                    Serving = "0.5l",
                    CategoryId = 5
                });
                dishes.Add(new Dish(){
                    Title = "Banarski rizling",
                    Ingredients = "vino belo",
                    Price = 200.00,
                    Serving = "1l",
                    CategoryId = 5
                });
                dishes.Add(new Dish(){
                    Title = "Vinjak",
                    Ingredients = "nesto jako",
                    Price = 300.00,
                    Serving = "1l",
                    CategoryId = 5
                });
                dishes.Add(new Dish(){
                    Title = "Rakija",
                    Ingredients = "prepekusa, sljiva, loza, ljuta",
                    Price = 50.00,
                    Serving = "100l",
                    CategoryId = 5
                });

                foreach (var dish in dishes)
                {
                    unitOfWork.Dish.Add(dish);
                }
               
                #endregion
                
                unitOfWork.Save();
                Console.WriteLine("Finished!");
            }
        }
    }
}