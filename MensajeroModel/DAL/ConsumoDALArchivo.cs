using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluacionModel.DAL;

using System.IO;

namespace EvaluacionModel.DAL
{

    public class ConsumoDALArchivo : IConsumoDAL
    {
        public static DateTime now;
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "Consumo.txt";
        //Patron Singleton
        //1. Constructor privado
        private ConsumoDALArchivo()
        {
        }
        //2. Un atributo de tipo estatico de la misma instancia
        private static IConsumoDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static IConsumoDAL GetInstance()
        {
            if (instancia == null)
            {
                instancia = new ConsumoDALArchivo();
            }
            return instancia;
        }

        public List<Consumo> GetAll()
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea = null;
                    do
                    {
                        linea = reader.ReadLine();
                        if (linea != null)
                        {

                            string[] textoArray = linea.Split('|');
                            Consumo c = new Consumo()
                            {
                                Fechita = textoArray[0],
                                Tipo = textoArray[1],
                                Valor = textoArray[2]
                            };
                            lista.Add(c);
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
        public void Save(Consumo c)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(c);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {
            }
        }

       
    }
}