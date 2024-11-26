using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class VentaArticulo
    {
        ManejoDatos b = new ManejoDatos();
        public Models.VentaArticulo VentaArticulo_Agregar(Models.VentaArticulo ventaArticulo)
        {
            const string consulta = "Ventas.VentaArticulo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVenta", ventaArticulo.Venta.Id, SqlDbType.NVarChar);
            b.AddParameter("@IdArticulo", ventaArticulo.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@Item", ventaArticulo.Item, SqlDbType.Int);
            b.AddParameter("@Precio", ventaArticulo.Precio, SqlDbType.Decimal);

            Models.VentaArticulo resultado = new Models.VentaArticulo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.VentaArticulo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.ArticuloConsulta> VentaArticulo_Seleccionar_IdVenta(Models.Venta venta)
        {
            const string consulta = "Ventas.VentaArticulo_Seleccionar_IdVenta";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVenta", venta.Id, SqlDbType.Int);

            List<Models.Consultas.ArticuloConsulta> resultado = new List<Models.Consultas.ArticuloConsulta>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.ArticuloConsulta>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        


    }
}
