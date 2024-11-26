using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Direccion
    {
        Data.Direccion _Direccion = new Data.Direccion();
        public List<Models.PersonaDireccion> Direccion_Seleccionar_IdUsuario(Models.Usuario usuario)
        {
            return _Direccion.Direccion_Seleccionar_IdUsuario(usuario);
        }
        public Models.PersonaDireccion Direccion_Seleccionar_Id(Models.PersonaDireccion personaDireccion)
        {
            return _Direccion.Direccion_Seleccionar_Id(personaDireccion);
        }
    }
}
