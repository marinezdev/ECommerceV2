using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class DireccionController : Controller
    {
        [HttpPost]
        public JsonResult CatCp_Seleccionar_CP(Models.CatCp catCp, Application.CatCp APCatCp)
        {
            List<Models.Consultas.Direccion> dbDireccion = APCatCp.CatCp_Seleccionar_CP(catCp);
            return Json(dbDireccion);
        }

        [HttpPost]
        public JsonResult CatEstados_Seleccionar(Application.CatEstados APcatEstados)
        {
            List<Models.CatEstados> estados = APcatEstados.CatEstados_Seleccionar();
            return Json(estados);
        }

        [HttpPost]
        public JsonResult Consulta_DelegacionMunicipio(Models.CatEstados catEstados, Application.CatPoblaciones APcatPoblacion)
        {
            List<Models.CatPoblaciones> Poblaciones = APcatPoblacion.CatPoblaciones_Seleccionar_IdEstado(catEstados);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_CP(Models.CatColonias catColonias, Application.CatCp APcatCP)
        {
            List<Models.CatCp> Poblaciones = APcatCP.CatCP_Seleccionar_IdColonia(catColonias);
            return Json(Poblaciones);
        }

        [HttpPost]
        public JsonResult Consulta_Colonias(Models.CatPoblaciones catPoblaciones, Application.CatColonias APcat_Colonias)
        {
            List<Models.CatColonias> Poblaciones = APcat_Colonias.CatColonias_Seleccionar_IdPoblacion(catPoblaciones);
            return Json(Poblaciones);
        }

    }
}
