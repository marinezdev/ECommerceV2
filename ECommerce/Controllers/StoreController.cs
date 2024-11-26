using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index(Application.Articulo articulo)
        {
            ViewBag.SubCategorias = articulo.Articulo_Seleccionar_TotalSubCategoria();
            ViewBag.UltimosArticulos = articulo.Articulo_Seleccionar_UltimosArticulos();
            ViewBag.Articulos = articulo.Articulo_Seleccionar();

            return View();
        }

        public ActionResult ArticuloDetalle(Application.ArticuloImagen AParticuloImagen, Application.Articulo AParticulo, Application.ArticuloAtributo APArticuloAtributo, Application.ArticuloComentario APArticuloComentario)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Arti"]))
            {
                Models.Articulo articulo = new Models.Articulo();
                articulo.Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Arti"]));
                List<Models.ArticuloImagen> ListArticuloImagen = AParticuloImagen.ArticuloImagen_Seleccionar_IdArticulo(articulo);
                Models.Consultas.ArticuloConsulta dtArticulo = AParticulo.Articulo_Seleccionar_IdArticulo(articulo);
                List<Models.ArticuloComentario> LisArticuloComentario = APArticuloComentario.ArticuloComentario_Seleccionar_PorPagina(articulo, 1);
                List<Models.ArticuloAtributo> articuloAtributos = APArticuloAtributo.ArticuloAtributo_Seleccionar_IdArticulo(articulo);
                Models.ArticuloComentario articuloComentarioPaginas = APArticuloComentario.ArticuloComentario_ContarPaginas_IdArticulo(articulo);

                Models.CatClasificacion _catClasificacion = new Models.CatClasificacion();
                _catClasificacion = dtArticulo.CatClasificacion;
                string Contenido = AParticulo.Articulo_Selecionar_IdClasificacion(_catClasificacion);

                ViewBag.Clasificacion = _catClasificacion;
                ViewBag.Articulos = Contenido;

                ViewBag.Imgs = ListArticuloImagen;
                ViewBag.ArticuloConsulta = dtArticulo;
                ViewBag.ArticuloAtributos = articuloAtributos;

                ViewBag.Comentarios = LisArticuloComentario;
                ViewBag.Paginador = articuloComentarioPaginas.NumPaginas;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Store");
            }


        }
    }
}
