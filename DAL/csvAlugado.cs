using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvAlugado
    {
        public static List<List<string>> Alugado = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Alugado.csv"))
            {
                var sr = new StreamReader(@"Alugado.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Alugado.Add(splitLine);
                }
                sr.Close();
                Alugado.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Alugado.csv");
            int listLength = Alugado.Count;
            sw.WriteLine("idVeiculo,dataInicio,dataPrevistaFim,idCliente");
            foreach (var item in Alugado)
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
