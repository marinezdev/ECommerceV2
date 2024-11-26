using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class VentaArticulo
    {
        Data.VentaArticulo _VentaArticulo =  new Data.VentaArticulo();
        public Models.VentaArticulo VentaArticulo_Agregar(Models.VentaArticulo ventaArticulo)
        {
            return _VentaArticulo.VentaArticulo_Agregar(ventaArticulo);
        }
        public List<Models.Consultas.ArticuloConsulta> VentaArticulo_Seleccionar_IdVenta(Models.Venta venta)
        {
            return _VentaArticulo.VentaArticulo_Seleccionar_IdVenta(venta);
        }
    }
}
