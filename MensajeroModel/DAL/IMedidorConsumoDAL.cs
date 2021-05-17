using EvaluacionModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public interface IMedidorConsumoDAL
    {
        void Save(MedidorConsumo mc);
        List<MedidorConsumo> GetAll();
    }
}
