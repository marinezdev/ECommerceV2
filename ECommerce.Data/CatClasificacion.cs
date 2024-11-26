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
    public class CatClasificacion
    {
        ManejoDatos b = new ManejoDatos();

        public Models.CatClasificacion CatClasificacion_Agregar(Models.CatClasificacion catClasificacion)
        {
            const string consulta = "Articulo.CatClasificacion_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Nombre", catClasificacion.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Imagen", catClasificacion.Imagen, SqlDbType.VarChar);
            b.AddParameter("@IdSubcategoria", catClasificacion.CatSubcategoria.Id, SqlDbType.Int);

            Models.CatClasificacion resultado = new Models.CatClasificacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatClasificacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.CatClasificacion> CatClasificacion_Seleccionar_IdSubCategoria(Models.CatSubcategoria catSubcategoria)
        {
            const string consulta = "Articulo.CatClasificacion_Seleccionar_IdSubCategoria";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdSubcategoria", catSubcategoria.Id, SqlDbType.Int);

            List<Models.CatClasificacion> resultado = new List<Models.CatClasificacion>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatClasificacion>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
