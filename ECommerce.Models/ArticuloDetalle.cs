using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ArticuloDetalle
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public CatMoneda CatMoneda { get; set; }
        public string Nombre { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public float Largo { get; set; }
        public float Ancho { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int Envio { get; set; } 
        public float PrecioPublico { get; set;}
        public float PrecioDistribuidor { get;set; }
        public float PrecioLista { get; set; }
        public float PrecioPlataformaPago { get; set; }
        public float PrecioEnvio { get; set; }
    }
}
