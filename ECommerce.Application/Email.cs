using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce.Application
{
    public  class Email
    {
        Data.Email _Email = new Data.Email();
        public Models.Email Email_Seleccionar_Email(Models.Email email)
        {
            return _Email.Email_Seleccionar_Email(email);
        }
    }
}
