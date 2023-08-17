using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvCarro
    {
        public static List<List<string>> Carro = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Carro.csv"))
            {
                var sr = new StreamReader(@"Carro.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Carro.Add(splitLine);
                }
                sr.Close();
                Carro.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Carro.csv");
            int listLength = Carro.Count;
            sw.WriteLine("");
            foreach (var item in Carro)
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
