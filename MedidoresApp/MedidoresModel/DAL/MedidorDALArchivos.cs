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
        private string archivo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "registro.json";

        public void Save(Medidor m)
        {
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(archivo, true))
                    {
                        writer.WriteLine(m);
                        writer.Flush();
                    }

                }
                catch (IOException ex)
                {

                }

            }
        }
        public List<Medidor> GetAll()
        {
            List<Medidor> mensajes = new List<Medidor>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] textoArray = texto.Split(';');
                            Medidor m = new Medidor()
                            {
                                Nombre = textoArray[0],
                                Detalle = textoArray[1],
                                Tipo = textoArray[2],
                            };
                            mensajes.Add(m);
                        }
                    } while (texto != null);
                }
            }
            catch (IOException ex)
            {

            }
            return mensajes;
        }

      
        
    }
}


    

