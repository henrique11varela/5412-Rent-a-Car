using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvHistalugado
    {
        public static List<List<string>> Histalugado = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Histalugado.csv"))
            {
                var sr = new StreamReader(@"Histalugado.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Histalugado.Add(splitLine);
                }
                sr.Close();
                Histalugado.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Histalugado.csv");
            int listLength = Histalugado.Count;
            sw.WriteLine("idVeiculo,tipoVeiculo,dataInicio,dataFim,idCliente,valor");
            foreach (var item in Histalugado)
            {
                int itemLength = item.Count;
                string newLine = item[0];
                for (int i = 1; i < itemLength; i++)
                {
                    newLine += "," + item[i];
                }
                sw.WriteLine(newLine);
            }
            sw.Close();
        }
    }
}
