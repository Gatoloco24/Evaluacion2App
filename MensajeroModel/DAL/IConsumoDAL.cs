
using EvaluacionModel.DAL;
using EvaluacionModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public interface IConsumoDAL
    {
        void Save(Consumo c);
        List<Consumo> GetAll();
    }
}
