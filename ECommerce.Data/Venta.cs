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
    public class Venta
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Venta SPNuevaVenta(Models.Venta venta)
        {
            const string consulta = "Ventas.SPNuevaVenta";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Clave", venta.CookieCarrito.Clave, SqlDbType.NVarChar);
            b.AddParameter("@IdCliente", venta.Cliente.Id, SqlDbType.Int);
            b.AddParameter("@IdMetodoPago", venta.CatMetodoPago.Id, SqlDbType.Int);
            b.AddParameter("@Referencia", venta.Referencia, SqlDbType.NVarChar);
            b.AddParameter("@Total", venta.Total, SqlDbType.Decimal);

            Models.Venta resultado = new Models.Venta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Venta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.Venta Venta_Seleccionar_Folio(Models.Folio folio)
        {
            const string consulta = "Ventas.Venta_Seleccionar_Folio";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Folio", folio.FolioCompuesto, SqlDbType.NVarChar);

            Models.Consultas.Venta resultado = new Models.Consultas.Venta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.Venta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.Venta Venta_Seleccionar_Id(Models.Venta venta)
        {
            const string consulta = "Ventas.Venta_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdVenta", venta.Id, SqlDbType.Int);

            Models.Consultas.Venta resultado = new Models.Consultas.Venta();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.Venta>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.Venta> Venta_Seleccionar_IdUsaurio(Models.Usuario usuario)
        {
            const string consulta = "Ventas.Venta_Seleccionar_IdUsaurio";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdUsuario", usuario.Id, SqlDbType.Int);

            List<Models.Consultas.Venta> resultado = new List<Models.Consultas.Venta>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.Venta>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }















        public List<Models.Venta> Venta_Listar_Pendientes(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Venta_Listar_Pendientes");
            b.AddParameter("@IdUsuario", usuarios.IdUsuario, SqlDbType.Int);
            List<Models.Venta> resultado = new List<Models.Venta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Venta item = new Models.Venta()
                {
                    //Folio = reader["FolioCompuesto"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Venta> Venta_Listar_Operador()
        {
            b.ExecuteCommandSP("Venta_Listar_Operador");
            List<Models.Venta> resultado = new List<Models.Venta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Venta item = new Models.Venta()
                {
                    //Folio = reader["FolioCompuesto"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Venta> Venta_Listar_Pendietes_Etapa_Total(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Venta_Listar_Pendietes_Etapa_Total");
            b.AddParameter("@IdUsuario", usuarios.IdUsuario, SqlDbType.Int);
            List<Models.Venta> resultado = new List<Models.Venta>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Venta item = new Models.Venta()
                {
                    Etapa = reader["Etapa"].ToString(),
                    Total = Convert.ToDecimal(reader["Total"]),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Articulo> Venta_Listar_Articulos(Models.Venta venta)
        {
            b.ExecuteCommandSP("Venta_Listar_Articulos");
            b.AddParameter("@IdVenta", venta.Id, SqlDbType.Int);
            List<Models.Articulo> resultado = new List<Models.Articulo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Articulo item = new Models.Articulo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    SKU = reader["SKU"].ToString(),
                    PrecioText = reader["PrecioText"].ToString(),
                    Largo = reader["Largo"].ToString(),
                    Ancho = reader["Ancho"].ToString(),
                    Altura = reader["Altura"].ToString(),
                    Peso = reader["Peso"].ToString(),
                    Id = Convert.ToInt32(reader["Id"]),
                    Imagen = reader["Imagen"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Venta_Consultar Venta_Consultar_Id(Models.Venta venta)
        {
            b.ExecuteCommandSP("Venta_Consultar_Id");
            b.AddParameter("@IdVenta", venta.Id, SqlDbType.Int);

            Models.Venta_Consultar resultado = new Models.Venta_Consultar();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Folio = reader["Folio"].ToString();
                resultado.FechaRegistro = reader["FechaRegistro"].ToString();
                resultado.NombreUsuario = reader["NombreUsuario"].ToString();
                resultado.Correo = reader["Correo"].ToString();
                resultado.Estado = reader["Estado"].ToString();
                resultado.Poblacion = reader["Poblacion"].ToString();
                resultado.Colonia = reader["Colonia"].ToString();
                resultado.CP = reader["CP"].ToString();
                resultado.NombreDireccion = reader["NombreDireccion"].ToString();
                resultado.NumExterior = reader["NumExterior"].ToString();
                resultado.NumInteriror = reader["NumInteriror"].ToString();
                resultado.Calle = reader["Calle"].ToString();
                resultado.EntreCalles = reader["EntreCalles"].ToString();
                resultado.Referencias = reader["Referencias"].ToString();
                resultado.Fiscal = Convert.ToInt32(reader["Fiscal"].ToString());
                resultado.Flag = Convert.ToInt32(reader["Flag"].ToString());
                resultado.RecibirPedido = Convert.ToInt32(reader["RecibirPedido"].ToString());
                resultado.Recibe_Nombre = reader["Recibe_Nombre"].ToString();
                resultado.Recibe_Apellidos = reader["Recibe_Apellidos"].ToString();
                resultado.Recibe_Telefono = reader["Recibe_Telefono"].ToString();
                resultado.Recibe_TipoTelefono = reader["Recibe_TipoTelefono"].ToString();
                resultado.MetodoPago = reader["MetodoPago"].ToString();
                resultado.Referencia = reader["Referencia"].ToString();
                resultado.PrecioText = reader["PrecioText"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Venta_Consultar SPProcesarVenta(Models.Venta venta)
        {
            b.ExecuteCommandSP("SPProcesarVenta");
            b.AddParameter("@IdVenta", venta.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", venta.IdUsuario, SqlDbType.Int);

            Models.Venta_Consultar resultado = new Models.Venta_Consultar();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Articulo Venta_Articulos_Agregar(Models.Carro_Electronico carro_Electronico)
        {
            b.ExecuteCommandSP("Venta_Articulos_Agregar");
            b.AddParameter("@IdVenta", carro_Electronico.Id, SqlDbType.Int);
            b.AddParameter("@IdArticulo", carro_Electronico.IdArticulo, SqlDbType.Int);
            b.AddParameter("@Item", carro_Electronico.Item, SqlDbType.Int);
            b.AddParameter("@Precio", carro_Electronico.Precio, SqlDbType.Decimal);

            Models.Articulo resultado = new Models.Articulo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cliente Venta_Direcciones_Seleccionar (Models.Usuarios_Direcciones usuarios_Direcciones, string clave)
        {
            b.ExecuteCommandSP("Venta_Direcciones_Seleccionar");
            b.AddParameter("@IdDireccion", usuarios_Direcciones.IdDireccion, SqlDbType.Int);
            b.AddParameter("@IdUsuario", usuarios_Direcciones.IdUsuario, SqlDbType.Int);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);

            Models.Cliente resultado = new Models.Cliente();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


    }
}
