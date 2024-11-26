using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CarroElectronicoController : Controller
    {
        public ActionResult Index(Application.CarroElectronico APCarroElectronico)
        {
            List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
            }

            decimal Precio = 0;
            if (Lista != null)
            {
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                }
            }
            
            string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                        //String s = String.Format("{0:#,##0.##}", Precio);

            ViewBag.Total = s;
            ViewBag.ListaArticulos = Lista;

            return View();
        }
        [HttpPost]
        public JsonResult CarroElectronico_Agregar(Models.CarroElectronico carroElectronico, Application.CookieCarrito APcookieCarrito, Application.CarroElectronico APcarroElectronico)
        {
            Models.CarroElectronico _carroElectronico = new Models.CarroElectronico();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                _carroElectronico = APcarroElectronico.CarroElectronico_Agregar(carroElectronico, ClaveCarro);
            }
            else
            {
                Models.CookieCarrito cookie_Carrito1 = APcookieCarrito.CookieCarrito_Agregar();
                Response.Cookies["Carrito"].Value = Application.Cifrado.Encriptar(cookie_Carrito1.Clave);
                _carroElectronico = APcarroElectronico.CarroElectronico_Agregar(carroElectronico, cookie_Carrito1.Clave);
            }
            return Json(_carroElectronico);
        }
        [HttpPost]
        public JsonResult CarroElectronico_Consultar_Total(Application.CarroElectronico APcarroElectronico)
        {
            Models.CarroElectronico carroElectronico = new Models.CarroElectronico();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                carroElectronico = APcarroElectronico.CarroElectronico_Seleccionar_Total(ClaveCarro);
            }
            return Json(carroElectronico);
        }
        [HttpPost]
        public JsonResult CarroElectronico_Eliminar_Articulo(Models.CarroElectronico carroElectronico, Application.CarroElectronico APCarroElectronico)
        {
            Models.CarroElectronico _carroElectronico = new Models.CarroElectronico();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                _carroElectronico = APCarroElectronico.CarroElectronico_Eliminar(carroElectronico, ClaveCarro);
            }

            return Json(_carroElectronico);
        }
        [HttpPost]
        public JsonResult CarroElectronico_Seleccionar_Clave(Application.CarroElectronico APCarroElectronico)
        {
            List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
            }
            return Json(Lista);
        }
        [HttpPost]
        public JsonResult CarroElectronico_Actualizar(Models.CarroElectronico carroElectronico, Application.CarroElectronico APCarroElectronico)
        {
            List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
            if (Request.Cookies["Carrito"] != null)
            {
                string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                Models.CarroElectronico  dbCarroEletronico = APCarroElectronico.CarroElectronico_Actualizar(carroElectronico, ClaveCarro);
                Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
            }
            return Json(Lista);
        }
    }
}
