using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DTO
{
    public class MedidorConsumo
    {
        
        private string modelo;
        private string nrSerie;
        private string kwh;

      

        public string Modelo
        {
            get
            {
                return modelo;
            }

            set
            {
                modelo = value;
            }
        }

        public string NrSerie
        {
            get
            {
                return nrSerie;
            }

            set
            {
                nrSerie = value;
            }
        }

        public string Kwh
        {
            get
            {
                return kwh;
            }

            set
            {
                kwh = value;
            }
        }

        public override string ToString()
        {
            return Modelo + ";" + NrSerie + ";" + Kwh;
        }
    }
}
