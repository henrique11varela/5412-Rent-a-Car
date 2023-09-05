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

        public Reservado(int idVeiculo, string tipoVeiculo, string contacto)
        {
            this.idVeiculo = idVeiculo;
            this.tipoVeiculo = tipoVeiculo;
            this.contacto = contacto;
        }
        #endregion
    }
}
