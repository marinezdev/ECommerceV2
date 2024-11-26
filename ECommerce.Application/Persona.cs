using ECommerce.Models.Consultas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public  class Persona
    {
        Data.Persona _Persona = new Data.Persona();
        public Models.Cliente Persona_Cliente_Agregar(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            return _Persona.Persona_Cliente_Agregar(usuarioInformacion);
        }
        public Models.Cliente Persona_Cliente_Agregar_NuevaDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            return _Persona.Persona_Cliente_Agregar_NuevaDireccion(usuarioInformacion);
        }
        public Models.Cliente Persona_Cliente_Agregar_EditarDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            return _Persona.Persona_Cliente_Agregar_EditarDireccion(usuarioInformacion);
        }
        public Models.Cliente Persona_Cliente_Agregar_SelectDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            return _Persona.Persona_Cliente_Agregar_SelectDireccion(usuarioInformacion);
        }
        public Models.Consultas.UsuarioInformacion Persona_Seleccionar_Id(Models.Persona Persona)
        {
            return _Persona.Persona_Seleccionar_Id(Persona);
        }
    }
}
