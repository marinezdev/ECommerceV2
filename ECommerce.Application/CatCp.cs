using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CatCp
    {
        Data.CatCp _CatCP = new Data.CatCp();
        public List<Models.Consultas.Direccion> CatCp_Seleccionar_CP(Models.CatCp catCp)
        {
            return _CatCP.CatCp_Seleccionar_CP(catCp);
        }
        public List<Models.CatCp> CatCP_Seleccionar_IdColonia(Models.CatColonias catColonias)
        {
            return _CatCP.CatCP_Seleccionar_IdColonia(catColonias);
        }
    }
}
