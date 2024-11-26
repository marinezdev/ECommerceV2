using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class PersonaDireccionController : Controller
    {
        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];


        [HttpPost]
        public JsonResult Cliente_Agregar_SelectDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            //if (Request.Cookies["Carrito"] != null)
            //{
            //    if (Session["Sesion"] != null)
            //    {
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_SelectDireccion(usuarioInformacion);
                    //Session["SesionInvitacion"] = cliente;
            //    }
            //    else
            //    {
            //        cliente.Id = -2;
            //    }
            //}
            //else
            //{
            //    cliente.Id = -1;
            //}
            return Json(cliente);
        }

        [HttpPost]
        public JsonResult Cliente_Agregar_NuevaDireccion_Nueva(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
  
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_NuevaDireccion(usuarioInformacion);
              
            return Json(cliente);
        }

        [HttpPost]
        public JsonResult Cliente_Agregar_EditarDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion, Application.Persona APPersona)
        {
            Models.Cliente cliente = new Models.Cliente();
            //if (Request.Cookies["Carrito"] != null)
            //{
            //    if (Session["Sesion"] != null)
            //    {
                    Models.CatTipoCliente catTipoCliente = new Models.CatTipoCliente();
                    catTipoCliente.Id = 2;
                    usuarioInformacion.CatTipoCliente = catTipoCliente;
                    usuarioInformacion.Persona = Usuario.Persona;
                    cliente = APPersona.Persona_Cliente_Agregar_EditarDireccion(usuarioInformacion);
                    //Session["SesionInvitacion"] = cliente;
            //    }
            //    else
            //    {
            //        cliente.Id = -2;
            //    }
            //}
            //else
            //{
            //    cliente.Id = -1;
            //}
            return Json(cliente);
        }
    }
}