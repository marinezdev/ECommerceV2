using System;
namespace ECommerce.Models.Consultas
{
	public class UsuarioInformacion
	{
        public Email Email { get; set; }
        public Persona Persona { get; set; }

        public CatTipoCliente CatTipoCliente { get; set; }
        public Telefono Telefono { get; set; }
        public PersonaDireccion PersonaDireccion { get; set; }
    }
}

