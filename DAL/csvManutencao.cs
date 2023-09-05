using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvManutencao
    {
        public static List<List<string>> Manutencao = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Manutencao.csv"))
            {
                var sr = new StreamReader(@"Manutencao.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Manutencao.Add(splitLine);
                }
                sr.Close();
                Manutencao.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Manutencao.csv");
            int listLength = Manutencao.Count;
            sw.WriteLine("idVeiculo,tipoVeiculo,dataInicio,dataPrevistaFim,problema");
            foreach (var item in Manutencao)
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
