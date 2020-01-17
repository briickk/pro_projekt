using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class StudentGrupa
    {
        public int IdOsoba { get; set; }
        public int IdGrupa { get; set; }

        public Grupa IdGrupaNavigation { get; set; }
        public Student IdOsobaNavigation { get; set; }
    }
}
