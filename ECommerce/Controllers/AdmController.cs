using ECommerce.Models.Consultas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class AdmController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();
        public ActionResult Index()
        {
            if (Usuario != null)
            {
                switch (Usuario.Rol.Id)
                {
                    case 3:
                        return RedirectToAction("Index", "Administracion");
                    case 2:
                        return RedirectToAction("Index", "Operador");
                    case 1:
                        return RedirectToAction("Index", "Cliente");
                    default:
                        return View();
                        break;
                }
            }
            else
            {
                ViewBag.rd = Request.QueryString["rd"];
                ViewBag.rdv = Request.QueryString["rdv"];
                return View();
            }
            
        }
        public ActionResult Invitacion(Application.CarroElectronico APcarroElectronico)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (APcarroElectronico.CarroElectronico_Seleccionar_Clave(Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString())).Count > 0)
                {
                    if (Session["Sesion"] != null)
                    {
                        return RedirectToAction("DireccionUsuario", "VentaDireccion");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "CarroElectronico");
                }
            }
            else
            {
                return RedirectToAction("Index", "CarroElectronico");
            }
        }
        [HttpPost]
        public JsonResult Venta_ClienteInvitado()
        {
            Models.CatTipoPersona catTipoPersona = new Models.CatTipoPersona();
            catTipoPersona.Id = 3;  // VALOR Hard-code
            Models.Persona persona = new Models.Persona();
            persona.CatTipoPersona = catTipoPersona;
            Models.Usuario DataUser = new Models.Usuario();
            DataUser.Persona = persona;
            Session["SesionInvitacion"] = DataUser;
            Session["Sesion"] = null;
            Session["SesionClienteNuevo"] = null;
            return Json(catTipoPersona);
        }
        [HttpPost]
        public JsonResult Venta_ClienteNuevo()
        {
            Models.CatTipoPersona catTipoPersona = new Models.CatTipoPersona();
            catTipoPersona.Id = 1;  // VALOR Hard-code
            Models.Persona persona = new Models.Persona();
            persona.CatTipoPersona = catTipoPersona;
            Models.Usuario DataUser = new Models.Usuario();
            DataUser.Persona = persona;
            Session["SesionClienteNuevo"] = DataUser;
            Session["SesionInvitacion"] = null;
            Session["Sesion"] = null;
            return Json(catTipoPersona);
        }
        [HttpPost]
        public JsonResult IniciarSesion(Models.Usuario _usuario, Application.Usuario APusuario, Application.Menu APmenu)
        {
            Models.Usuario DataUser = APusuario.Iniciar(_usuario);

            if (DataUser.Id > 0)
            {
                Session["Sesion"] = DataUser;
                Session["SesionInvitacion"] = null;
                Session["SesionNuevoUsuario"] = null;

                if (_usuario.Session)
                {
                    Response.Cookies["SesionDT"].Value = Application.Cifrado.Encriptar(DataUser.ClaveCookie);
                }
            }

            if (!String.IsNullOrEmpty(_usuario.Rol.Ruta))
            {
                string url = Application.Cifrado.Desencriptar(_usuario.Rol.Ruta);
                menuPermiso.Rol = DataUser.Rol;
                Menu.URL = url;
                menuPermiso.Menu = Menu;
                if (APmenu.ValidacionPagina(menuPermiso))
                {
                    string Nu = Application.Cifrado.Desencriptar(_usuario.Rol.RutaAcceso);
                    DataUser.Rol.RutaAcceso = Nu;
                }
            }

            return Json(DataUser);
            
        }
        [HttpPost]
        public JsonResult CerrarSesion()
        {
            Models.Usuario DataUser = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
            Response.Cookies["SesionDT"].Value = null;

            Session.Abandon();

            if (DataUser != null)
            {
                return Json(DataUser);
            }
            else
            {
                return Json("Ha ocurrido un problema!");
            }
        }
        [HttpPost]
        public JsonResult Administracion_UsuarioActualizarPass(Models.Usuario usuario, Application.Usuario ApUsuario)
        {
            usuario.Id = Usuario.Id;
            Models.Usuario respuesta = ApUsuario.Administracion_UsuarioActualizarPass(usuario);

            return Json(respuesta);
        }
        [HttpPost]
        public JsonResult Administracion_UsuarioActualizarName(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Usuario ApUsuario)
        {
            usuarioInformacion.Persona.Id = Usuario.Id;
            Models.Usuario respuesta = ApUsuario.Administracion_UsuarioActualizarName(usuarioInformacion);

            return Json(respuesta);
        }
        [HttpPost]
        public JsonResult Administracion_UsuarioActualizarCorreo(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Usuario ApUsuario)
        {
            usuarioInformacion.Email.Id = Usuario.Id;
            Models.Usuario respuesta = ApUsuario.Administracion_UsuarioActualizarCorreo(usuarioInformacion);

            return Json(respuesta);
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



















        //public ActionResult Index(Application.Usuario usuario)
        //{
        //    Models.Usuarios Usuairo = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];

        //    if (Usuairo != null)
        //    {
        //        switch (Usuairo.IdRol)
        //        {
        //            case 1:
        //                return RedirectToAction("Index", "Administracion");
        //            case 2:
        //                return RedirectToAction("Index", "Operador");
        //            default:
        //                break;
        //        }
        //    }

        //    try
        //    {
        //        if (Request.Cookies["SesionDT"] != null)
        //        {
        //            if (Request.Cookies["SesionDT"].Value != "")
        //            {
        //                string Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["SesionDT"].Value.ToString());
        //                Models.Usuarios DtUsuer = usuario.coo_Session_Seleccionar(Clave);

        //                if (DtUsuer.IdUsuario > 0)
        //                {
        //                    Session["Sesion"] = DtUsuer;
        //                    Session["SesionInvitacion"] = null;
        //                    switch (DtUsuer.IdRol)
        //                    {
        //                        case 1:
        //                            return RedirectToAction("Index", "Administracion");
        //                        case 2:
        //                            return RedirectToAction("Index", "Operador");
        //                        default:
        //                            break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    ViewBag.rd = Request.QueryString["rd"];
        //    ViewBag.rdv = Request.QueryString["rdv"];
        //    return View();
        //}

        

        //[HttpPost]
        //public JsonResult Iniciar(Models.NuevoRegistro NuevoUsuario, Application.Usuario usuario, Application.Menu menu)
        //{
        //    if (NuevoUsuario != null)
        //    {
        //        Models.Usuarios DataUser = usuario.Iniciar(NuevoUsuario.usuarios);
        //        if (DataUser.IdUsuario > 0)
        //        {
        //            Session["Sesion"] = DataUser;
        //            Session["SesionInvitacion"] = null;
        //            if (NuevoUsuario.usuarios.Session)
        //            {
        //                Response.Cookies["SesionDT"].Value = Application.UrlCifrardo.Encrypt(DataUser.ClaveCoo);
        //            }
        //        }

        //        if (!String.IsNullOrEmpty(NuevoUsuario.usuarios.Ruta))
        //        {
        //            string url = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.Ruta);
        //            //if (menu.ValidacionPagina(DataUser, url))
        //            //{
        //            //    string Nu = Application.UrlCifrardo.Decrypt(NuevoUsuario.usuarios.RutaAcceso);
        //            //    DataUser.RutaAcceso = Nu;
        //            //}
        //        }

        //        return Json(DataUser);
        //    }
        //    else
        //    {
        //        return Json("Ha ocurrido un problema!");
        //    }
        //}

        //[HttpPost]
        //public JsonResult CerrarSesion()
        //{
        //    Models.Usuarios DataUser = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
        //    Response.Cookies["SesionDT"].Value = null;

        //    Session.Abandon();

        //    if (DataUser != null)
        //    {
        //        return Json(DataUser);
        //    }
        //    else
        //    {
        //        return Json("Ha ocurrido un problema!");
        //    }
        //}

        

        //[HttpPost]
        //public JsonResult Invitado_Agregar_Informacion(Models.Usuarios_Invitado usuarios_Invitado, Application.Usuarios_Invitado APusuarios_Invitado)
        //{
        //    string Clave = "";
        //    Models.Cliente cliente = new Models.Cliente();
        //    if (Request.Cookies["Carrito"] != null)
        //    {
        //        Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
        //        cliente = APusuarios_Invitado.Usuarios_Invitado_Agregar(Clave, usuarios_Invitado);
        //    }
        //    else
        //    {
        //        cliente.Id = 0;
        //    }
        //    return Json(cliente);
        //}

        [HttpPost]
        public JsonResult Usuario_Agregar_Informacion(Models.Usuarios_Direcciones usuarios_Direcciones, Application.Usuarios_Direcciones APusuarios_Direcciones)
        {
            string Clave = "";
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                Models.Usuarios Usuario = (Models.Usuarios)System.Web.HttpContext.Current.Session["Sesion"];
                Clave = Application.UrlCifrardo.Decrypt(Request.Cookies["Carrito"].Value.ToString());
                usuarios_Direcciones.IdUsuario = Usuario.IdUsuario;
                cliente = APusuarios_Direcciones.Usuarios_Direcciones_Agregar(Clave, usuarios_Direcciones);
            }
            else
            {
                cliente.Id = 0;
            }
            return Json(cliente);
        }

        [HttpPost]
        public JsonResult IniciarSesionCompra(Models.Usuarios usuarios, Application.Usuario usuario)
        {
            usuarios.Session = false;
            Models.Usuarios DataUser = usuario.Iniciar(usuarios);
            if (DataUser.IdUsuario > 0)
            {
                Session["Sesion"] = DataUser;
                Session["SesionInvitacion"] = null;
            }
            return Json(DataUser);
        }

        
    }
}
