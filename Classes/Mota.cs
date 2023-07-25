using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Mota : Veiculo
    {
        #region attributes

        private int cubicCapacity;

        #endregion

        #region getset

        public int CubicCapacity
        {
            get
            {
                return cubicCapacity;
            }
            set
            {
                cubicCapacity = value;
            }
        }

        #endregion

        #region constructors

        public Mota() : base()
        {
            cubicCapacity = 0;
        }

        public Mota(string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int cubicCapacity) : base(marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia)
        {
            this.cubicCapacity = cubicCapacity;
        }

        #endregion
    }
}