using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class MedidorDALFactory
    {
        public static IMedidorDAL CreateDal()
        {
            return MedidorDALArchivos.GetInstancia();
        }
    }
}
