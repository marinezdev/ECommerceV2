using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class PersonaDireccion
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public CatColonias CatColonias { get; set; }
        public string Nombre { get; set; }
        public string NumExterior { get; set; }
        public string NumInterior { get; set; }
        public string Calle { get; set; }
        public string EntreCalles { get; set; }
        public string Referencias { get; set; }
        public int RecibirPedido { get; set; }
        public string RecibirNombre { get; set; }
        public string RecibirApellidos { get; set; }
        public string RecibirTelefono { get; set; }
        public int RecibirTipoTelefono { get; set; }
        public int Flag { get; set; }

    }
}
