using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Direccion
    {
        private int codPostal;
        private string detalle;
        private int nro;
        private string adicional;

        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
            return "{\"codPostal\":" + "\"" + codPostal + "\"" + ",\n" +
                    "\"detalle\":" + "\"" + detalle + "\"" + ",\n" +
                    "\"nro\":" + "\"" + nro + "\"" + ",\n" +
                    "\"adicional\":" + "\"" + adicional + "\"" + "}";

        }
    }
}
