using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class Direccion
    {
        public CatEstados CatEstados { get; set; }
        public CatPoblaciones CatPoblaciones { get; set; }
        public CatCp CatCp { get; set; }
        public CatColonias CatColonias { get; set; }
    }
}
