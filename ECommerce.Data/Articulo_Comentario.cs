using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Articulo_Comentario
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.Articulo_Comentario> Articulo_Comentario_Selecionar_PorPagina(Models.Articulo articulo, int Pagina)
        {
            const string consulta = "Articulo_Comentario_Selecionar_PorPagina";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);
            b.AddParameter("@NumPag", Pagina, SqlDbType.Int);

            List<Models.Articulo_Comentario> resultado = new List<Models.Articulo_Comentario>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Articulo_Comentario>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Articulo_Comentario Articulo_Comentario_Agregar(Models.Articulo_Comentario articulo_Comentario)
        {
            const string consulta = "Articulo_Comentario_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo_Comentario.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", articulo_Comentario.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@Email", articulo_Comentario.Email, SqlDbType.NVarChar);
            b.AddParameter("@Estrellas", articulo_Comentario.Estrellas, SqlDbType.Int);
            b.AddParameter("@Comentario", articulo_Comentario.Comentario, SqlDbType.NVarChar);

            Models.Articulo_Comentario resultado = new Models.Articulo_Comentario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Articulo_Comentario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }
        public Models.Articulo_Comentario Articulo_Comentario_ContarPaginas_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo_Comentario_ContarPaginas_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            Models.Articulo_Comentario resultado = new Models.Articulo_Comentario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Articulo_Comentario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
