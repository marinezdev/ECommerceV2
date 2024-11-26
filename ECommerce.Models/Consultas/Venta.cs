using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models.Consultas
{
    public class Venta
    {
        public int Id { get; set; }
        public string TotalText { get; set; }
        public string Referencia { get; set; }
        public Persona Persona { get; set; }
        public Email Email { get; set; }
        public Telefono Telefono { get; set; }
        public CatTipoCliente CatTipoCliente { get; set; }
        public CatMetodoPago CatMetodoPago { get; set; }
        public CatEstatusVenta CatEstatusVenta { get; set; }
        public CatColonias CatColonias { get; set; }
        public PersonaDireccion PersonaDireccion { get; set; }
        public Folio Folio { get; set; }
        
    }
}
