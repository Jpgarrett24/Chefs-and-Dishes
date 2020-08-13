using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Wrapper
    {
        public Dish OneDish { get; set; }
        public List<Dish> AllDishes { get; set; }
        public Chef OneChef { get; set; }
        public List<Chef> AllChefs { get; set; }
    }
}