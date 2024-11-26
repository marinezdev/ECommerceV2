using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public  class Email
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Email Email_Seleccionar_Email(Models.Email email)
        {
            const string consulta = "Persona.Email_Seleccionar_Email";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Email", email.email, SqlDbType.VarChar);

            Models.Email resultado = new Models.Email();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Email>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
