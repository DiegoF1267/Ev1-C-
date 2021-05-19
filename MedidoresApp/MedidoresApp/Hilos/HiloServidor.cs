using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidoresApp.Hilos
{
    class HiloServidor
    {
        private int puerto;
        private SocketServer server;
        public HiloServidor(int puerto)
        {
            this.puerto = puerto;
        }

        public void Ejecutar()
        {
            server = new SocketServer(puerto);
            Console.WriteLine("Iniciando server en puerto {0}", puerto);
            if (server.Iniciar())
            {
                Console.WriteLine("Servidor iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Medidores...");
                    SocketCliente clienteSocket = server.ObtenerCliente();
                    HiloCliente hiloCliente = new HiloCliente(clienteSocket);
                    Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
        }
    }
}
