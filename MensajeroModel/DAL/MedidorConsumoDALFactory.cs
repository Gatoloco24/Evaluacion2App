﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class MedidorConsumoDALFactory
    {
        public static IMedidorConsumoDAL CreateDal()
        {
            return MedidorConsumoDALArchivo.GetInstance();
        }
    }
}
