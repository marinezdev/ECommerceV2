using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class CarroElectronico
    {
        Data.CarroElectronico _CarroElectronico = new Data.CarroElectronico();
        public Models.CarroElectronico CarroElectronico_Agregar(Models.CarroElectronico carroElectronico, string clave)
        {
            return _CarroElectronico.CarroElectronico_Agregar(carroElectronico, clave);
        }
        public Models.CarroElectronico CarroElectronico_Seleccionar_Total(string clave)
        {
            return _CarroElectronico.CarroElectronico_Seleccionar_Total(clave);
        }
        public Models.CarroElectronico CarroElectronico_Eliminar(Models.CarroElectronico carroElectronico, string clave)
        {
            return _CarroElectronico.CarroElectronico_Eliminar(carroElectronico, clave);
        }
        public List<Models.Consultas.CarroElectronicoArticulo> CarroElectronico_Seleccionar_Clave(string clave)
        {
            return _CarroElectronico.CarroElectronico_Seleccionar_Clave(clave);
        }
        public Models.CarroElectronico CarroElectronico_Actualizar(Models.CarroElectronico carroElectronico, string clave)
        {
            return _CarroElectronico.CarroElectronico_Actualizar(carroElectronico, clave);
        }
    }
}
