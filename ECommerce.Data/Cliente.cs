using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Cliente
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Consultas.UsuarioInformacion Cliente_Seleccionar_Id(Models.Cliente cliente)
        {
            const string consulta = "Ventas.Cliente_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", cliente.Id, SqlDbType.Int);

            Models.Consultas.UsuarioInformacion resultado = new Models.Consultas.UsuarioInformacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.UsuarioInformacion> (reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
