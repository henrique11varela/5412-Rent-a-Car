using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Camiao : Veiculo
    {
        #region attributes
        private float maxWeight;
        #endregion

        #region getset
        public float MaxWeight
        {
            get
            {
                return maxWeight;
            }
            set
            {
                maxWeight = value;
            }
        }
        #endregion

        #region constructors
        public Camiao() : base()
        {
            maxWeight = 0;
        }

        public Camiao(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, float maxWeight) : base(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia)
        {
            this.maxWeight = maxWeight;
        }
        #endregion
    }
}
