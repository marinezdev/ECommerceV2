using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public CatTipoPersona CatTipoPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }



        public int Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string RFC { get; set; }
        public int Publicidad { get; set; }
        public int TerminosCondiciones { get; set; }
    }
}
