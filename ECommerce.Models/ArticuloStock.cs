using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public  class ArticuloStock
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int Stock { get; set; }
    }
}
