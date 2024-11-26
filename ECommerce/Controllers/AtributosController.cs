using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AtributosController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();

        // GET: Atributos
        public ActionResult Index(Application.CatCategoriaProducto APcat_CategoriaProducto, Application.CatTipoDatos APcatTipoDatos)
        {
            if (ValidaUsuario())
            {
                ViewBag.cat_CategoriaProducto = APcat_CategoriaProducto.CatCategoriaProducto_Seleccionar();
                ViewBag.cat_TipoDatos = APcatTipoDatos.CatTipoDatos_Seleccionar();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }
        [HttpPost]
        public JsonResult Atributo_Buscar(Models.CatAtributos catAtributos, Application.CatAtributos APcatAtributos)
        {
            List<Models.CatAtributos> ResulAtributos = APcatAtributos.CatAtributos_Seleccionar_IdClasificacion(catAtributos);
            return Json(ResulAtributos);
        }
        [HttpPost]
        public JsonResult Atributo_Agregar(Models.CatAtributos catAtributos, Application.CatAtributos APcatAtributos)
        {
            Models.CatAtributos ResulAtributos = APcatAtributos.CatAtributos_Agregar(catAtributos);
            return Json(ResulAtributos);
        }
        [HttpPost]
        public JsonResult Atributo_Eliminar(Models.CatAtributos catAtributos, Application.CatAtributos APcatAtributos)
        {
            Models.CatAtributos ResulAtributos = APcatAtributos.CatAtributos_Eliminar(catAtributos);
            return Json(ResulAtributos);
        }
        [HttpPost]
        public JsonResult Atributo_Buscar_Id(Models.CatAtributos catAtributos, Application.CatAtributos APcatAtributos)
        {
            Models.CatAtributos ResulAtributos = APcatAtributos.CatAtributos_Seleccionar_Id(catAtributos);
            return Json(ResulAtributos);
        }
        [HttpPost]
        public JsonResult Atributo_Editar(Models.CatAtributos catAtributos, Application.CatAtributos APcatAtributos)
        {
            Models.CatAtributos ResulAtributos = APcatAtributos.CatAtributos_Editar(catAtributos);
            return Json(ResulAtributos);
        }

        public bool ValidaUsuario()
        {
            bool result = false;
            Application.Menu APmenu = new Application.Menu();

            try
            {
                menuPermiso.Rol = Usuario.Rol;
                Menu.URL = url;
                menuPermiso.Menu = Menu;
                if (APmenu.ValidacionPagina(menuPermiso))
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
