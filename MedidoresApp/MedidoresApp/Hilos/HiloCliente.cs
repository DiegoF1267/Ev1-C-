using MedidoresApp.ValidacionesUtils;
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
        private Validaciones v = new Validaciones();

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

            } while (v.mensajeCorrecto(mensaje));

            clienteSocket.Escribir(fechaActual.ToString("yyyy-MM-dd-HH-mm-ss") + "|WAIT");

            mensaje=clienteSocket.Leer().Trim();

            mensaje=v.lecturaCorrecta(mensaje);

            clienteSocket.Escribir(mensaje);

            clienteSocket.CerrarConexion();

        }

       
    }
}
