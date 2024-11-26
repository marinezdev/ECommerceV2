using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Correo
{
    public class NuevoUsuario
    {
        public Models.Mensaje ConfirmarEmail(Models.Email email, Models.CodigoVeridicacion codigo)
        {
            Models.Mensaje mensaje = new Models.Mensaje();

            WSCorreo.CorreoSoapClient correo1 = new WSCorreo.CorreoSoapClient();
            if (correo1.CorreoMetPrivado("mail.asae.com.mx", 25, "soporte-aplicaciones@asae.com.mx", "$%65hgy#19_", email.email.Trim(), "Ecommerce", "Confirmacion de usuario", HTMLNuevaCompra(codigo)) == "Correo enviado")
            {
                mensaje.Respuesta = true;
            }
            return mensaje;
        }

        private string HTMLNuevaCompra(Models.CodigoVeridicacion codigo)
        {
            string HTML = "<p>Tu codigo de verificacion es: " + codigo.Clave + "</p>";
            return HTML;
        }
    }
}
