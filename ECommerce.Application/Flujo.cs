using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Flujo
    {
        Data.Flujo _Flujo = new Data.Flujo();
        public List<Models.Flujo> Flujo_Seleccionar()
        {
            return _Flujo.Flujo_Seleccionar();
        }

        public Models.Flujo Flujo_Agregar(Models.Flujo flujo)
        {
            return _Flujo.Flujo_Agregar(flujo);
        }
    }
}
