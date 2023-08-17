using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




    }
}
