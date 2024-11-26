using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class MenuPermiso
    {
        public Rol Rol { get; set; }
        public Menu Menu { get; set; }
        public bool Permiso { get; set; }
    }
}
