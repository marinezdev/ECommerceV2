using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class NuevoUsuario
    {
        public Token Toke { get; set; }
        public Email Email { get; set; }
        public Persona Persona { get; set; }
        public Usuario Usuario { get; set;}
    }
}
