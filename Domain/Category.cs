using System.Collections.Generic;

namespace Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Dish Dish { get; set; }
        public int DishId { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}