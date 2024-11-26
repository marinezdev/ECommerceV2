using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Articulo_Comentario
    {
        public int Id { get; set; }
        public Articulo Articulo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Estrellas { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int NumPaginas { get; set; }

    }
}
