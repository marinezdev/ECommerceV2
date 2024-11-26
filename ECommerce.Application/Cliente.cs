using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Cliente
    {
        Data.Cliente _Cliente = new Data.Cliente();
        public Models.Consultas.UsuarioInformacion Cliente_Seleccionar_Id(Models.Cliente cliente)
        {
            return _Cliente.Cliente_Seleccionar_Id(cliente);
        }
    }
}
