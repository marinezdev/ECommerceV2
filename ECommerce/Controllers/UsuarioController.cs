
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Administracion
        public ActionResult Index(Application.Menu menu)
        {
            string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

            //if (menu.ValidacionPagina(Usuairo, url))
            if (true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.UrlCifrardo.Encrypt(cadena), @rdv = Application.UrlCifrardo.Encrypt(url) });
            }
        }
        [HttpPost]
        public JsonResult Usuario_Agregar(Application.Usuario APusuario)
        {
            Models.Usuario usuario = new Models.Usuario();
            Models.Usuario usuario2 = new Models.Usuario();
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                usuario = APusuario.Usuario_Agregar(_NuevoUsuario);

                _NuevoUsuario.Usuario.usuario = _NuevoUsuario.Email.email;
                usuario = APusuario.Iniciar(_NuevoUsuario.Usuario);
                if (usuario.Id > 0)
                {
                    Session["Sesion"] = usuario;
                    Session["SesionInvitacion"] = null;
                    Session["SesionNuevoUsuario"] = null;

                    if (Session["SesionClienteNuevo"] != null)
                    {
                        usuario2.Id = 1;
                        Session["SesionClienteNuevo"] = null;
                    }
                    else
                    {
                        usuario2.Id = 2;
                    }
                }
            }
            else
            {
                usuario2.Id = 0;
            }
            return Json(usuario2);
        }
    }
}
