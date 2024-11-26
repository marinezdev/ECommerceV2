using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class CategoriaController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();

        public ActionResult Index(Application.CatCategoriaProducto APcatCategoriaProducto)
        {
            if (ValidaUsuario())
            {
                List<Models.CatCategoriaProducto> dtCategorias = APcatCategoriaProducto.CatCategoriaProducto_Seleccionar();

                ViewBag.Categorias = dtCategorias;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }

        [HttpPost]
        public JsonResult Categoria_Agregar(Models.CatCategoriaProducto catCategoriaProducto, Application.CatCategoriaProducto APcatCategoriaProducto)
        {
            Models.CatCategoriaProducto cat_Categoria = APcatCategoriaProducto.CatCategoriaProducto_Agregar(catCategoriaProducto);
            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult Categoria_Seleccionar(Application.CatCategoriaProducto APcatCategoriaProducto)
        {
            List<Models.CatCategoriaProducto> dtCategorias = APcatCategoriaProducto.CatCategoriaProducto_Seleccionar();
            return Json(dtCategorias);
        }

        [HttpPost]
        public JsonResult Categoria_Actualizar(Models.CatCategoriaProducto catCategoriaProducto, Application.CatCategoriaProducto APcatCategoriaProducto)
        {
            Models.CatCategoriaProducto dbcat_Categoria = new Models.CatCategoriaProducto();
            return Json(dbcat_Categoria);
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
