using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatSubcategoria
    {
        Data.CatSubcategoria _catSubcategoria = new Data.CatSubcategoria();
        public List<Models.CatSubcategoria> CatSubcategoria_Seleccionar_IdCategoria(Models.CatCategoriaProducto catCategoriaProducto)
        {
            return _catSubcategoria.CatSubcategoria_Seleccionar_IdCategoria(catCategoriaProducto);
        }

        public Models.CatSubcategoria CatSubcategoria_Agregar(Models.CatSubcategoria catSubcategoria)
        {
            return _catSubcategoria.CatSubcategoria_Agregar(catSubcategoria);
        }
        
    }
}
