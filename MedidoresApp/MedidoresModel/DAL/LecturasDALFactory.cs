﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class LecturasDALFactory
    {
        public static ILecturasDAL CreateDal()
        {
            return LecturasDALArchivos.GetInstancia();
        }
    }
}
