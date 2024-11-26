using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CatSubcategoria
    {
        public int Id { get; set; }

        public CatCategoriaProducto CatCategoriaProducto { get; set; }
        public string Nombre { get; set; }  
        public string Imagen { get; set; }
        public int Total { get; set; }

    }
}
