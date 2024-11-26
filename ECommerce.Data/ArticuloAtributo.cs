using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ArticuloAtributo
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ArticuloAtributo ArticuloAtributo_Agregar(Models.ArticuloAtributo articuloAtributo)
        {
            const string consulta = "Articulo.ArticuloAtributo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articuloAtributo.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@IdAtributo", articuloAtributo.CatAtributos.Id, SqlDbType.Int);
            b.AddParameter("@Valor", articuloAtributo.CatAtributos.Valor, SqlDbType.NVarChar);

            Models.ArticuloAtributo resultado = new Models.ArticuloAtributo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArticuloAtributo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ArticuloAtributo> ArticuloAtributo_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo.ArticuloAtributo_Seleccionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            List<Models.ArticuloAtributo> resultado = new List<Models.ArticuloAtributo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ArticuloAtributo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
