﻿using System;
using System.Collections.Generic;

namespace api_project.Models
{
    public partial class PrzedmiotPoprzedzajacy
    {
        public int IdPoprzednik { get; set; }
        public int IdPrzedmiot { get; set; }

        public Przedmiot IdPoprzednikNavigation { get; set; }
        public Przedmiot IdPrzedmiotNavigation { get; set; }
    }
}
