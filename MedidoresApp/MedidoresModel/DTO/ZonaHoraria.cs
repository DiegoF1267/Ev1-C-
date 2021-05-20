using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
   public class ZonaHoraria
    {
        private string codigo;
        private string nombreLargo;

        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
            return "{\"codigo\":" + "\"" + codigo + "\"" + ",\n" +
                    "\"nombreLargo\":" + "\"" + nombreLargo + "\"" + "}";

        }
    }
}
