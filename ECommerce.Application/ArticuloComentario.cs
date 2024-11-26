using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class ArticuloComentario
    {
        Data.ArticuloComentario _ArticuloComentario = new Data.ArticuloComentario();
        public List<Models.ArticuloComentario> ArticuloComentario_Seleccionar_PorPagina(Models.Articulo articulo, int Pagina)
        {
            return _ArticuloComentario.ArticuloComentario_Seleccionar_PorPagina(articulo, Pagina);
        }
        public Models.ArticuloComentario ArticuloComentario_Agregar(Models.ArticuloComentario articuloComentario)
        {
            return _ArticuloComentario.ArticuloComentario_Agregar(articuloComentario);

        }
        public Models.ArticuloComentario ArticuloComentario_ContarPaginas_IdArticulo(Models.Articulo articulo)
        {
            return _ArticuloComentario.ArticuloComentario_ContarPaginas_IdArticulo(articulo);
        }
    }
}