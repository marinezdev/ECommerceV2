using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ECommerce.Controllers
{
    public class SubcategoriaProductoController : Controller
    {
        // GET: SubcategoriaProductos
        public ActionResult Index(Application.Cat_TiendaPromo Acat_TiendaPromo, Application.Cat_Subcategoria Acat_SubCategoriaProducto,
            Application.Cat_Clasificacion Acat_Clasificacion)
        {
            int Id = Convert.ToInt32(Application.Cifrado.Desencriptar(Request.QueryString["Id"]));
            Models.Cat_Subcategoria cat_Subcategoria = new Models.Cat_Subcategoria();
            cat_Subcategoria.Id = Id;

            ViewBag.Promos = Acat_TiendaPromo.Cat_TiendaPromo_Listar(3);

            ViewBag.SubCategorias = Acat_SubCategoriaProducto.Cat_Subcategoria_PorId(cat_Subcategoria);

            ViewBag.Clasificacion = Acat_Clasificacion.Cat_Clasificacion_ListarAleatorio();


            return View();
        }

        [HttpPost]
        public JsonResult Subcategoria_Seleccionar_IdCategoria(Models.CatCategoriaProducto catCategoriaProducto, Application.CatSubcategoria APcatSubcategoria)
        {
            List<Models.CatSubcategoria> dbCatSubcategorias = APcatSubcategoria.CatSubcategoria_Seleccionar_IdCategoria(catCategoriaProducto);
            return Json(dbCatSubcategorias);
        }

        [HttpPost]
        public JsonResult Subcategoria_Agregar(Models.CatSubcategoria catSubcategoria, Application.CatSubcategoria APcatSubcategoria)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneSubCategoria"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneSubCategoria"];
            }

            catSubcategoria.Imagen = LstArticuloImg[0].ImagenURL;
            Models.CatSubcategoria cat_Categoria = APcatSubcategoria.CatSubcategoria_Agregar(catSubcategoria);

            if (cat_Categoria.Id > 0)
            {
                Session["ImageneSubCategoria"] = null;
            }

            return Json(cat_Categoria);
        }

        [HttpPost]
        public JsonResult CargaImagenes(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();
            Session["ImageneSubCategoria"] = null;

            foreach (var dt in ListaImagenes)
            {
                LstArticuloImg.Add(dt);
            }

            Session["ImageneSubCategoria"] = LstArticuloImg;
            return Json(LstArticuloImg);
        }

        [HttpPost]
        public JsonResult ConsulltaImagenes()
        {
            List<Models.ArticuloImg> LstArticuloImg = new List<Models.ArticuloImg>();

            if (Session["ImageneSubCategoria"] != null)
            {
                LstArticuloImg = (List<Models.ArticuloImg>)Session["ImageneSubCategoria"];
            }
            return Json(LstArticuloImg);
        }
    }
}