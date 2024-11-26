using ECommerce.Models;
using ECommerce.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class VentaDireccionController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();
        // GET: VentaDireccion
        public ActionResult DireccionInvitado(Application.CatEstados APcatEstados, Application.CarroElectronico APCarroElectronico)
        {
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);

                    decimal Precio = 0;
                    foreach (var dt in Lista)
                    {
                        Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                    }
                    string s = string.Format("{0:N2}", Precio); // No fear of rounding and takes the default number format
                                                                //String s = String.Format("{0:#,##0.##}", Precio);

                    ViewBag.Estados = APcatEstados.CatEstados_Seleccionar();
                    ViewBag.Total = s;
                    ViewBag.ListaArticulos = Lista;

                    return View();
                }
                else
                {
                    return RedirectToAction("Invitacion", "Adm");
                }
            }
            else
            {
                return RedirectToAction("Invitacion", "Adm");
            }
        }

        public ActionResult DireccionUsuario(Application.CatEstados APcatEstados, Application.CarroElectronico APCarroElectronico, Application.Direccion APdireccion, Application.Persona APpersona)
        {
            if (ValidaUsuario())
            {
                List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                List<Models.PersonaDireccion> ListaDireciones = APdireccion.Direccion_Seleccionar_IdUsuario(Usuario);
                Models.Consultas.UsuarioInformacion usuarioInformacion = APpersona.Persona_Seleccionar_Id(Usuario.Persona);

                if (Request.Cookies["Carrito"] != null)
                {
                    string ClaveCarro = Application.Cifrado.Desencriptar(Request.Cookies["Carrito"].Value.ToString());
                    Lista = APCarroElectronico.CarroElectronico_Seleccionar_Clave(ClaveCarro);
                }

                decimal Precio = 0;
                foreach (var dt in Lista)
                {
                    Precio += (Convert.ToDecimal(dt.CarroElectronico.Item) * Convert.ToDecimal(dt.ArticuloDetalle.PrecioPublico));
                }
                string s = string.Format("{0:N2}", Precio); 

                ViewBag.Estados = APcatEstados.CatEstados_Seleccionar();
                ViewBag.Total = s;
                ViewBag.ListaArticulos = Lista;

                ViewBag.ListaDireciones = ListaDireciones;
                ViewBag.UsuarioInformacion = usuarioInformacion;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }        
        }


        [HttpPost]
        public JsonResult Cliente_Agregar_Informacion_Invitado(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["SesionInvitacion"] != null)
                {
                    /// TIPO DE USUAIRO INVITADO
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 1;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.PersonaDireccion.Nombre = "DOMICILIO PRINCIPAL";
                    cliente = APPersona.Persona_Cliente_Agregar(usuarioInformacion);
                    Session["SesionInvitacion"] = cliente;
                }
                else
                {
                    cliente.Id = -2;
                }
            }
            else
            {
                cliente.Id = -1;
            }
            return Json(cliente);
        }
        [HttpPost]
        public JsonResult Cliente_Agregar_NuevaDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["Sesion"] != null)
                {
                    /// TIPO DE USUAIRO INVITADO
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.PersonaDireccion.Nombre = "DOMICILIO PRINCIPAL";
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_NuevaDireccion(usuarioInformacion);
                    Session["SesionInvitacion"] = cliente;
                }
                else
                {
                    cliente.Id = -2;
                }
            }
            else
            {
                cliente.Id = -1;
            }
            return Json(cliente);
        }
        [HttpPost]
        public JsonResult Cliente_Agregar_NuevaDireccion_Nueva(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["Sesion"] != null)
                {
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_NuevaDireccion(usuarioInformacion);
                    Session["SesionInvitacion"] = cliente;
                }
                else
                {
                    cliente.Id = -2;
                }
            }
            else
            {
                cliente.Id = -1;
            }
            return Json(cliente);
        }
        [HttpPost]
        public JsonResult Cliente_Agregar_EditarDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["Sesion"] != null)
                {
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_EditarDireccion(usuarioInformacion);
                    Session["SesionInvitacion"] = cliente;
                }
                else
                {
                    cliente.Id = -2;
                }
            }
            else
            {
                cliente.Id = -1;
            }
            return Json(cliente);
        }
        [HttpPost]
        public JsonResult Cliente_Agregar_SelectDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            if (Request.Cookies["Carrito"] != null)
            {
                if (Session["Sesion"] != null)
                {
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_SelectDireccion(usuarioInformacion);
                    Session["SesionInvitacion"] = cliente;
                }
                else
                {
                    cliente.Id = -2;
                }
            }
            else
            {
                cliente.Id = -1;
            }
            return Json(cliente);
        }
        [HttpPost]
        public JsonResult Direccion_Seleccionar_Id(Models.PersonaDireccion personaDireccion, Application.Direccion APDireccion)
        {
            Models.PersonaDireccion dbDireccion  = APDireccion.Direccion_Seleccionar_Id(personaDireccion);
            return Json(dbDireccion);
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
