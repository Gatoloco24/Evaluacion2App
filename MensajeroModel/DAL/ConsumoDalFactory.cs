using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class ConsumoDalFactory
    {
        public static IConsumoDAL CreateDal()
        {
            return ConsumoDALArchivo.GetInstance();
        }
    }
}
