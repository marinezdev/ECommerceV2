using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ArticuloComentarioController : Controller
    {   Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        [HttpPost]
        public JsonResult ArticuloComentario_Agregar(Models.ArticuloComentario articuloComentario, Application.ArticuloComentario APArticuloComentario)
        {
            articuloComentario.Usuario = Usuario;
            Models.ArticuloComentario DBArticuloComentario = APArticuloComentario.ArticuloComentario_Agregar(articuloComentario);
            return Json(DBArticuloComentario);
        }
        [HttpPost]
        public JsonResult ArticuloComentario_ContarPaginas_IdArticulo(Models.Articulo articulo, Application.ArticuloComentario APArticuloComentario)
        {
            Models.ArticuloComentario DBArticuloComentario = APArticuloComentario.ArticuloComentario_ContarPaginas_IdArticulo(articulo);
            return Json(DBArticuloComentario);
        }
        [HttpPost]
        public JsonResult ArticuloComentario_Seleccionar_PorPagina(Models.ArticuloComentario articuloComentario, Application.ArticuloComentario AParticulo_Comentario)
        {
            List<Models.ArticuloComentario> DBArticuloComentario = AParticulo_Comentario.ArticuloComentario_Seleccionar_PorPagina(articuloComentario.Articulo, articuloComentario.NumPaginas);
            return Json(DBArticuloComentario);
        }
    }
}
