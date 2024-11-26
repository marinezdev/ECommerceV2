using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class RastreaPedidosController : Controller
    {
        // GET: RastreaPedidos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rastreo(Application.Venta APVenta, Application.VentaArticulo APventaArticulo)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["F"]))
            {
                Models.Venta _venta = new Models.Venta();
                Models.Folio _Folio = new Models.Folio();
                List<Models.Consultas.ArticuloConsulta> dbArticulos = new List<Models.Consultas.ArticuloConsulta>();
                _Folio.FolioCompuesto = Application.Cifrado.Desencriptar(Request.QueryString["F"].ToString());

                Models.Consultas.Venta dbventa = APVenta.Venta_Seleccionar_Folio(_Folio);
                if (dbventa.Id > 0)
                {
                    _venta.Id = dbventa.Id;
                    dbArticulos = APventaArticulo.VentaArticulo_Seleccionar_IdVenta(_venta);
                }


                ViewBag.Venta = dbventa;
                ViewBag.Articulos = dbArticulos;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "RastreaPedido");
            }
        }

    }
}
