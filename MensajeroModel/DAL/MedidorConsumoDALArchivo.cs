using EvaluacionModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionModel.DAL
{
    public class MedidorConsumoDALArchivo : IMedidorConsumoDAL
    {
        public static DateTime now;DateTime now1 = DateTime.Now;
        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "MedidorConsumo.txt";
        //Patron Singleton
        //1. Constructor privado
        private MedidorConsumoDALArchivo()
        {
        }
        //2. Un atributo de tipo estatico de la misma instancia
        private static IMedidorConsumoDAL instancia;
        //3. Un metodo estatico que permita obtener la unica instancia
        public static IMedidorConsumoDAL GetInstance()
        {
            if (instancia == null)
            {
                instancia = new MedidorConsumoDALArchivo();
            }
            return instancia;
        }

        public List<MedidorConsumo> GetAll()
        {
            List<MedidorConsumo> lista = new List<MedidorConsumo>();
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
                            MedidorConsumo mc = new MedidorConsumo()
                            { 
                                Modelo = textoArray[0],
                                NrSerie = textoArray[1],
                                Kwh = textoArray[2]
                            };
                            lista.Add(mc);
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
        public void Save(MedidorConsumo mc)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(mc);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {
            }
        }


    }
}
