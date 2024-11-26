using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatEstados
    {
        Data.CatEstados _CatEstados = new Data.CatEstados();
        public List<Models.CatEstados> CatEstados_Seleccionar()
        {
            return _CatEstados.CatEstados_Seleccionar();
        }
    }
}