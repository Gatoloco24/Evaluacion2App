using EvaluacionModel.DAL;

using EvaluacionModel.DAL;
using EvaluacionModel.DAL;
using EvaluacionModel.DTO;
using SocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2App.Hilos
{
    public class HiloCliente
    {
        public static DateTime now;
        DateTime now1 = DateTime.Now;
        private ILecturaDAL dal = LecturaDAlFactory.CreateDal();
        private IMedidorTraficoDAL dal1 = MedidorTraficoDALFactory.CreateDal();
        private IMedidorConsumoDAL dal2 = MedidorConsumoDALFactory.CreateDal();
        private ClienteSocket clientesocket;
        public HiloCliente(ClienteSocket clientesocket)
        {
            this.clientesocket = clientesocket;
        }

        public void Ejecutar()
        {


            string tipo, valor;

            DateTime now = DateTime.Now;
            string fecha = now.ToString("dd-MM-yyyy-HH:mm:ss");
            Console.WriteLine("fecha: " + now);
            clientesocket.Escribir("fecha: " + now);
            int contador = 0;
            string valoractual = "";
            string valorTrafico = "cantidad de autos entre 1 y 99;";
            string valorConsumo = "Kwh entre 1 y 99";

            do
            {
                tipo = "nulo";

                tipo = clientesocket.Leer().Trim();
                Console.WriteLine("Ingresando...intento n° " + contador);

                switch (tipo)
                {
                    case "Trafico": { tipo = "Trafico"; valoractual = valorTrafico; break; }
                    case "Consumo": { tipo = "Consumo"; valoractual = valorConsumo; break; }
                    default: { tipo = "nulo"; contador = contador + 1; break; }
                }

            } while (tipo == "nulo");
            int errores = 0;
           
            do
            {
                clientesocket.Escribir("fecha: " + now);
                Console.WriteLine("fecha: " + now);
                clientesocket.Escribir("Adentro, usted ingreso " + tipo);
                Console.WriteLine("Adentro, usted ingreso " + tipo);
                clientesocket.Escribir("Proporcione fecha, nr Serie, medidor: " + tipo + " y valor: " + valoractual);
                Console.WriteLine("Proporcione fecha, nr Serie, medidor: " + tipo + " y valor: " + valoractual);
                clientesocket.Escribir("ejemplo : 11-11-1111-11:11:11|1234|Trafico|20");
                Console.WriteLine("ejemplo : 11-11-1111-11:11:11|1234|Trafico|20");
                string cadena = clientesocket.Leer().Trim();
                string cadenafecha = cadena.Substring(0, 19);
                string cadenaserie = cadena.Substring(20, 4);
                string cadenamedidor = cadena.Substring(25, 7);
                string cadeenavalor = cadena.Substring(33, 2);
                string cadenahora = cadena.Substring(15,2);

                Random estado = new Random();
                int azar;
                azar = estado.Next(-1, 2);
                string salida;
                switch (azar)
                {
                    case '0': { salida = "OK"; break; }
                    case '1': { salida = "Punto de carga lleno"; break; }
                    case '2': { salida = "Requiere mantencion preventiva"; break; }
                    default: { salida = "Error de lectura"; break; }
                }

                int cantidad = Convert.ToInt32(cadeenavalor);
                
                
                if (cantidad <= 0 || cantidad >= 1001)
                {
                    errores = errores + 1;
                    clientesocket.Escribir("fecha servidor: " + now +" |nr Serie |" + cadenaserie + "|  ERROR ( " + cadeenavalor + ") : el Valor debe estar entre 1 y 1000 || ha pasado mas de media hora desde el inicio y el ingreso");

                }
                else
                {
                    errores = 0;
                    clientesocket.Escribir("fecha servidor: " + now + "| WAIT...procesando fecha entregada =( " + cadenafecha + " )");

                    clientesocket.Escribir("| fecha | " + now + "| tipo |" + cadenamedidor + "| valor |" + cadeenavalor + " |{ " + azar + "-" + salida + " }| " + "| UPDATE");
                }

                DateTime now3 = DateTime.Now;
                string fecha3 = now3.ToString("dd-MM-yyyy-HH:mm:ss");
                Lectura l = new Lectura();
                l.Fecha = now3;
                l.Valor = cadenaserie;
                l.Tipo = "TCP";
                lock (dal)
                {
                    dal.Save(l);
                    clientesocket.Escribir("Mensaje de Confirmacion los datos Fecha, Valor y Tipo de coneccion");
                    clientesocket.Escribir("Se han registrado en el archivo Trafico.txt que esta en bin/Debug...");
                }
                clientesocket.CerrarConexion();
                

           } while (errores != 0);


                 
            }
    }
}
            
        
    

