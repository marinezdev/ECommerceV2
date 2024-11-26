using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public Rol Rol { get; set; }
        public Persona Persona { get; set; }
        public string usuario { get; set; }
        public string Password { get; set; }
        public bool Session { get; set; }
        public string ClaveCookie { get; set; }
        public string Mensaje { get; set; }
    }
}
