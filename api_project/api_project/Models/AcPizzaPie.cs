﻿using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class AcPizzaPie
    {
        public AcPizzaPie()
        {
            AcPizzaOrder = new HashSet<AcPizzaOrder>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<AcPizzaOrder> AcPizzaOrder { get; set; }
    }
}
