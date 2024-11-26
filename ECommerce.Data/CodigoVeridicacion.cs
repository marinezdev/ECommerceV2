using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CodigoVeridicacion
    {
        ManejoDatos b = new ManejoDatos();
        public Models.CodigoVeridicacion Administracion_CodigoVeridicacion_Generar(Models.Usuario usuario)
        {
            const string consulta = "Administracion.CodigoVeridicacion_Generar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUser", usuario.Id, SqlDbType.Int);


            Models.CodigoVeridicacion resultado = new Models.CodigoVeridicacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CodigoVeridicacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }
    }
}
