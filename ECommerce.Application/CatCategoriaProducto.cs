using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatCategoriaProducto
    {
        Data.CatCategoriaProducto _catCategoriaProducto = new Data.CatCategoriaProducto();
        public List<Models.CatCategoriaProducto> CatCategoriaProducto_Seleccionar()
        {
            return _catCategoriaProducto.CatCategoriaProducto_Seleccionar();
        }
        public Models.CatCategoriaProducto CatCategoriaProducto_Agregar(Models.CatCategoriaProducto catCategoriaProducto)
        {
            return _catCategoriaProducto.CatCategoriaProducto_Agregar(catCategoriaProducto);
        }
    }
}
