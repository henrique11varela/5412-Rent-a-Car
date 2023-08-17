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

        //csvCarro;
        public static List<Carro> ConvertCarro()
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
        public static List<Mota> ConvertMota()
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
        public static List<Camiao> ConvertCamiao()
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
        public static List<Camioneta> ConvertCamioneta()
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



    }
}
