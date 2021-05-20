using MedidoresModel.DAL;
using MedidoresModel.DTO;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresApp.Hilos
{
    class HiloCliente
    {
        private SocketCliente clienteSocket;
        private IMedidorDAL dalMedidor = MedidorDALFactory.CreateDal();
        private ILecturasDAL dalLectura = LecturasDALFactory.CreateDal();
        static DateTime fechaActual = DateTime.Now;

        public HiloCliente(SocketCliente clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            string mensaje;
            DateTime fechaActual = DateTime.Now;
            do
            {
                do
                {
                    mensaje = clienteSocket.Leer().Trim();
                } while (mensaje == string.Empty);

            } while (mensajeCorrecto(mensaje));

            clienteSocket.Escribir(fechaActual.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");

            mensaje=clienteSocket.Leer().Trim();

            lecturaCorrecta(mensaje);

            clienteSocket.Escribir(mensaje);

        }

        public void lecturaCorrecta(string mensaje)
        {
            int flag = 0;
            int valor = 0;
            string estado = "";
            string tipo="";
            DateTime fechaValida = new DateTime();
            string[] mensajeArray = mensaje.Split('|');
            if (mensajeArray.Length == 5 || mensajeArray.Length == 6)
            {
                if (existeMedidor(mensajeArray[0]))
                {
                    flag = flag + 1;
                }

               
                try
                {
                    fechaValida = DateTime.Parse(mensajeArray[1]);
                    if (fechaValida.ToString("yyyy-MM-dd-HH-mm-ss") == mensajeArray[1])
                    {
                        flag = flag + 1;
                    }
                }
                catch (Exception ex)
                {
                    flag = flag - 1;
                }

                if (existeTipo(mensajeArray[2]))
                {
                    flag = flag + 1;
                    if (mensajeArray[2].Equals("consumo", StringComparison.OrdinalIgnoreCase))
                    {
                        tipo = "Consumo";
                    }
                    else
                    {
                        tipo = "Trafico";
                    }
                }

                
                try
                {
                    valor = Convert.ToInt32(mensajeArray[3]);
                    if(valor >= 0 && valor <= 1000)
                    {
                        flag = flag + 1;
                    }
                }catch(Exception ex)
                {
                    flag = flag - 1;
                }

                
                if(mensajeArray.Length == 6)
                {
                    //Viene con estado
                    switch (mensajeArray[4])
                    {
                        case "-1": estado = "Error de Lectura";
                            flag = flag + 1;
                            break;
                        case "0": estado = "OK";
                            flag = flag + 1;
                            break;
                        case "1":
                            estado = "Punto de carga lleno";
                            flag = flag + 1;
                            break;
                        case "2":
                            estado = "Requiere mantención preventiva";
                            flag = flag + 1;
                            break;
                        default: flag = flag - 1;
                            break;
                    }

                   if (mensajeArray[5].Equals("UPDATE"))
                    {
                        flag = flag + 1;
                    }

                }
                else
                {
                    //Viene sin estado
                    if (mensajeArray[4].Equals("UPDATE"))
                    {
                        flag = flag + 1;
                    }
                }
               
            }

          


            if ((mensajeArray.Length == 6 && flag==6) || (mensajeArray.Length == 5 && flag == 5))
            {
                Lectura l = new Lectura()
                {
                    Fecha = fechaValida,
                    Valor = valor,
                    Tipo = tipo,
                    Estado = estado
                };
                    lock (dalLectura)
                    {
                        dalLectura.registrarLectura(l);
                    }
                mensaje = "";
            }
            else
            {
                mensaje = fechaActual.ToString("yyyy-MM-dd-HH-mm-ss")+"|"+mensajeArray[0]+"|ERROR";
            }

            
        }

        public bool mensajeCorrecto(string mensaje)
        {
            bool flag=false;
            string fecha;
            string nroMedidorStr;
            string tipo;
            string[] mensajeArray = mensaje.Split('|');
            if (mensajeArray.Length == 3)
            {
                //Proceder con las demas verificaciones 
                fecha = mensajeArray[0];
                nroMedidorStr = mensajeArray[1];
                tipo = mensajeArray[2];
                
                if (esFecha(fecha))
                {
                    if (existeMedidor(nroMedidorStr))
                    {
                        if (existeTipo(tipo))
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        public bool esFecha (string fecha)
        {
            bool flag = false;
            DateTime fechaValida = new DateTime();
            try
            {
                fechaValida = DateTime.Parse(fecha);
                if (fechaValida.ToString("yyyy-MM-dd-HH-mm-ss") == fecha)
                {
                    if ((fechaValida - fechaActual).Minutes < 30)
                    {
                        flag = true;
                    }
                }
            }catch(Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        public bool existeMedidor(string idMedidorStr)
        {
            bool flag = false;
            int idMedidor=0;
            try
            {
                idMedidor = Convert.ToInt32(idMedidorStr.Trim());
                List<Medidor> medidores = dalMedidor.GetAll();
                medidores.ForEach(m =>
                {
                    if (m.Id == idMedidor)
                    {
                        flag = true;
                    }
                });
            }
            catch(Exception ex)
            {

            }

            
            return flag;
        }

        public bool existeTipo(string tipo)
        {
            bool flag = false;
            if(tipo.Equals("consumo", StringComparison.OrdinalIgnoreCase) || tipo.Equals("trafico", StringComparison.OrdinalIgnoreCase))
            {
                flag = true;
            }
            return flag;
        }
    }
}
