using EvaluacionModel.DAL;
using EvaluacionModel.DAL;
using EvaluacionModel.DAL;
using EvaluacionModel.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2
{
    public partial class Program
    {
        static IMedidorTraficoDAL dal = MedidorTraficoDALFactory.CreateDal();
        static IMedidorConsumoDAL dal1 = MedidorConsumoDALFactory.CreateDal();
        public static DateTime now;

        static void IngresarMedidor()
        {
            string id,Modelo,NrSerie,Cantidad;

            DateTime now = DateTime.Now;
            Console.WriteLine("fecha: " + now);
            string valoractual = "";
            string valorTrafico = "cantidad de autos entre 1 y 99;";
            string valorConsumo = "Kwh entre 1 y 99";
            do
            {
                Modelo = "nulo";
                Console.WriteLine("ingrese Medidor: Trafico - Consumo");
                Modelo = Console.ReadLine().Trim();
                Console.WriteLine("Ingresando...");
                
                switch (Modelo)
                {
                    case "Trafico": { Modelo = "Trafico";valoractual = valorTrafico; break; }
                    case "Consumo": { Modelo = "Consumo";valoractual = valorConsumo; break; }
                    default: { Modelo = "nulo"; break; }
                }
            } while (Modelo == "nulo");
            Console.WriteLine("Adentro");
            
            Console.WriteLine("Proporcione Nr Serie ejemplo: 1111");
            NrSerie = Console.ReadLine().Trim();
            Console.WriteLine("Proporcione " + valoractual + "ejemplo:22" + valoractual);
            Cantidad = Console.ReadLine().Trim();
            if (Modelo == "Trafico")
            { 
                MedidorTrafico mt = new MedidorTrafico();
                
                 mt.Modelo = Modelo;
                 mt.NrSerie = NrSerie;
                 mt.Cantidad = Cantidad;
          
                lock (dal)
                  {
                   dal.Save(mt);
                  }

                Console.WriteLine("Se Registro un medidor de :" + mt.Modelo + "|" + mt.NrSerie + "|" + mt.Cantidad);
                Console.WriteLine("Solo se puede ver en el archivo de 'MedidorTrafico.txt' que se ");
                Console.WriteLine("enceuntra en bin/Debug.. de este Proyecto");
            }
            if(Modelo == "Consumo")
            {
                MedidorConsumo mc = new MedidorConsumo();
                
                mc.Modelo = Modelo;
                mc.NrSerie = NrSerie;
                mc.Kwh = Cantidad;

                lock (dal1)
                {
                    dal1.Save(mc);
                }
                Console.WriteLine("Se Registro un medidor de :" + mc.Modelo +"|"+mc.NrSerie+"|"+mc.Kwh);
                Console.WriteLine("Solo se puede ver en el archivo de 'MedidorConsumo.txt' que se ");
                Console.WriteLine("enceuntra en bin/Debug.. de este Proyecto");

            }
            
        }

   

      
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Seleccione Opcion:");
            Console.WriteLine("1. Ingreso de Medidor");
            
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1": IngresarMedidor(); break;
                
                case "0": continuar = false; break;
            }
            return continuar;
        }
    }

}
