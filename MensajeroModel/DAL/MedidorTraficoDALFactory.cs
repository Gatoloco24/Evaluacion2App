using EvaluacionModel.DAL;
using EvaluacionoModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class MedidorTraficoDALFactory
    {
        public static IMedidorTraficoDAL CreateDal()
        {
            return MedidorTraficoDALArchivo.GetInstance();
        }
    }

}
