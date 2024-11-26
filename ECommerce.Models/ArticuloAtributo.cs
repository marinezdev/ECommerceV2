using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ArticuloAtributo
    {
        public Articulo Articulo { get; set; }  
        public CatAtributos CatAtributos { get; set; }
        public string Valor { get; set; }
    }
}
