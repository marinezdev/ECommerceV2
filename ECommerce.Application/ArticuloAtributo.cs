using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class ArticuloAtributo
    {
        Data.ArticuloAtributo _ArticuloAtributo =  new Data.ArticuloAtributo();
        public Models.ArticuloAtributo ArticuloAtributo_Agregar(Models.ArticuloAtributo articuloAtributo)
        {
            return _ArticuloAtributo.ArticuloAtributo_Agregar(articuloAtributo);
        }
        public List<Models.ArticuloAtributo> ArticuloAtributo_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            return _ArticuloAtributo.ArticuloAtributo_Seleccionar_IdArticulo(articulo);
        }
    }
}
