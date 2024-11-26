using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Articulo_Comentario
    {
        Data.Articulo_Comentario _Articulo_Comentario = new Data.Articulo_Comentario();
        public List<Models.Articulo_Comentario> Articulo_Comentario_Selecionar_PorPagina(Models.Articulo articulo, int Pagina)
        {
            return _Articulo_Comentario.Articulo_Comentario_Selecionar_PorPagina(articulo, Pagina);
        }
        public Models.Articulo_Comentario Articulo_Comentario_Agregar(Models.Articulo_Comentario articulo_Comentario)
        {
            return _Articulo_Comentario.Articulo_Comentario_Agregar(articulo_Comentario);
        }
        public Models.Articulo_Comentario Articulo_Comentario_ContarPaginas_IdArticulo(Models.Articulo articulo)
        {
            return _Articulo_Comentario.Articulo_Comentario_ContarPaginas_IdArticulo(articulo);
        }
    }
}
