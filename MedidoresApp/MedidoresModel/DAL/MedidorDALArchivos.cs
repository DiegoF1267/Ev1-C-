using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidoresModel.DTO;

namespace MedidoresModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        static List<Medidor> medidores = new List<Medidor>();

        private MedidorDALArchivos()
        {

        }
        private static IMedidorDAL instancia;
        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
                instancia = new MedidorDALArchivos();
            return instancia;
        }
        private string archivo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "consumo.txt";





        public List<Medidor> GetAll()
        {
            return medidores;
        }

        public void save(Medidor m)
        {
            medidores.Add(m);
        }
    }
}


    

