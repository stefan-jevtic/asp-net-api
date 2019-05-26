using System.Collections;
using System.Collections.Generic;
using Application.DTO;
using Domain;

namespace WebApp.Models
{
    public class DishCategoryModel
    {
        public CategoryDTO Categories { get; set; }
        public DishDTO Dishes { get; set; }
    }
}