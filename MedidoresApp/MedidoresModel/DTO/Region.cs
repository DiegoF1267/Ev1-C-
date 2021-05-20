using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
   public class Region
    {
        private int codigo;
        private string nombre;

        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
            return "{\"codigo\":" + "\"" + codigo + "\"" + ",\n" +
                    "\"nombre\":" + "\"" + nombre + "\"" + "}";

        }
    }
}
