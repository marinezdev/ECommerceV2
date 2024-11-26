using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class CatSubcategoria
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatSubcategoria> CatSubcategoria_Seleccionar_IdCategoria(Models.CatCategoriaProducto catCategoriaProducto)
        {
            const string consulta = "Articulo.CatSubcategoria_Seleccionar_IdCategoria";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdCategoria", catCategoriaProducto.Id, SqlDbType.VarChar);

            List<Models.CatSubcategoria> resultado = new List<Models.CatSubcategoria>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatSubcategoria>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.CatSubcategoria CatSubcategoria_Agregar(Models.CatSubcategoria catSubcategoria)
        {
            const string consulta = "Articulo.CatSubcategoria_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", catSubcategoria.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Imagen", catSubcategoria.Imagen, SqlDbType.VarChar);
            b.AddParameter("@IdCategoria", catSubcategoria.CatCategoriaProducto.Id, SqlDbType.VarChar);

            Models.CatSubcategoria resultado = new Models.CatSubcategoria();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatSubcategoria>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
