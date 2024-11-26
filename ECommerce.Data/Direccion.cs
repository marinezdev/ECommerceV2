using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Direccion
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.PersonaDireccion> Direccion_Seleccionar_IdUsuario(Models.Usuario usuario)
        {
            const string consulta = "Persona.Direccion_Seleccionar_IdUsuario";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuario.Id, SqlDbType.NVarChar);

            List<Models.PersonaDireccion> resultado = new List<Models.PersonaDireccion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.PersonaDireccion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.PersonaDireccion Direccion_Seleccionar_Id(Models.PersonaDireccion personaDireccion)
        {
            const string consulta = "Persona.Direccion_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", personaDireccion.Id, SqlDbType.NVarChar);

            Models.PersonaDireccion resultado = new Models.PersonaDireccion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.PersonaDireccion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
