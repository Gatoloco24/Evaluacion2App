using MensajeroApp.Hilos;
using EvaluacionModel.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluacion2
{
    public partial class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando hilo del Server");
            int puerto = int.Parse(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu()) ;
        }
    }
}
