using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidoresModel.DTO;
using System.IO;
using Newtonsoft.Json;

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
        private string archivoConsumo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "consumo.txt";

        public List<Lectura> ObtenerLecturaConsumo()
        {
            List<Lectura> lecturas = new List<Lectura>();
            try
            {
                string texto = null;
                using (StreamReader reader = new StreamReader(archivoConsumo))
                {
                    texto = reader.ReadToEnd();
                }
                lecturas = JsonConvert.DeserializeObject<List<Lectura>>(texto);
            }
            catch (IOException ex)
            {

            }
            return lecturas;
        }

        public List<Lectura> ObtenerLecturasTrafico()
        {
            List<Lectura> lecturas = new List<Lectura>();
            try
            {
                string texto = null;
                using (StreamReader reader = new StreamReader(archivoTrafico))
                {
                    texto = reader.ReadToEnd();
                }
                lecturas = JsonConvert.DeserializeObject<List<Lectura>>(texto);
            }
            catch (IOException ex)
            {

            }
            return lecturas;
        }

        public void registrarLectura(Lectura l)
        {
         try
            {
                if (l.Tipo.Equals("Trafico"))
                {
                    using (StreamWriter writer = new StreamWriter(archivoTrafico, true))
                    {
                        writer.WriteLine(l);
                        writer.Flush();
                    }
                }
                else
                {
                    using (StreamWriter writer = new StreamWriter(archivoConsumo, true))
                    {
                        writer.WriteLine(l);
                        writer.Flush();
                    }
                }
            }catch(IOException ex)
            {

            }
        }
    }
}
