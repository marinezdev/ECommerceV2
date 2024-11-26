using ECommerce.Models.Consultas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatPoblaciones
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatPoblaciones> CatPoblaciones_Seleccionar_IdEstado(Models.CatEstados catEstados)
        {
            const string consulta = "Persona.CatPoblaciones_Seleccionar_IdEstado";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdEstado", catEstados.Id, SqlDbType.Int);

            List<Models.CatPoblaciones> resultado = new List<Models.CatPoblaciones>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatPoblaciones>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
