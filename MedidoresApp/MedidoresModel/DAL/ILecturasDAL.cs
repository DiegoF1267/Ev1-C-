using MedidoresModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public interface ILecturasDAL
    {
        void registrarLectura(Lectura l);
        List<Lectura> ObtenerLecturasTrafico();
        List<Lectura> ObtenerLecturaConsumo();
    }
}
