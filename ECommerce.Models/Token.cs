using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Token
    {
        public int Id { get; set; }
        public CatTipoToken CatTipoToken { get; set; }
        public string token { get; set; }
        public string Contenido { get; set; }
    }
}
