using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Past : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime FormDate = Convert.ToDateTime(value);
            if (FormDate < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("D.O.B. must be a date from the past");
            }
        }
    }

    public class Over18 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime FormDate = Convert.ToDateTime(value);
            DateTime Cutoff = DateTime.Now.AddYears(-18);
            if (FormDate < Cutoff)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Chef must be at least 18 years of age");
            }
        }
    }

    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Date of Birth: ")]
        [DataType(DataType.Date)]
        [Past]
        [Over18]
        public DateTime DOB { get; set; }

        public List<Dish> CreatedDishes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}