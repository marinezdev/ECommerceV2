using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CookieCarrito
    {
        ManejoDatos b = new ManejoDatos();
        public Models.CookieCarrito CookieCarrito_Agregar()
        {
            const string consulta = "Ventas.CookieCarrito_Agregar";
            b.ExecuteCommandSP(consulta);

            Models.CookieCarrito resultado = new Models.CookieCarrito();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CookieCarrito>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
