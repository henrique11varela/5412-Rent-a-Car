using Rent_a_Car.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DAL
{
    internal static class csvIds
    {
        public static void read()
        {
            if (File.Exists("Ids.csv"))
            {
                var sr = new StreamReader(@"Ids.csv");
                string line = sr.ReadLine();
                line = sr.ReadLine();
                List<string> splitLine = line.Split(",").ToList();

                Empresa.LastCarroId = Int32.Parse(splitLine[0]);
                Empresa.LastCamiaoId = Int32.Parse(splitLine[1]);
                Empresa.LastCamionetaId = Int32.Parse(splitLine[2]);
                Empresa.LastMotaId = Int32.Parse(splitLine[3]);
                Empresa.LastClienteId = Int32.Parse(splitLine[4]);

                sr.Close();
            }
            else
            {
                Empresa.LastCarroId = 1;
                Empresa.LastCamiaoId = 1;
                Empresa.LastCamionetaId = 1;
                Empresa.LastMotaId = 1;
                Empresa.LastClienteId = 1;
            }
        }
        public static void write()
        {
            var sw = new StreamWriter(@"Ids.csv");
            sw.WriteLine("Carro,Camiao,Camioneta,Mota,Cliente");

            string newLine = Empresa.LastCarroId.ToString();
            newLine += "," + Empresa.LastCamiaoId.ToString();
            newLine += "," + Empresa.LastCamionetaId.ToString();
            newLine += "," + Empresa.LastMotaId.ToString();
            newLine += "," + Empresa.LastClienteId.ToString();

            sw.WriteLine(newLine);

            sw.Close();
        }
    }
}
