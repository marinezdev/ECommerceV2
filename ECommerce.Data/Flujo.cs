using ECommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Flujo
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Flujo> Flujo_Seleccionar()
        {
            const string consulta = "Flujo.Flujo_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.Flujo> resultado = new List<Models.Flujo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Flujo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Flujo Flujo_Agregar(Models.Flujo flujo)
        {
            const string consulta = "Flujo.Flujo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", flujo.Nombre, SqlDbType.VarChar);

            Models.Flujo resultado = new Models.Flujo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Flujo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
