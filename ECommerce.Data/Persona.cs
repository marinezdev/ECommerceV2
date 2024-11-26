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
    public class Persona
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Cliente Persona_Cliente_Agregar(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Ventas.Persona_Cliente_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Email", usuarioInformacion.Email.email, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", usuarioInformacion.Persona.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoPaterno", usuarioInformacion.Persona.ApellidoPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoMaterno", usuarioInformacion.Persona.ApellidoMaterno, SqlDbType.NVarChar);
            b.AddParameter("@Publicidad", usuarioInformacion.Persona.Publicidad, SqlDbType.Int);
            b.AddParameter("@TerminosCondiciones", usuarioInformacion.Persona.TerminosCondiciones, SqlDbType.Int);
            b.AddParameter("@IdTipoTelefono", usuarioInformacion.Telefono.CatTipoTelefono.Id, SqlDbType.Int);
            b.AddParameter("@Telefono", usuarioInformacion.Telefono.telefono, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoCliente", usuarioInformacion.CatTipoCliente.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", usuarioInformacion.PersonaDireccion.CatColonias.Id, SqlDbType.Int);
            b.AddParameter("@NombreDireccion", usuarioInformacion.PersonaDireccion.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@NumExterior", usuarioInformacion.PersonaDireccion.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInterior", usuarioInformacion.PersonaDireccion.NumInterior, SqlDbType.NVarChar);
            b.AddParameter("@Calle", usuarioInformacion.PersonaDireccion.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", usuarioInformacion.PersonaDireccion.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", usuarioInformacion.PersonaDireccion.Referencias, SqlDbType.NVarChar);
            b.AddParameter("@RecibirPedido", usuarioInformacion.PersonaDireccion.RecibirPedido, SqlDbType.Int);
            b.AddParameter("@RecibirNombre", usuarioInformacion.PersonaDireccion.RecibirNombre, SqlDbType.NVarChar);
            b.AddParameter("@RecibirApellidos", usuarioInformacion.PersonaDireccion.RecibirApellidos, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTelefono", usuarioInformacion.PersonaDireccion.RecibirTelefono, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTipoTelefono", usuarioInformacion.PersonaDireccion.RecibirTipoTelefono, SqlDbType.Int);

            Models.Cliente resultado = new Models.Cliente();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cliente>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cliente Persona_Cliente_Agregar_NuevaDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Ventas.Persona_Cliente_Agregar_NuevaDireccion";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", usuarioInformacion.Persona.Id, SqlDbType.Int);
            b.AddParameter("@Publicidad", usuarioInformacion.Persona.Publicidad, SqlDbType.Int);
            b.AddParameter("@IdTipoTelefono", usuarioInformacion.Telefono.CatTipoTelefono.Id, SqlDbType.Int);
            b.AddParameter("@Telefono", usuarioInformacion.Telefono.telefono, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoCliente", usuarioInformacion.CatTipoCliente.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", usuarioInformacion.PersonaDireccion.CatColonias.Id, SqlDbType.Int);
            b.AddParameter("@NombreDireccion", usuarioInformacion.PersonaDireccion.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@NumExterior", usuarioInformacion.PersonaDireccion.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInterior", usuarioInformacion.PersonaDireccion.NumInterior, SqlDbType.NVarChar);
            b.AddParameter("@Calle", usuarioInformacion.PersonaDireccion.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", usuarioInformacion.PersonaDireccion.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", usuarioInformacion.PersonaDireccion.Referencias, SqlDbType.NVarChar);
            b.AddParameter("@RecibirPedido", usuarioInformacion.PersonaDireccion.RecibirPedido, SqlDbType.Int);
            b.AddParameter("@RecibirNombre", usuarioInformacion.PersonaDireccion.RecibirNombre, SqlDbType.NVarChar);
            b.AddParameter("@RecibirApellidos", usuarioInformacion.PersonaDireccion.RecibirApellidos, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTelefono", usuarioInformacion.PersonaDireccion.RecibirTelefono, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTipoTelefono", usuarioInformacion.PersonaDireccion.RecibirTipoTelefono, SqlDbType.Int);

            Models.Cliente resultado = new Models.Cliente();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cliente>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Cliente Persona_Cliente_Agregar_EditarDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Ventas.Persona_Cliente_Agregar_EditarDireccion";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", usuarioInformacion.Persona.Id, SqlDbType.Int);
            b.AddParameter("@IdDireccion", usuarioInformacion.PersonaDireccion.Id, SqlDbType.Int);
            b.AddParameter("@Publicidad", usuarioInformacion.Persona.Publicidad, SqlDbType.Int);
            b.AddParameter("@IdTipoTelefono", usuarioInformacion.Telefono.CatTipoTelefono.Id, SqlDbType.Int);
            b.AddParameter("@Telefono", usuarioInformacion.Telefono.telefono, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoCliente", usuarioInformacion.CatTipoCliente.Id, SqlDbType.Int);
            b.AddParameter("@IdColonia", usuarioInformacion.PersonaDireccion.CatColonias.Id, SqlDbType.Int);
            b.AddParameter("@NombreDireccion", usuarioInformacion.PersonaDireccion.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@NumExterior", usuarioInformacion.PersonaDireccion.NumExterior, SqlDbType.NVarChar);
            b.AddParameter("@NumInterior", usuarioInformacion.PersonaDireccion.NumInterior, SqlDbType.NVarChar);
            b.AddParameter("@Calle", usuarioInformacion.PersonaDireccion.Calle, SqlDbType.NVarChar);
            b.AddParameter("@EntreCalles", usuarioInformacion.PersonaDireccion.EntreCalles, SqlDbType.NVarChar);
            b.AddParameter("@Referencias", usuarioInformacion.PersonaDireccion.Referencias, SqlDbType.NVarChar);
            b.AddParameter("@RecibirPedido", usuarioInformacion.PersonaDireccion.RecibirPedido, SqlDbType.Int);
            b.AddParameter("@RecibirNombre", usuarioInformacion.PersonaDireccion.RecibirNombre, SqlDbType.NVarChar);
            b.AddParameter("@RecibirApellidos", usuarioInformacion.PersonaDireccion.RecibirApellidos, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTelefono", usuarioInformacion.PersonaDireccion.RecibirTelefono, SqlDbType.NVarChar);
            b.AddParameter("@RecibirTipoTelefono", usuarioInformacion.PersonaDireccion.RecibirTipoTelefono, SqlDbType.Int);

            Models.Cliente resultado = new Models.Cliente();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cliente>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Cliente Persona_Cliente_Agregar_SelectDireccion(Models.Consultas.UsuarioInformacion usuarioInformacion)
        {
            const string consulta = "Ventas.Persona_Cliente_Agregar_SelectDireccion";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@IdPersona", usuarioInformacion.Persona.Id, SqlDbType.Int);
            b.AddParameter("@IdDireccion", usuarioInformacion.PersonaDireccion.Id, SqlDbType.Int);
            b.AddParameter("@IdTipoCliente", usuarioInformacion.CatTipoCliente.Id, SqlDbType.Int);

            Models.Cliente resultado = new Models.Cliente();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.Cliente>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Consultas.UsuarioInformacion Persona_Seleccionar_Id(Models.Persona Persona)
        {
            const string consulta = "Persona.Persona_Seleccionar_Id";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", Persona.Id, SqlDbType.Int);

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
    }
}
