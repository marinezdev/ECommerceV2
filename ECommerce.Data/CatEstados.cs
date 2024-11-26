using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatEstados
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatEstados> CatEstados_Seleccionar()
        {
            const string consulta = "Persona.CatEstados_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.CatEstados> resultado = new List<Models.CatEstados>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatEstados>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
