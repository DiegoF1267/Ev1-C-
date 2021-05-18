using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidoresModel.DTO;
using System.IO;

namespace MedidoresModel.DAL
{
   public class LecturasDALArchivos : ILecturasDAL
    {

        private LecturasDALArchivos()
        {

        }
        private static ILecturasDAL instancia;
        public static ILecturasDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new LecturasDALArchivos();
            return instancia;
        }

        private string archivoTrafico = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "trafico.txt";
        private string archivoConsumo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "consumo.json";

        public List<Lectura> ObtenerLecturaConsumo()
        {
            throw new NotImplementedException();
        }

        public List<Lectura> ObtenerLecturasTrafico()
        {
            throw new NotImplementedException();
        }

        public void registrarLectura(Lectura l)
        {
            throw new NotImplementedException();
        }
    }
}
