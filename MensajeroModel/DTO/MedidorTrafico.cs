using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class MedidorTrafico
    {
       
        private string modelo;
        private string nrSerie;
        private string cantidad;

     

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

        public string Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public override string ToString()
        {
            return Modelo + ";" + NrSerie + ";" + Cantidad;
        }
    }
}
