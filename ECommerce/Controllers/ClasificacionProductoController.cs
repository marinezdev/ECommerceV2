using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ClasificacionProductoController : Controller
    {
        // GET: Clasificacion
        public ActionResult Index(Application.Cat_TiendaPromo Acat_TiendaPromo, Application.Cat_Clasificacion Acat_Clasificacion)
        {
            int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
            Models.Cat_Clasificacion cat_Clasificacion = new Models.Cat_Clasificacion();
            cat_Clasificacion.Id = Id;

            ViewBag.Promos = Acat_TiendaPromo.Cat_TiendaPromo_Listar(2);

            ViewBag.Clasificacion = Acat_Clasificacion.Cat_Clasificacion_PorId(cat_Clasificacion);

            ViewBag.ClasificacionA = Acat_Clasificacion.Cat_Clasificacion_ListarAleatorio();

            return View();
        }

        [HttpPost]
        public JsonResult Clasificacion_Agregar(Models.CatClasificacion catClasificacion, Application.CatClasificacion APcatClasificacion)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneClasificacion"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneClasificacion"];
            }

            catClasificacion.Imagen = LstArticuloImg[0].ImagenURL;
            Models.CatClasificacion cat_Clasificacion2 = APcatClasificacion.CatClasificacion_Agregar(catClasificacion);

            if (cat_Clasificacion2.Id > 0)
            {
                Session["ImageneClasificacion"] = null;
            }

            return Json(cat_Clasificacion2);
        }

        [HttpPost]
        public JsonResult Clasificacion_Seleccionar_IdSubCategoria(Models.CatSubcategoria catSubcategoria, Application.CatClasificacion APcatClasificacion)
        {
            List<Models.CatClasificacion> DBcat_Clasificacions = APcatClasificacion.CatClasificacion_Seleccionar_IdSubCategoria(catSubcategoria);
            return Json(DBcat_Clasificacions);
        }

        [HttpPost]
        public JsonResult CargaImagenesClasificacion(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            Session["ImageneClasificacion"] = null;

            foreach (var dt in ListaImagenes)
            {
                LstArticuloImg.Add(dt);
            }

            Session["ImageneClasificacion"] = LstArticuloImg;

            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult ConsulltaImagenesClasificacion()
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneClasificacion"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneClasificacion"];
            }

            return Json(LstArticuloImg);
        }
    }
}