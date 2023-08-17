using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvCamiao
    {
        public static List<List<string>> Camiao = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Camiao.csv"))
            {
                var sr = new StreamReader(@"Camiao.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Camiao.Add(splitLine);
                }
                sr.Close();
                Camiao.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Camiao.csv");
            int listLength = Camiao.Count;
            sw.WriteLine("id,marca,modelo,cor,quantRodas,matricula,ano,valorDia,maxWeight");
            foreach (var item in Camiao)
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
