using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Classes;

namespace Rent_a_Car.DAL
{
    internal static class DAL
    {
        #region ALL
        public static void readAll()
        {
            csvCarro.read();
            csvMota.read();
            csvCamioneta.read();
            csvCamiao.read();
            csvManutencao.read();
            csvAlugado.read();
            csvReservado.read();
            csvHistmanutencao.read();
            csvHistalugado.read();
        }
        public static void writeAll()
        {
            csvCarro.write();
            csvMota.write();
            csvCamioneta.write();
            csvCamiao.write();
            csvManutencao.write();
            csvAlugado.write();
            csvReservado.write();
            csvHistmanutencao.write();
            csvHistalugado.write();
        }
        #endregion

        #region From matrix to obj list

        public static List<Carro> convertCarro()
        {
            List<Carro> list = new List<Carro>();
            if (csvCarro.Carro.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCarro.Carro)
            {
                //status, freeExpect
                string status = "Free";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Carro(Int32.Parse(item[0]), item[1], item[2], item[3], Int32.Parse(item[4]), item[5], Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8]), Boolean.Parse(item[9])));
            }
            return list;
        }

        //csvMota;
        public static List<Mota> convertMota()
        {
            List<Mota> list = new List<Mota>();
            if (csvMota.Mota.Count < 1)
            {
                return list;
            }
            foreach (var item in csvMota.Mota)
            {
                //status, freeExpect
                string status = "Free";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Mota(Int32.Parse(item[0]), item[1], item[2], item[3], Int32.Parse(item[4]), item[5], Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8])));
            }
            return list;
        }

        //csvCamiao;
        public static List<Camiao> convertCamiao()
        {
            List<Camiao> list = new List<Camiao>();
            if (csvCamiao.Camiao.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCamiao.Camiao)
            {
                //status, freeExpect
                string status = "Free";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Camiao(Int32.Parse(item[0]), item[1], item[2], item[3], Int32.Parse(item[4]), item[5], Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), float.Parse(item[8])));
            }
            return list;
        }

        //csvCamioneta;
        public static List<Camioneta> convertCamioneta()
        {
            List<Camioneta> list = new List<Camioneta>();
            if (csvCamioneta.Camioneta.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCamioneta.Camioneta)
            {
                //status, freeExpect
                string status = "Free";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Camioneta(Int32.Parse(item[0]), item[1], item[2], item[3], Int32.Parse(item[4]), item[5], Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8]), Int32.Parse(item[9])));
            }
            return list;
        }



        //csvManutencao;
        //csvAlugado;
        //csvReservado;
        //csvHistmanutencao;
        //csvHistalugado;
        //string strDate = now1.ToString(FMT);
        #endregion

        #region From obj list to matrix

        public static void storeCarro()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CarrosList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca);
                line.Add(Empresa.ConvertObj(item).Modelo);
                line.Add(Empresa.ConvertObj(item).Cor);
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula);
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).QuantDoors.ToString());
                line.Add(Empresa.ConvertObj(item).IsManual.ToString());
                list.Add(line);
            }
            csvCarro.Carro = list;
        }

        public static void storeMota()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.MotasList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca);
                line.Add(Empresa.ConvertObj(item).Modelo);
                line.Add(Empresa.ConvertObj(item).Cor);
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula);
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).cubicCapacity.ToString());
                list.Add(line);
            }
            csvMota.Mota = list;
        }

        public static void storeCamiao()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CamioesList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca);
                line.Add(Empresa.ConvertObj(item).Modelo);
                line.Add(Empresa.ConvertObj(item).Cor);
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula);
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).MaxWeight.ToString());
                list.Add(line);
            }
            csvCamiao.Camiao = list;
        }

        public static void storeCamioneta()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CamionetasList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca);
                line.Add(Empresa.ConvertObj(item).Modelo);
                line.Add(Empresa.ConvertObj(item).Cor);
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula);
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).QuantAxis.ToString());
                line.Add(Empresa.ConvertObj(item).MaxPassengers.ToString());
                list.Add(line);
            }
            csvCamioneta.Camioneta = list;
        }

        #endregion

    }
}
