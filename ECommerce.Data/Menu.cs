using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Menu
    {
        ManejoDatos b = new ManejoDatos();

        public Models.MenuPermiso ValidaPaginas(Models.MenuPermiso menuPermiso)
        {
            const string consulta = "Administracion.Menu_Selecionar_rol";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdRol", menuPermiso.Rol.Id, SqlDbType.Int);
            b.AddParameter("@url", menuPermiso.Menu.URL, SqlDbType.VarChar);

            Models.MenuPermiso resultado = new Models.MenuPermiso();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.MenuPermiso>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
