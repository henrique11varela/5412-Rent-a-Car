using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvCliente
    {
        public static List<List<string>> Clientes = new List<List<string>>();
        public static void read()
        {
            if (File.Exists("Cliente.csv"))
            {
                var sr = new StreamReader(@"Cliente.csv");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<string> splitLine = line.Split(",").ToList();
                    Clientes.Add(splitLine);
                }
                sr.Close();
                Clientes.RemoveAt(0);
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Cliente.csv");
            int listLength = Clientes.Count;
            sw.WriteLine("id,nome,contacto");
            foreach (var item in Clientes)
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
