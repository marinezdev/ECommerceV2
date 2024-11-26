using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatCp
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Consultas.Direccion> CatCp_Seleccionar_CP(Models.CatCp catCp)
        {
            const string consulta = "Persona.CatCp_Seleccionar_CP";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@CP", catCp.CP, SqlDbType.NVarChar);

            List<Models.Consultas.Direccion> resultado = new List<Models.Consultas.Direccion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Direccion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.CatCp> CatCP_Seleccionar_IdColonia(Models.CatColonias catColonias)
        {
            const string consulta = "Persona.CatCP_Seleccionar_IdColonia";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdColonia", catColonias.Id, SqlDbType.NVarChar);

            List<Models.CatCp> resultado = new List<Models.CatCp>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatCp>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
