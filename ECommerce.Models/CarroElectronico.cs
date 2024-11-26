using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CarroElectronico
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public int Item { get; set; }
    }
}
