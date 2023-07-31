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

        public Mota(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int cubicCapacity) : base(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia)
        {
            this.cubicCapacity = cubicCapacity;
        }

        public Mota(Mota c) : this(c.Id, c.Marca, c.Modelo, c.Cor, c.QuantRodas, c.Matricula, c.Ano, c.Status, c.FreeExpect, c.ValorDia, c.CubicCapacity)
        { }

            #endregion
        }
}