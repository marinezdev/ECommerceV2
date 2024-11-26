using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Menu
    {
        Data.Menu _Menu = new Data.Menu();
        public bool ValidacionPagina(Models.MenuPermiso menuPermiso)
        {
            bool resultado = false;
            if (menuPermiso != null)
            {
                if (_Menu.ValidaPaginas(menuPermiso).Permiso)
                {
                    resultado = true;
                }
            }
            return resultado;
        }

    }
}
