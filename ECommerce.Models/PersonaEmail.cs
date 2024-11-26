using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class PersonaEmail
    {
        public int Id { get; set; } 
        public Persona Persona { get; set; }
        public Email Email { get; set; }
    }
}
