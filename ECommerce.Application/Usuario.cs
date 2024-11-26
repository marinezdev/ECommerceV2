using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class Usuario
    {
        Data.Usuario _Usuario = new Data.Usuario();

        public Models.Usuario Usuario_Agregar(Models.Consultas.NuevoUsuario nuevoUsuario)
        {
            return _Usuario.Usuario_Agregar(nuevoUsuario);
        }
        public Models.Usuario Iniciar(Models.Usuario usuarios)
        {
            Models.Usuario user = _Usuario.Usuario_autentificar(usuarios);
            return user;
        }


        public Models.Usuario Administracion_UsuarioActualizarPass(Models.Usuario usuarios)
        {
            Models.Usuario user = _Usuario.Administracion_UsuarioActualizarPass(usuarios);
            return user;
        }

        public Models.Consultas.UsuarioInformacion Usuario_Usuario_Seleccionar_Id(Models.Usuario usuario)
        {
            return _Usuario.Usuario_Usuario_Seleccionar_Id(usuario);
        }

        public Models.Usuario Administracion_UsuarioActualizarName(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            Models.Usuario user = _Usuario.Administracion_UsuarioActualizarName(usuarioInformacion);
            return user;
        }
        public Models.Usuario Administracion_UsuarioActualizarCorreo(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            Models.Usuario user = _Usuario.Administracion_UsuarioActualizarCorreo(usuarioInformacion);
            return user;
        }








        public Models.Usuarios Iniciar(Models.Usuarios usuarios)
        {
            Models.Usuarios user = _Usuario.Usuario_Selecionar_Pas_US(usuarios);
            return user;
        }

        public Models.Usuarios coo_Session_Seleccionar(string clave)
        {
            Models.Usuarios usuario = _Usuario.coo_Session_Seleccionar(clave);
            return usuario;
        }

        public Models.Usuarios Consulta_Usuario_Nombre(int IdUsuario)
        {
            Models.Usuarios usuario = _Usuario.Consulta_Usuario_Nombre(IdUsuario);
            return usuario;
        }



    }
}
