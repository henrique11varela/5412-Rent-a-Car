using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        public Carro(Carro c) : this(c.Id, c.Marca, c.Modelo, c.Cor, c.QuantRodas, c.Matricula, c.Ano, c.Status, c.FreeExpect, c.ValorDia, c.QuantDoors, c.IsManual)
        { 
        }

        #endregion


    }
}