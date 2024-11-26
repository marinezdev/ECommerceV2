using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CodigoVeridicacion
    {
        Data.CodigoVeridicacion _CodigoVeridicacion = new Data.CodigoVeridicacion();

        public Models.CodigoVeridicacion Administracion_CodigoVeridicacion_Generar(Models.Usuario usuario)
        {
            return _CodigoVeridicacion.Administracion_CodigoVeridicacion_Generar(usuario);
        }
    }
}
