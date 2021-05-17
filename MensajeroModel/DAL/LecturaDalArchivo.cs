using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluacionModel.DAL;

using System.IO;

namespace EvaluacionModel.DAL
{

    public class LecturaDalArchivo : ILecturaDAL
    {
        public static DateTime now;
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "Trafico.txt";
        //Patron Singleton
        //1. Constructor privado
        private LecturaDalArchivo()
        {
        }
        //2. Un atributo de tipo estatico de la misma instancia
        private static ILecturaDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static ILecturaDAL GetInstance()
        {
            if (instancia == null)
            {
                instancia = new LecturaDalArchivo();
            }
            return instancia;
        }

        public List<Lectura> GetAll()
        {
            List<Lectura> lista = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea = null;
                    DateTime now = DateTime.Now;
                    
                    Console.WriteLine("fecha: " + now);
                    do
                    {
                        linea = reader.ReadLine();
                        if (linea != null)
                        {
                           

                            string[] textoArray = linea.Split('|');
                            Lectura l = new Lectura()


                            {

                                
                                now = Convert.ToDateTime(textoArray[0]),
                                Tipo = textoArray[1],
                                Valor = textoArray[2]
                            };
                            lista.Add(l);
                        }
                    } while (linea != null);
                }
            }
            catch (IOException ex)
            {
                lista = null;
            }
            return lista;
        }
        public void Save(Lectura l)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(l);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {
            }
        }
    }
}