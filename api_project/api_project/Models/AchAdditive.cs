using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class AchAdditive
    {
        public AchAdditive()
        {
            AchOrderAdditive = new HashSet<AchOrderAdditive>();
        }

        public int IdAdditive { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public ICollection<AchOrderAdditive> AchOrderAdditive { get; set; }
    }
}
