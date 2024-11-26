using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatPoblaciones
    {
        Data.CatPoblaciones _CatPoblaciones = new Data.CatPoblaciones();

        public List<Models.CatPoblaciones> CatPoblaciones_Seleccionar_IdEstado(Models.CatEstados catEstados)
        {
            return _CatPoblaciones.CatPoblaciones_Seleccionar_IdEstado(catEstados);
        }
    }
}
