using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class CarroElectronicoArticulo
    {
        public Articulo Articulo { get; set; }
        public ArticuloDetalle ArticuloDetalle { get; set; }
        public ArticuloImagen ArticuloImagen { get; set; }
        public CatCategoriaProducto CatCategoriaProducto { get; set; }
        public CatSubcategoria CatSubcategoria { get; set; }
        public CatClasificacion CatClasificacion { get; set; }
        public CarroElectronico CarroElectronico { get; set; }
        public string PrecioPublicoText { get; set; }
        public string PrecioTotalText { get; set; }
    }
}
