﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CatPoblaciones
    {
        public int Id { get; set; }
        public CatEstados CatEstados { get; set;}
        public string Poblacion { get; set; }
    }
}
