using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ArticuloImagen
    {
        public Articulo Articulo { get; set; }  
        public string NmArchivo { get; set; }
        public string NmOriginal { get; set; }
        public string ImagenURL { get; set; }
    }
}
