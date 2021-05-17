using EvaluacionModel.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionoModel.DAL
{
    public class MedidorTraficoDALArchivo : IMedidorTraficoDAL
    {
        public static DateTime now;
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "MedidorTrafico.txt";
        //Patron Singleton
        //1. Constructor privado
        private MedidorTraficoDALArchivo()
        {
        }
        //2. Un atributo de tipo estatico de la misma instancia
        private static IMedidorTraficoDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static IMedidorTraficoDAL GetInstance()
        {
            if (instancia == null)
            {
                instancia = new MedidorTraficoDALArchivo();
            }
            return instancia;
        }

        public List<MedidorTrafico> GetAll()
        {
            List<MedidorTrafico> lista = new List<MedidorTrafico>();
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
                            MedidorTrafico mt = new MedidorTrafico()
                            {
                                
                                Modelo = textoArray[0],
                                NrSerie = textoArray[1],
                                Cantidad = textoArray[2]
                            };
                            lista.Add(mt);
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
        public void Save(MedidorTrafico mt)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(mt);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {
            }
        }


    }
}
