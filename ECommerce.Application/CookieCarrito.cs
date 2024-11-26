using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CookieCarrito
    {
        Data.CookieCarrito _CookieCarrito = new Data.CookieCarrito();
        public Models.CookieCarrito CookieCarrito_Agregar()
        {
            return _CookieCarrito.CookieCarrito_Agregar();
        }
    }
}
