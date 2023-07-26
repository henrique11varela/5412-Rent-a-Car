using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Carro : Veiculo
    {
        #region attributes

        private int quantDoors;
        private bool isManual;

        #endregion


        #region getset
        public int QuantDoors
        {
            get
            {
                return quantDoors;
            }
            set
            {
                quantDoors = value;
            }
        }

        public bool IsManual
        {
            get
            {
                return isManual;
            }
            set
            {
                isManual = value;
            }
        }
        #endregion


        #region constructors

        public Carro() : base()
        {
            quantDoors = 0;
            isManual = true;
        }

        public Carro(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantDoors, bool isManual) : base(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia)
        {
            this.quantDoors = quantDoors;
            this.isManual = isManual;
        }

        #endregion


    }
}