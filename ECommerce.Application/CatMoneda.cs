using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatMoneda
    {
        Data.CatMoneda _CatMoneda = new Data.CatMoneda();
        public List<Models.CatMoneda> CatMoneda_Seleccionar()
        {
            return _CatMoneda.CatMoneda_Seleccionar();
        }
    }
}
