using MedidoresModel.DAL;
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
        private IMedidorDAL dal = MedidorDALFactory.CreateDal();

        public HiloCliente(SocketCliente clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
          
        }
    }
}
