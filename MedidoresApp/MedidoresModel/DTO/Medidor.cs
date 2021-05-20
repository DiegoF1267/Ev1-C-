using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Medidor
    {
        private int id;
        private DateTime fechaInstalacion;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime FechaInstalacion
        {
            get
            {
                return fechaInstalacion;
            }

            set
            {
                fechaInstalacion = value;
            }
        }

        public Lectura enviarLectura(Lectura lectura)
        {
            return lectura;
        }
        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
        return "{\"id\":" + "\"" + id + "\"" + ",\n" +
                "\"fechaInstalación\":" + "\"" + fechaInstalacion + "\"" + "}";
        }

    }
}
