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
    public class CarroElectronico
    {
        ManejoDatos b = new ManejoDatos();
        public Models.CarroElectronico CarroElectronico_Agregar(Models.CarroElectronico carroElectronico, string clave)
        {
            const string consulta = "Ventas.CarroElectronico_Agregar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);
            b.AddParameter("@IdArticulo", carroElectronico.Articulo.Id, SqlDbType.Int);
            b.AddParameter("@Item", carroElectronico.Item, SqlDbType.Int);

            Models.CarroElectronico resultado = new Models.CarroElectronico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CarroElectronico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CarroElectronico CarroElectronico_Seleccionar_Total(string clave)
        {
            const string consulta = "Ventas.CarroElectronico_Seleccionar_Total";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);

            Models.CarroElectronico resultado = new Models.CarroElectronico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CarroElectronico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CarroElectronico CarroElectronico_Eliminar(Models.CarroElectronico carroElectronico, string clave)
        {
            const string consulta = "Ventas.CarroElectronico_Eliminar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", carroElectronico.Id, SqlDbType.Int);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);

            Models.CarroElectronico resultado = new Models.CarroElectronico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CarroElectronico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.Consultas.CarroElectronicoArticulo> CarroElectronico_Seleccionar_Clave(string clave)
        {
            const string consulta = "Ventas.CarroElectronico_Seleccionar_Clave";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);

            List<Models.Consultas.CarroElectronicoArticulo> resultado = new List<Models.Consultas.CarroElectronicoArticulo>();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<List<Models.Consultas.CarroElectronicoArticulo>>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.CarroElectronico CarroElectronico_Actualizar(Models.CarroElectronico carroElectronico, string clave)
        {
            const string consulta = "Ventas.CarroElectronico_Actualizar";
            b.ExecuteCommandSP(consulta);
            b.AddParameter("@Id", carroElectronico.Id, SqlDbType.Int);
            b.AddParameter("@Item", carroElectronico.Item, SqlDbType.Int);
            b.AddParameter("@Clave", clave, SqlDbType.NVarChar);
            
            Models.CarroElectronico resultado = new Models.CarroElectronico();
            var reader = b.ExecuteReader();
            if (reader.Read())
            {
                resultado = JsonConvert.DeserializeObject<Models.CarroElectronico>(reader.GetValue(0).ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
