using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Alugado
    {
        #region attributes
        //private variables
        private int idVeiculo;
        private string tipoVeiculo;
        private DateTime dataInicio;
        private DateTime dataPrevistaFim;
        private string contacto;
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

        public string Contacto
        {
            get
            {
                return contacto;
            }
            set
            {
                contacto = value;
            }
        }
        #endregion


        #region constructors
        //constructors

        public Alugado(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, string contacto)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.dataInicio = dataInicio;
            this.dataPrevistaFim = dataPrevistaFim;
            this.contacto = contacto;
        }
        #endregion

    }
}
