using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class Lectura
    {
        public DateTime now = DateTime.Now;

        private DateTime fecha;

        private string valor;
        private string tipo;
        private string unidadMedida;
        public string fechita;

        

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

        public DateTime Fecha
        {
            get
            {
                fecha = DateTime.Now;
                return fecha;
            }

            set
            {
                fecha = DateTime.Now;
                fecha = value;
            }
        }

        public override string ToString()
        {
            return now + ";" + Valor + ";" + Tipo + ";" + UnidadMedida;
        }

        
    }
}
