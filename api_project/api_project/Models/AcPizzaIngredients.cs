﻿using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class AcPizzaIngredients
    {
        public int Id { get; set; }
        public int AcIngredientsId { get; set; }
        public int AcPizzasId { get; set; }

        public AcIngredients AcIngredients { get; set; }
        public AcPizzas AcPizzas { get; set; }
    }
}
