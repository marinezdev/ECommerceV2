using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatTipoDatos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatTipoDatos> CatTipoDatos_Seleccionar()
        {
            const string consulta = "Articulo.CatTipoDatos_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.CatTipoDatos> resultado = new List<Models.CatTipoDatos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatTipoDatos>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
