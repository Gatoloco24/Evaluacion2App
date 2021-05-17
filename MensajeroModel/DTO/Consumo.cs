using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class Consumo
    {
        public DateTime fecha;
        private string valor;
        private string tipo;
        private string unidadMedida;
        public string fechita;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public string Valor
        {
            get
            {
                return valor;
            }

            set
            {
                valor = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public string UnidadMedida
        {
            get
            {
                return unidadMedida;
            }

            set
            {
                unidadMedida = value;
            }
        }

        public DateTime now { get; internal set; }
        public string Fecha1 { get; internal set; }

        public string Fechita
        {
            get
            {
                return fechita;
            }

            set
            {
                fechita = value;
            }
        }

        public override string ToString()
        {
            return now + ";" + Valor + ";" + Tipo + ";" + UnidadMedida;
        }

        
    }
}
