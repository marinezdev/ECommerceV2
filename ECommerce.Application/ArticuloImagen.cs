using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class ArticuloImagen
    {
        Data.ArticuloImagen _ArticuloImagen =  new Data.ArticuloImagen();
        public Models.ArticuloImagen ArticuloImagen_Agregar(Models.ArticuloImagen articuloImagen)
        {
            return _ArticuloImagen.ArticuloImagen_Agregar(articuloImagen);
        }
        public List<Models.ArticuloImagen> ArticuloImagen_Seleccionar_IdArticulo(Models.Articulo articulo)
        {
            return _ArticuloImagen.ArticuloImagen_Seleccionar_IdArticulo(articulo);
        }
    }
}
