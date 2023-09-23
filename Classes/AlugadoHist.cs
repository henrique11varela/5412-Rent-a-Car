using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class AlugadoHist
    {
        #region attributes
        //private variables
        private int idVeiculo;
        private string tipoVeiculo;
        private DateTime dataInicio;
        private DateTime dataFim;
        private int idCliente;
        private float valor;
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
        public DateTime DataInicio
        {
            get
            {
                return dataInicio;
            }
            set
            {
                dataInicio = value;
            }
        }

        public DateTime DataFim
        {
            get
            {
                return dataFim;
            }
            set
            {
                dataFim = value;
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

        public float Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
        #endregion


        #region constructors
        //constructors

        public AlugadoHist(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataFim, int idCliente, float valor)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.idCliente = idCliente;
            this.valor = valor;
        }
        public AlugadoHist(AlugadoHist a) : this(a.IdVeiculo, a.TipoVeiculo, a.DataInicio, a.DataFim, a.IdCliente, a.Valor)
        {
        }
        #endregion

    }
}
