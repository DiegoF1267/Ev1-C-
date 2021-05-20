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
        static List<Medidor> medidores = new List<Medidor>()
        {
           new Medidor() {Id = 1, FechaInstalacion =  Convert.ToDateTime(" 2018-01-01-04-02-00")},
           new Medidor() {Id = 2, FechaInstalacion =  Convert.ToDateTime(" 2018-01-01-04-02-00")},
           new Medidor() {Id = 3, FechaInstalacion =  Convert.ToDateTime(" 2018-01-01-04-02-00")}
        };

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


    

