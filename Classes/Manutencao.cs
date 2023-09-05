using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Rent_a_Car.Classes
{
    internal class Manutencao
    {
        #region attributes
        //private variables
        private int idVeiculo;
        private string tipoVeiculo;
        private DateTime dataInicio;
        private DateTime dataPrevistaFim;
        private string problema;
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

        public DateTime DataPrevistaFim
        {
            get
            {
                return dataPrevistaFim;
            }
            set
            {
                dataPrevistaFim = value;
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
        #endregion


        #region constructors
        //constructors

        public Manutencao(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, string problema)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.dataInicio = dataInicio;
            this.dataPrevistaFim = dataPrevistaFim;
            this.problema = problema;
        }
        public Manutencao(Manutencao m) : this(m.IdVeiculo, m.TipoVeiculo, m.DataInicio, m.DataPrevistaFim, m.Problema)
        {
        }
        #endregion

    }
}
