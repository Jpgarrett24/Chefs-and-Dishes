using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required(ErrorMessage = "Dish name is required")]
        [Display(Name = "Dish Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Number of Calories is required")]
        [Range(0, 2000000000, ErrorMessage = "Calories must be a positive number")]
        [Display(Name = "Number of Calories: ")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Tastiness level is required")]
        [Range(1, 5, ErrorMessage = "Tastiness must be between 1-5")]
        [Display(Name = "Tastiness :")]
        public int Tastiness { get; set; }

        [Required(ErrorMessage = "Descriptions is required")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Display(Name = "Chef :")]
        public int ChefId { get; set; }
        public Chef Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}