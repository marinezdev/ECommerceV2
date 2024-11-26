using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public  class CatClasificacion
    {
        Data.CatClasificacion _CatClasificacion = new Data.CatClasificacion();
        public Models.CatClasificacion CatClasificacion_Agregar(Models.CatClasificacion catClasificacion)
        {
            return _CatClasificacion.CatClasificacion_Agregar(catClasificacion);
        }
        public List<Models.CatClasificacion> CatClasificacion_Seleccionar_IdSubCategoria(Models.CatSubcategoria catSubcategoria)
        {
            return _CatClasificacion.CatClasificacion_Seleccionar_IdSubCategoria(catSubcategoria);
        }
    }
}
