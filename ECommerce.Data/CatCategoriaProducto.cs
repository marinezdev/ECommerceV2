using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatCategoriaProducto
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatCategoriaProducto> CatCategoriaProducto_Seleccionar()
        {
            const string consulta = "Articulo.CatCategoriaProducto_Seleccionar";
            b.ExecuteCommandSP(consulta);

            List<Models.CatCategoriaProducto> resultado = new List<Models.CatCategoriaProducto>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatCategoriaProducto>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.CatCategoriaProducto CatCategoriaProducto_Agregar(Models.CatCategoriaProducto catCategoriaProducto)
        {
            const string consulta = "Articulo.CatCategoriaProducto_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", catCategoriaProducto.Nombre, SqlDbType.VarChar);

            Models.CatCategoriaProducto resultado = new Models.CatCategoriaProducto();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatCategoriaProducto>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
