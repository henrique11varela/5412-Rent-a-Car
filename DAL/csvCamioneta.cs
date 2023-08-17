using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvCamioneta
    {
        public static List<List<string>> Camioneta = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Camioneta.csv"))
            {
                var sr = new StreamReader(@"Camioneta.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Camioneta.Add(splitLine);
                }
                sr.Close();
                Camioneta.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Camioneta.csv");
            int listLength = Camioneta.Count;
            sw.WriteLine("id,marca,modelo,cor,quantRodas,matricula,ano,valorDia,quantAxis,maxPassengers");
            foreach (var item in Camioneta)
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
