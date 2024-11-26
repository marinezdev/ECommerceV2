using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatMoneda
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatMoneda> CatMoneda_Seleccionar()
        {
            const string consulta = "Articulo.CatMoneda_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.CatMoneda> resultado = new List<Models.CatMoneda>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatMoneda>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
