using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatAtributos
    {
        Data.CatAtributos _CatAtributos = new Data.CatAtributos();
        public List<Models.CatAtributos> CatAtributos_Seleccionar_IdClasificacion(Models.CatAtributos catAtributos)
        {
            return _CatAtributos.CatAtributos_Seleccionar_IdClasificacion(catAtributos);
        }
        public Models.CatAtributos CatAtributos_Agregar(Models.CatAtributos catAtributos)
        {
            return _CatAtributos.CatAtributos_Agregar(catAtributos);
        }
        public Models.CatAtributos CatAtributos_Eliminar(Models.CatAtributos catAtributos)
        {
            return _CatAtributos.CatAtributos_Eliminar(catAtributos);
        }
        public Models.CatAtributos CatAtributos_Seleccionar_Id(Models.CatAtributos catAtributos)
        {
            return _CatAtributos.CatAtributos_Seleccionar_Id(catAtributos);
        }
        public Models.CatAtributos CatAtributos_Editar(Models.CatAtributos catAtributos)
        {
            return _CatAtributos.CatAtributos_Editar(catAtributos);
        }
    }
}
