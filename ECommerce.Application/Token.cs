using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Token
    {
        Data.Token _Token = new Data.Token();
        public Models.Token Token_Agregar()
        {
            return _Token.Token_Agregar();
        }
    }
}
