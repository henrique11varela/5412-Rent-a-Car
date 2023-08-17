using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvMota
    {
        public static List<List<string>> Mota = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Mota.csv"))
            {
                var sr = new StreamReader(@"Mota.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Mota.Add(splitLine);
                }
                sr.Close();
                Mota.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Mota.csv");
            int listLength = Mota.Count;
            sw.WriteLine("id,marca,modelo,cor,quantRodas,matricula,ano,valorDia,cubicCapacity");
            foreach (var item in Mota)
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
