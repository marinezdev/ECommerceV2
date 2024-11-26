using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Token
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Token Token_Agregar()
        {
            const string consulta = "Administracion.Token_Agregar";
            b.ExecuteCommandSP(consulta);

            Models.Token resultado = new Models.Token();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Token>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
