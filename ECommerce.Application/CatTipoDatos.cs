using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatTipoDatos
    {
        Data.CatTipoDatos _CatTipoDatos = new Data.CatTipoDatos();
        public List<Models.CatTipoDatos> CatTipoDatos_Seleccionar()
        {
            return _CatTipoDatos.CatTipoDatos_Seleccionar();
        }
    }
}
