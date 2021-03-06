using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Lectura
    {
        private DateTime fecha;
        private int valor;
        private string tipo;
        private string unidadMedida;
        private string estado;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string UnidadMedida
        {
            get
            {
                return unidadMedida;
            }

            set
            {
                unidadMedida = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public override string ToString()
        {
            //return "{\"id\":\"{0}\"}" ;       //aca puese el salto de pagina
            return "{\"fecha\":" + "\"" + fecha + "\"" + ",\n" +
                    "\"valor\":" + "\"" + valor + "\"" + ",\n" +
                    "\"tipo\":" + "\"" + tipo + "\"" + ",\n" +
                    "\"unidadMedida\":" + "\"" + unidadMedida + "\"" + "}";
        
        }
    }
}
