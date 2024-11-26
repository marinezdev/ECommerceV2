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
    public class CatAtributos
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.CatAtributos> CatAtributos_Seleccionar_IdClasificacion(Models.CatAtributos catAtributos)
        {
            const string consulta = "Articulo.CatAtributos_Seleccionar_IdClasificacion";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdClasificacion", catAtributos.CatClasificacion.Id, SqlDbType.Int);

            List<Models.CatAtributos> resultado = new List<Models.CatAtributos>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.CatAtributos>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CatAtributos CatAtributos_Agregar(Models.CatAtributos catAtributos)
        {
            const string consulta = "Articulo.CatAtributos_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdClasificacion", catAtributos.CatClasificacion.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoDato", catAtributos.CatTipoDatos.Id, SqlDbType.Int);
            b.AddParameter("@Atributo", catAtributos.Atributo, SqlDbType.NVarChar);

            Models.CatAtributos resultado = new Models.CatAtributos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatAtributos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CatAtributos CatAtributos_Eliminar(Models.CatAtributos catAtributos)
        {
            const string consulta = "Articulo.CatAtributos_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", catAtributos.Id, SqlDbType.Int);

            Models.CatAtributos resultado = new Models.CatAtributos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatAtributos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CatAtributos CatAtributos_Seleccionar_Id(Models.CatAtributos catAtributos)
        {
            const string consulta = "Articulo.CatAtributos_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", catAtributos.Id, SqlDbType.Int);

            Models.CatAtributos resultado = new Models.CatAtributos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatAtributos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CatAtributos CatAtributos_Editar(Models.CatAtributos catAtributos)
        {
            const string consulta = "Articulo.CatAtributos_Editar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", catAtributos.Id, SqlDbType.Int);
            b.AddParameter("@Atributo", catAtributos.Atributo, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoDato", catAtributos.CatTipoDatos.Id, SqlDbType.Int);

            Models.CatAtributos resultado = new Models.CatAtributos();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CatAtributos>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
