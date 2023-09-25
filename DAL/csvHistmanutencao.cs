using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal class csvHistmanutencao
    {
        public static List<List<string>> Histmanutencao = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Histmanutencao.csv"))
            {
                var sr = new StreamReader(@"Histmanutencao.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Histmanutencao.Add(splitLine);
                }
                sr.Close();
                Histmanutencao.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Histmanutencao.csv");
            int listLength = Histmanutencao.Count;
            sw.WriteLine("idVeiculo,tipoVeiculo,dataInicio,dataFim,problem,valor");
            foreach (var item in Histmanutencao)
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
