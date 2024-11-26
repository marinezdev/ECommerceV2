using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ArticuloAtributoController : Controller
    {
        [HttpPost]
        public JsonResult ArticuloAtributo_ConsultaId(Models.CatAtributos catAtributos)
        {
            bool result = false;
            List<Models.CatAtributos> LstCatAtributos = new List<Models.CatAtributos>();
            if (Session["AtributosArticulo"] != null)
            {
                LstCatAtributos = (List<Models.CatAtributos>)Session["AtributosArticulo"];
            }

            foreach (var dt in LstCatAtributos)
            {
                if (catAtributos.Id == dt.Id)
                {
                    result = true;
                    break;
                }
            }
            return Json(result);
        }
        [HttpPost]
        public JsonResult ArticuloAtributo_Agregar(Models.CatAtributos catAtributos, Application.CatAtributos APCatAtributos)
        {
            List<Models.CatAtributos> LstCat_Atributos = new List<Models.CatAtributos>();
            Models.CatAtributos BuquedaAtributo = new Models.CatAtributos();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.CatAtributos>)Session["AtributosArticulo"];
            }

            BuquedaAtributo = APCatAtributos.CatAtributos_Seleccionar_Id(catAtributos);
            if (BuquedaAtributo.Id > 0)
            {
                BuquedaAtributo.Valor = "";
                LstCat_Atributos.Add(BuquedaAtributo);
            }

            Session["AtributosArticulo"] = LstCat_Atributos;


            return Json(LstCat_Atributos);
        }
        [HttpPost]
        public JsonResult ArticuloAtributo_Actualizar(Models.CatAtributos catAtributos)
        {
            List<Models.CatAtributos> LstCat_Atributos = new List<Models.CatAtributos>();
            List<Models.CatAtributos> LstNuevaCat_Atributos = new List<Models.CatAtributos>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.CatAtributos>)Session["AtributosArticulo"];
            }

            foreach (var dt in LstCat_Atributos)
            {
                if (dt.Id == catAtributos.Id)
                {
                    dt.Valor = catAtributos.Valor;
                    LstNuevaCat_Atributos.Add(dt);
                }
                else
                {
                    LstNuevaCat_Atributos.Add(dt);
                }
            }

            Session["AtributosArticulo"] = LstNuevaCat_Atributos;

            return Json(LstCat_Atributos);
        }
        [HttpPost]
        public JsonResult ArticuloAtributo_Eliminar(Models.CatAtributos cat_Atributos)
        {
            List<Models.CatAtributos> LstCat_Atributos = new List<Models.CatAtributos>();
            List<Models.CatAtributos> LstNuevaCat_Atributos = new List<Models.CatAtributos>();

            if (Session["AtributosArticulo"] != null)
            {
                LstCat_Atributos = (List<Models.CatAtributos>)Session["AtributosArticulo"];
            }

            foreach (var dt in LstCat_Atributos)
            {
                if (dt.Id == cat_Atributos.Id)
                {

                }
                else
                {
                    LstNuevaCat_Atributos.Add(dt);
                }
            }

            Session["AtributosArticulo"] = LstNuevaCat_Atributos;

            return Json(LstNuevaCat_Atributos);
        }
    }
}
