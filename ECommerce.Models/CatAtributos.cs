using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CatAtributos
    {
        public int Id { get; set; }
        public CatClasificacion CatClasificacion { get; set; }
        public CatTipoDatos CatTipoDatos { get; set; }  
        public string Atributo { get; set; }
        public string Valor { get; set; }
    }
}
