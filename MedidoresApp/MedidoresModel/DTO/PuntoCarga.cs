using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class PuntoCarga
    {
        private int id;
        private int tipo;
        private int capacidadMaxima;
        private DateTime fechaVencimiento;

        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
            return "{\"id\":" + "\"" + id + "\"" + ",\n" +
                    "\"tipo\":" + "\"" + tipo + "\"" + ",\n" +
                    "\"capacidadMaxima\":" + "\"" + capacidadMaxima + "\"" + ",\n" +
                    "\"fechaVencimiento\":" + "\"" + fechaVencimiento + "\"" + "}";

        }
    }
}
