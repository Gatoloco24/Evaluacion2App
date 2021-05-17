
using EvaluacionModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public interface IMedidorTraficoDAL
    {
        void Save(MedidorTrafico mt);
        List<MedidorTrafico> GetAll();

    }
}
