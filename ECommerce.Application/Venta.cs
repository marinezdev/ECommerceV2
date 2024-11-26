using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Venta
    {
        Data.Venta _Venta = new Data.Venta();

        public Models.Venta SPNuevaVenta(Models.Venta venta)
        {
            return _Venta.SPNuevaVenta(venta);
        }
        public Models.Consultas.Venta Venta_Seleccionar_Folio(Models.Folio folio)
        {
            return _Venta.Venta_Seleccionar_Folio(folio);
        }
        public Models.Consultas.Venta Venta_Seleccionar_Id(Models.Venta venta)
        {
            return _Venta.Venta_Seleccionar_Id(venta);
        }
        public List<Models.Consultas.Venta> Venta_Seleccionar_IdUsaurio(Models.Usuario usuario)
        {
            return _Venta.Venta_Seleccionar_IdUsaurio(usuario);
        }





















        public List<Models.Venta> Venta_Listar_Pendientes(Models.Usuarios usuarios)
        {
            return _Venta.Venta_Listar_Pendientes(usuarios);
        }
        public List<Models.Venta> Venta_Listar_Operador()
        {
            return _Venta.Venta_Listar_Operador();
        }
        public List<Models.Venta> Venta_Listar_Pendietes_Etapa_Total(Models.Usuarios usuarios)
        {
            return _Venta.Venta_Listar_Pendietes_Etapa_Total(usuarios);
        }
        public List<Models.Articulo> Venta_Listar_Articulos(Models.Venta venta)
        {
            return _Venta.Venta_Listar_Articulos(venta);
        }
        public Models.Venta_Consultar Venta_Consultar_Id(Models.Venta venta)
        {
            return _Venta.Venta_Consultar_Id(venta);
        }
        public Models.Venta_Consultar SPProcesarVenta(Models.Venta venta)
        {
            return _Venta.SPProcesarVenta(venta);
        }

        //public Models.Articulo Venta_Articulos_Agregar(Models.Carro_Electronico carro_Electronico)
        //{
        //    return _Venta.Venta_Articulos_Agregar(carro_Electronico);
        //}
        public Models.Cliente Venta_Direcciones_Seleccionar(Models.Usuarios_Direcciones usuarios_Direcciones, string clave)
        {
            return _Venta.Venta_Direcciones_Seleccionar(usuarios_Direcciones, clave);
        }
    }
}
