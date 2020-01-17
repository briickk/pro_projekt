using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class AcSize
    {
        public AcSize()
        {
            AcPizzaDetails = new HashSet<AcPizzaDetails>();
        }

        public int Id { get; set; }
        public int Size { get; set; }

        public ICollection<AcPizzaDetails> AcPizzaDetails { get; set; }
    }
}
