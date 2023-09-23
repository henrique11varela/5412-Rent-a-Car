using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Rent_a_Car.Classes
{
    internal class ManutencaoHist
    {
        #region attributes
        //private variables
        private int idVeiculo;
        private string tipoVeiculo;
        private DateTime dataInicio;
        private DateTime dataFim;
        private string problema;
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

        public string Problema
        {
            get
            {
                return problema;
            }
            set
            {
                problema = value;
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

        public ManutencaoHist(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataFim, string problema, float valor)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.problema = problema;
            this.valor = valor;
        }
        public ManutencaoHist(ManutencaoHist m) : this(m.IdVeiculo, m.TipoVeiculo, m.DataInicio, m.DataFim, m.Problema, m.Valor)
        {
        }
        #endregion

    }
}
