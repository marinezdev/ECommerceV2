using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class NuevoArticulo
    {
        public Articulo Articulo { get; set; }
        public ArticuloDetalle ArticuloDetalle { get; set; }
        public ArticuloStock ArticuloStock { get; set; }
        public ArticuloPromocion ArticuloPromocion { get; set; }
    }
}
