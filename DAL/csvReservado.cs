using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvReservado
    {
        public static List<List<string>> Reservado = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Reservado.csv"))
            {
                var sr = new StreamReader(@"Reservado.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Reservado.Add(splitLine);
                }
                sr.Close();
                Reservado.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Reservado.csv");
            int listLength = Reservado.Count;
            sw.WriteLine("idVeiculo,idCliente");
            foreach (var item in Reservado)
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
