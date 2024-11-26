using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class RegistroController : Controller
    {
        public ActionResult TerminosCondiciones()
        {
            Session["SesionNuevoUsuario"] = null;
            return View();
        }
        public ActionResult Progreso()
        {
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                int email = 0;
                int persona = 0;
                if (_NuevoUsuario.Email != null)
                {
                    email = 1;
                }

                if (_NuevoUsuario.Persona != null)
                {
                    persona = 1;
                }

                ViewBag.Email = email;
                ViewBag.persona = persona;
                ViewBag.NuevoUsuario = _NuevoUsuario;

                return View();
            }
            else
            {
                return RedirectToAction("TerminosCondiciones", "Registro");
            }
        }
        public ActionResult EmailValidacion()
        {
            return View();
        }
        public ActionResult EmailVerificado()
        {
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                if(_NuevoUsuario.Email != null)
                {
                    ViewBag.Email = _NuevoUsuario.Email;
                    return View();
                }
                else
                {
                    return RedirectToAction("EmailValidacion", "Registro");
                }
            }
            else
            {
                return RedirectToAction("TerminosCondiciones", "Registro");
            }
        }
        public ActionResult NombreValidacion()
        {
            return View();
        }
        public ActionResult NombreVerificado()
        {
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                if (_NuevoUsuario.Persona != null)
                {
                    ViewBag.Persona = _NuevoUsuario.Persona.Nombre + " " + _NuevoUsuario.Persona.ApellidoPaterno + " " + _NuevoUsuario.Persona.ApellidoMaterno;
                    return View();
                }
                else
                {
                    return RedirectToAction("EmailValidacion", "Registro");
                }
            }
            else
            {
                return RedirectToAction("TerminosCondiciones", "Registro");
            }
        }
        public ActionResult ConfigurarValidacion()
        {
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                if (_NuevoUsuario.Persona != null)
                {
                    ViewBag.NuevoUsuario = _NuevoUsuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("NombreValidacion", "Registro");
                }
            }
            else
            {
                return RedirectToAction("TerminosCondiciones", "Registro");
            }
        }
        public ActionResult ConfigurarVerificado()
        {
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                if (_NuevoUsuario.Usuario != null)
                {
                    ViewBag.NuevoUsuario = _NuevoUsuario;
                    return View();
                }
                else
                {
                    return RedirectToAction("ConfigurarValidacion", "Registro");
                }
            }
            else
            {
                return RedirectToAction("TerminosCondiciones", "Registro");
            }
        }
        [HttpPost]
        public JsonResult NuevoUsuario_iniciar(Application.Token token)
        {
            Models.Consultas.NuevoUsuario _NuevoUsuario = new Models.Consultas.NuevoUsuario();
            Models.Token dbToke = token.Token_Agregar();
            dbToke.token = Application.Cifrado.Encriptar(dbToke.token);
            _NuevoUsuario.Toke = dbToke;
            Session["SesionNuevoUsuario"] = _NuevoUsuario;
            return Json(dbToke);
        }
        [HttpPost]
        public JsonResult NuevoUsuario_Email(Models.Email email, Application.Email APemail)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Email dbEmail = APemail.Email_Seleccionar_Email(email);
                if (dbEmail.Id == 0)
                {
                    Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                    _NuevoUsuario.Email = email;
                    Session["SesionNuevoUsuario"] = _NuevoUsuario;
                    // ENVIA DE CORREO ELECTRONICO, NOTIFICACION.
                    // mensaje = nuevoUsuario.ConfirmarEmail(email);
                    // mensaje.Respuesta = true;
                    mensaje.Id = 3;
                }
                else
                {
                    mensaje.Id = 2;
                }
            }
            else
            {
                mensaje.Id = 1;
            }
            return Json(mensaje);
        }
        [HttpPost]
        public JsonResult NuevoUsuario_Nombre(Models.Persona persona)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                _NuevoUsuario.Persona = persona;
                Session["SesionNuevoUsuario"] = _NuevoUsuario;
                mensaje.Id = 2;
            }
            else
            {
                mensaje.Id = 1;
            }
            return Json(mensaje);
        }
        [HttpPost]
        public JsonResult NuevoUsuario_Password(Models.Usuario usuario)
        {
            Models.Mensaje mensaje = new Models.Mensaje();
            if (Session["SesionNuevoUsuario"] != null)
            {
                Models.Consultas.NuevoUsuario _NuevoUsuario = (Models.Consultas.NuevoUsuario)System.Web.HttpContext.Current.Session["SesionNuevoUsuario"];
                _NuevoUsuario.Usuario = usuario;
                Session["SesionNuevoUsuario"] = _NuevoUsuario;
                mensaje.Id = 2;
            }
            else
            {
                mensaje.Id = 1;
            }
            return Json(mensaje);
        }
    }
}
