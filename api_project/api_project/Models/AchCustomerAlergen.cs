using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class AchCustomerAlergen
    {
        public int CustomerAlergenId { get; set; }
        public int AchIngredientIdIngredient { get; set; }
        public int AchCustomerIdCustomer { get; set; }

        public AchCustomer AchCustomerIdCustomerNavigation { get; set; }
        public AchIngredient AchIngredientIdIngredientNavigation { get; set; }
    }
}
