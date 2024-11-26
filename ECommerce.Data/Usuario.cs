using ECommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class Usuario
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Usuario Usuario_Agregar(Models.Consultas.NuevoUsuario nuevoUsuario)
        {
            const string consulta = "Administracion.Usuario_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Email", nuevoUsuario.Email.email, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", nuevoUsuario.Persona.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", nuevoUsuario.Persona.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", nuevoUsuario.Persona.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@Password", nuevoUsuario.Usuario.Password, SqlDbType.NVarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuario Usuario_autentificar(Models.Usuario usuarios)
        {
            const string consulta = "Administracion.Usuario_autentificar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Usuario", usuarios.usuario, SqlDbType.VarChar);
            b.AddParameter("@Password", usuarios.Password, SqlDbType.VarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Usuario Administracion_UsuarioActualizarPass(Models.Usuario usuarios)
        {
            const string consulta = "Administracion.UsuarioActualizarPass";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", usuarios.Id, SqlDbType.VarChar);
            b.AddParameter("@Password", usuarios.Password, SqlDbType.VarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Consultas.UsuarioInformacion Usuario_Usuario_Seleccionar_Id(Models.Usuario usuario)
        {
            const string consulta = "Usuario.Usuario_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", usuario.Id, SqlDbType.Int);

            Models.Consultas.UsuarioInformacion resultado = new Models.Consultas.UsuarioInformacion();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Consultas.UsuarioInformacion>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuario Administracion_UsuarioActualizarName(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Usuario.Usuario_actualizarName";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", usuarioInformacion.Persona.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", usuarioInformacion.Persona.Nombre, SqlDbType.VarChar);
            b.AddParameter("@ApellidoPaterno", usuarioInformacion.Persona.ApellidoPaterno, SqlDbType.VarChar);
            b.AddParameter("@ApellidoMaterno", usuarioInformacion.Persona.ApellidoMaterno, SqlDbType.VarChar);

            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Usuario Administracion_UsuarioActualizarCorreo(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Administracion.UsuarioActualizarCorreo";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", usuarioInformacion.Email.Id, SqlDbType.Int);
            b.AddParameter("@Correo", usuarioInformacion.Email.email, SqlDbType.VarChar);


            Models.Usuario resultado = new Models.Usuario();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Usuario>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }






        public Models.Usuarios Usuario_Selecionar_Pas_US(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuario_Selecionar_Pas_US");
            b.AddParameter("@Email", usuarios.Email, SqlDbType.VarChar);
            b.AddParameter("@Password", usuarios.Password, SqlDbType.VarChar);
            b.AddParameter("@Session", usuarios.Session, SqlDbType.Bit);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.Telefono = reader["Telefono"].ToString();
                resultado.TipoTelefono = reader["TipoTelefono"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios coo_Session_Seleccionar(string Clave)
        {
            b.ExecuteCommandSP("coo_Session_Seleccionar");
            b.AddParameter("@Clave", Clave, SqlDbType.VarChar);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios Consulta_Usuario_Nombre(int IdUsuario)
        {
            b.ExecuteCommandSP("Usuario_Selecionar_Nombre");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


    }
}
