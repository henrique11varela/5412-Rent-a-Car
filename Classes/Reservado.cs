using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Reservado
    {
        #region attributes
        //private variables
        private int idVeiculo;
        private string tipoVeiculo;
        private int idCliente;
        #endregion


        #region getset
        //getters, setters
        public int IdVeiculo
        {
            get
            {
                return idVeiculo;
            }
            set
            {
                idVeiculo = value;
            }
        }
        public string TipoVeiculo
        {
            get
            {
                return tipoVeiculo;
            }
            set
            {
                tipoVeiculo = value;
            }
        }

        public int IdCliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
            }
        }
        #endregion


        #region constructors
        //constructors

        public Reservado(int idVeiculo, string tipoVeiculo, int idCliente)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.idCliente = idCliente;
        }
        public Reservado(Reservado r) : this(r.IdVeiculo, r.TipoVeiculo, r.IdCliente)
        {
        }
        #endregion
    }
}
