using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Articulo
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Articulo Articulo_Agregar(Models.Consultas.NuevoArticulo nuevoArticulo)
        {
            const string consulta = "Articulo.Articulo_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdClasificacion", nuevoArticulo.Articulo.CatClasificacion.Id, SqlDbType.Int);
            b.AddParameter("@IdFlujo", nuevoArticulo.Articulo.Flujo.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", nuevoArticulo.ArticuloDetalle.Nombre, SqlDbType.VarChar);
            b.AddParameter("@SKU", nuevoArticulo.ArticuloDetalle.SKU, SqlDbType.VarChar);
            b.AddParameter("@Stock", nuevoArticulo.ArticuloStock.Stock, SqlDbType.Int);
            b.AddParameter("@Descripcion", nuevoArticulo.ArticuloDetalle.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@Largo", nuevoArticulo.ArticuloDetalle.Largo, SqlDbType.Float);
            b.AddParameter("@Ancho", nuevoArticulo.ArticuloDetalle.Ancho, SqlDbType.Float);
            b.AddParameter("@Altura", nuevoArticulo.ArticuloDetalle.Altura, SqlDbType.Float);
            b.AddParameter("@Peso", nuevoArticulo.ArticuloDetalle.Peso, SqlDbType.Float);
            b.AddParameter("@Envio", nuevoArticulo.ArticuloDetalle.Envio, SqlDbType.Int);
            b.AddParameter("@PrecioPublico", nuevoArticulo.ArticuloDetalle.PrecioPublico, SqlDbType.Float);
            b.AddParameter("@PrecioDistribuidor", nuevoArticulo.ArticuloDetalle.PrecioDistribuidor, SqlDbType.Float);
            b.AddParameter("@PrecioLista", nuevoArticulo.ArticuloDetalle.PrecioLista, SqlDbType.Float);
            b.AddParameter("@PrecioPlataformaPago", nuevoArticulo.ArticuloDetalle.PrecioPlataformaPago, SqlDbType.Float);
            b.AddParameter("@PrecioEnvio", nuevoArticulo.ArticuloDetalle.PrecioEnvio, SqlDbType.Float);
            b.AddParameter("@IdMoneda", nuevoArticulo.ArticuloDetalle.CatMoneda.Id, SqlDbType.Int);
            b.AddParameter("@Promocion", nuevoArticulo.ArticuloPromocion.Id, SqlDbType.Int);
            b.AddParameter("@FechaInicio", nuevoArticulo.ArticuloPromocion.FechaInicio, SqlDbType.Date);
            b.AddParameter("@FechaFin", nuevoArticulo.ArticuloPromocion.FechaFin, SqlDbType.Date);
            b.AddParameter("@Precio", nuevoArticulo.ArticuloPromocion.Precio, SqlDbType.Float);
            b.AddParameter("@IdMonedaPromocion", nuevoArticulo.ArticuloPromocion.CatMoneda.Id, SqlDbType.Int);

            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Articulo>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar_TotalSubCategoria()
        {
            const string consulta = "Articulo.Articulo_Seleccionar_TotalSubCategoria";
            b.ExecuteCommandSP(consulta);

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
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar_UltimosArticulos()
        {
            const string consulta = "Articulo.Articulo_Seleccionar_UltimosArticulos";
            b.ExecuteCommandSP(consulta);

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
        public List<Models.Consultas.ArticuloConsulta> Articulo_Seleccionar()
        {
            const string consulta = "Articulo.Articulo_Seleccionar";
            b.ExecuteCommandSP(consulta);

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
        public Models.Consultas.ArticuloConsulta Articulo_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo.Articulo_Seleccionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            Models.Consultas.ArticuloConsulta resultado = new Models.Consultas.ArticuloConsulta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.ArticuloConsulta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.ArticuloConsulta> Articulo_Selecionar_IdClasificacion(Models.CatClasificacion catClasificacion)
        {
            const string consulta = "Articulo.Articulo_Seleccionar_IdClasificacion";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdClasificacion", catClasificacion.Id, SqlDbType.Int);

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
















        public List<Models.Articulo> Articulo_Listar()
        {
            b.ExecuteCommandSP("Articulo_Listar");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    SKU = reader["SKU"].ToString(),
                    Informacion = reader["Informacion"].ToString(),
                    PrecioPublico = reader["PrecioPublico"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Articulo> Articulos_Store_Listar()
        {
            b.ExecuteCommandSP("Articulos_Store_Listar");
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Clasificacion = reader["Clasificacion"].ToString(),
                    Imagen = reader["Imagen"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Moneda =  reader["Moneda"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.ArticuloConsulta Articulo_Selecionar_IdArticulo(Models.Articulo articulo)
        {
            const string consulta = "Articulo_Selecionar_IdArticulo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdArticulo", articulo.Id, SqlDbType.Int);

            Models.Consultas.ArticuloConsulta resultado = new Models.Consultas.ArticuloConsulta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.ArticuloConsulta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        

        


    }
}
