using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ArticuloComentario
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.ArticuloComentario> ArticuloComentario_Seleccionar_PorPagina(Models.Articulo articulo, int Pagina)
        {
            const string consulta = "Articulo_Comentario_Selecionar_PorPagina";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);
            b.AddParameter("@NumPag", Pagina, SqlDbType.Int);

            List<Models.ArticuloComentario> resultado = new List<Models.ArticuloComentario>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ArticuloComentario>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.ArticuloComentario ArticuloComentario_Agregar(Models.ArticuloComentario articuloComentario)
        {
            const string consulta = "Articulo.ArticuloComentario_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articuloComentario.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", articuloComentario.Usuario.Id, SqlDbType.Int);
            b.AddParameter("@Estrellas", articuloComentario.Estrellas, SqlDbType.Int);
            b.AddParameter("@Comentario", articuloComentario.Comentario, SqlDbType.NVarChar);

            Models.ArticuloComentario resultado = new Models.ArticuloComentario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArticuloComentario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }
        public Models.ArticuloComentario ArticuloComentario_ContarPaginas_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo.ArticuloComentario_ContarPaginas_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            Models.ArticuloComentario resultado = new Models.ArticuloComentario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArticuloComentario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
