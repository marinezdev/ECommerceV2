using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ClienteController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();

        // GET: Administracion
        public ActionResult Index(Application.Usuario Appusuario)
         {
            if (ValidaUsuario())
            {

                ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);



                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }
        public ActionResult Datos(Application.Usuario Ausuario)
        {



            ViewBag.User = Ausuario.Usuario_Usuario_Seleccionar_Id(Usuario);

            return View();

        }
        public ActionResult Seguridad(Application.Usuario Appusuario)
        {
            if (ValidaUsuario())
            {
                ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);




                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }

        }
        public ActionResult Buscar(Application.Usuario Appusuario)
        {
            ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);


            return View();
        }
        public ActionResult Configuracion(Application.Usuario Appusuario)
        {
            ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);

            return View();
        }


        public ActionResult Direcciones(Application.Usuario Appusuario, Application.CatEstados APcatEstados,
            Application.CarroElectronico APCarroElectronico, Application.Direccion APdireccion, Application.Persona APpersona)
        {
            //if (ValidaUsuario())
            //{
                List<Models.Consultas.CarroElectronicoArticulo> Lista = new List<Models.Consultas.CarroElectronicoArticulo>();
                List<Models.PersonaDireccion> ListaDireciones = APdireccion.Direccion_Seleccionar_IdUsuario(Usuario);
                Models.Consultas.UsuarioInformacion usuarioInformacion = APpersona.Persona_Seleccionar_Id(Usuario.Persona);

         

                ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);


                ViewBag.Estados = APcatEstados.CatEstados_Seleccionar();
               

                ViewBag.ListaDireciones = ListaDireciones;
                ViewBag.UsuarioInformacion = usuarioInformacion;

                return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            //}
        }
        public ActionResult MisPedidos(Application.Venta APVenta)
        {
            if (ValidaUsuario())
            {
                List<Models.Consultas.Venta> ListVentas = APVenta.Venta_Seleccionar_IdUsaurio(Usuario);
                ViewBag.ListVentas = ListVentas;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }
        public ActionResult RastrearPedido(Application.Venta APVenta, Application.VentaArticulo APventaArticulo)
        {
            if (ValidaUsuario())
            {
                if (!String.IsNullOrEmpty(Request.QueryString["F"]))
                {
                    Models.Venta _venta = new Models.Venta();
                    List<Models.Consultas.ArticuloConsulta> dbArticulos = new List<Models.Consultas.ArticuloConsulta>();
                    _venta.Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["F"].ToString()));

                    Models.Consultas.Venta dbventa = APVenta.Venta_Seleccionar_Id(_venta);
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
                    return RedirectToAction("MisPedidos", "Ciente");
                }
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }

        public ActionResult Privacidad(Application.Usuario Appusuario)
        {
            ViewBag.User = Appusuario.Usuario_Usuario_Seleccionar_Id(Usuario);


            return View();
        }
        public bool ValidaUsuario( )
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
        [HttpPost]
        public JsonResult EviarCodigoVerificacion(Models.Email correo)
        {
            Models.Usuario usuario = new Models.Usuario();
            Application.Correo.NuevoUsuario email = new Application.Correo.NuevoUsuario();
            Application.CodigoVeridicacion codigoVeridicacion = new Application.CodigoVeridicacion();

            usuario.Id = Usuario.Id;

            Models.CodigoVeridicacion codigo = codigoVeridicacion.Administracion_CodigoVeridicacion_Generar(usuario);
            var respuesta = email.ConfirmarEmail(correo, codigo);
            return Json(respuesta);
        }
    }
}
