using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CatCp
    {
        public int Id { get; set; }
        public CatPoblaciones CatPoblaciones { get; set;}
        public string CP { get; set; }
    }
}
