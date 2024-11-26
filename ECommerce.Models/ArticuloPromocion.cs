using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ArticuloPromocion
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }  
        public CatMoneda CatMoneda { get; set;}
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public float Precio { get; set; }
    }
}
