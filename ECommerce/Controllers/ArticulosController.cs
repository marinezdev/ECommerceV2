using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ArticulosController : Controller
    {

        Models.Usuario Usuario = (Models.Usuario)System.Web.HttpContext.Current.Session["Sesion"];
        string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        string cadena = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        Models.MenuPermiso menuPermiso = new Models.MenuPermiso();
        Models.Menu Menu = new Models.Menu();

        public ActionResult NuevoArticulo(Application.Flujo flujo, Application.CatCategoriaProducto APcatCategoriaProducto, Application.CatTipoDatos APcatTipoDatos, Application.CatMoneda catMoneda)
        {
            if (ValidaUsuario())
            {
                ViewBag.cat_CategoriaProducto = APcatCategoriaProducto.CatCategoriaProducto_Seleccionar();
                ViewBag.flujo = flujo.Flujo_Seleccionar();
                ViewBag.cat_TipoDatos = APcatTipoDatos.CatTipoDatos_Seleccionar();
                ViewBag.cat_Moneda = catMoneda.CatMoneda_Seleccionar();

                Session["Imagenes"] = null;
                Session["AtributosArticulo"] = null;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Adm", new { @rd = Application.Cifrado.Encriptar(cadena), @rdv = Application.Cifrado.Encriptar(url) });
            }
        }
        [HttpPost]
        public JsonResult Articulo_registrar(Models.Consultas.NuevoArticulo nuevoArticulo, Application.Articulo ApArticulo, Application.ArticuloAtributo APArticuloAtributo, Application.ArticuloImagen AParticuloImagen)
        {
            Models.Articulo Newarticulo = new Models.Articulo();
            List<Models.CatAtributos> LstCat_Atributos = new List<Models.CatAtributos>();
            List<Models.ArticuloImg> LstArticuloImagen = new List<Models.ArticuloImg>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.CatAtributos>)Session["AtributosArticulo"];
            }

            if (Session["Imagenes"] != null)
            {
                LstArticuloImagen = (List<Models.ArticuloImg>)Session["Imagenes"];
            }


            Newarticulo = ApArticulo.Articulo_agregar(nuevoArticulo);

            if (Newarticulo.Id > 0)
            {
                foreach (var Atributo in LstCat_Atributos)
                {
                    Models.ArticuloAtributo articuloAtributo = new Models.ArticuloAtributo();
                    articuloAtributo.Articulo = Newarticulo;
                    articuloAtributo.CatAtributos = Atributo;
                    APArticuloAtributo.ArticuloAtributo_Agregar(articuloAtributo);
                }

                foreach (var Imagen in LstArticuloImagen)
                {
                    Models.ArticuloImagen articuloImagen = new Models.ArticuloImagen();
                    articuloImagen.Articulo = Newarticulo;
                    articuloImagen.NmOriginal = Imagen.NmOriginal;
                    articuloImagen.NmArchivo = Imagen.NmArchivo;
                    articuloImagen.ImagenURL = Imagen.ImagenURL;

                    AParticuloImagen.ArticuloImagen_Agregar(articuloImagen);
                }
            }
            return Json(Newarticulo);
        }
        [HttpPost]
        public JsonResult CargaImagenes(List<Models.ArticuloImg> ListaImagenes)
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            foreach (var dt in ListaImagenes)
            {
                LstInmuebleImg.Add(dt);
            }

            Session["Imagenes"] = LstInmuebleImg;

            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult EliminarImagen(Models.ArticuloImg articuloImg)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\Articulos\\";
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    //string extencion = LstInmuebleImg[i].NmArchivo.Split('.')[1];

                    System.IO.File.Delete(DirectorioUsuario + LstInmuebleImg[i].NmArchivo);
                    LstInmuebleImg.Remove(LstInmuebleImg[i]);
                }
            }

            Session["Imagenes"] = LstInmuebleImg;
            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult RotarImagen(Models.ArticuloImg articuloImg, Application.Control_Archivos control_Archivos)
        {
            string DirectorioUsuario = Server.MapPath("~") + "Articulos\\";
            string DirectorioURL = System.Web.HttpContext.Current.Request.Url.Authority + "\\Articulos\\";

            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            Models.ArticuloImg InmuebleImg = new Models.ArticuloImg();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    InmuebleImg = control_Archivos.RotarImagen(DirectorioUsuario, LstInmuebleImg[i].NmArchivo, DirectorioURL);
                }
            }

            LstInmuebleImg.Add(InmuebleImg);

            return Json(LstInmuebleImg);
        }
        [HttpPost]
        public JsonResult ReacomodarImagen(Models.ArticuloImg articuloImg)
        {
            string DirectorioUsuario = Server.MapPath("~") + "\\Inmuebles\\";
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            List<Models.ArticuloImg> LstInmuebleImgNuevo = new List<Models.ArticuloImg>();

            Models.ArticuloImg UltimaImg = new Models.ArticuloImg();
            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            UltimaImg = LstInmuebleImg[LstInmuebleImg.Count - 1];

            // elimina el ultimo elemento de la lista
            LstInmuebleImg.Remove(LstInmuebleImg[LstInmuebleImg.Count - 1]);

            // OPTINE LA POCIOCION DEL ELEMENTO A SUSTITUIR 
            int num = 0;
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    num = i;
                    break;
                    //LstInmuebleImg.Remove(LstInmuebleImg[i]);
                }
            }

            // LLEGA EL LSITADO
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (i == num)
                {
                    LstInmuebleImgNuevo.Add(UltimaImg);
                }
                else
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }

            Session["Imagenes"] = LstInmuebleImgNuevo;
            return Json(LstInmuebleImgNuevo);

        }
        [HttpPost]
        public JsonResult OrdenarImagenes(Models.ArticuloImg articuloImg)
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();
            List<Models.ArticuloImg> LstInmuebleImgNuevo = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            // TOMA LA IMAGEN ESCOGIDA
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo == articuloImg.IdArchivo)
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }

            // LLEGA EL LSITADO
            for (int i = 0; i < LstInmuebleImg.Count; i++)
            {
                if (LstInmuebleImg[i].IdArchivo != articuloImg.IdArchivo)
                {
                    LstInmuebleImgNuevo.Add(LstInmuebleImg[i]);
                }
            }
            Session["Imagenes"] = LstInmuebleImgNuevo;
            return Json(LstInmuebleImgNuevo);
        }
        [HttpPost]
        public JsonResult ConsultaImagenes()
        {
            List<Models.ArticuloImg> LstInmuebleImg = new List<Models.ArticuloImg>();

            if (Session["Imagenes"] != null)
            {
                LstInmuebleImg = (List<Models.ArticuloImg>)Session["Imagenes"];
            }

            Session["Imagenes"] = LstInmuebleImg;

            return Json(LstInmuebleImg);
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
