using ECommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ArticuloImagen
    {
        ManejoDatos b = new ManejoDatos();
        public Models.ArticuloImagen ArticuloImagen_Agregar(Models.ArticuloImagen articuloImagen)
        {
            const string consulta = "Articulo.ArticuloImagen_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articuloImagen.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@NmArchivo", articuloImagen.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", articuloImagen.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@ImagenURL", articuloImagen.ImagenURL, SqlDbType.NVarChar);

            Models.ArticuloImagen resultado = new Models.ArticuloImagen();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.ArticuloImagen>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.ArticuloImagen> ArticuloImagen_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo.ArticuloImagen_Seleccionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            List<Models.ArticuloImagen> resultado = new List<Models.ArticuloImagen>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.ArticuloImagen>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
