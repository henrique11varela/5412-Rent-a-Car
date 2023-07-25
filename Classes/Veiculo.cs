using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Veiculo
    {
        #region attributes
        //private variables
        private string id;
        private string marca;
        private string modelo;
        private string cor;
        private int quantRodas;
        private string matricula;
        private int ano;
        private string status;
        private DateTime freeExpect;
        private float valorDia;
        #endregion


        #region getset
        //getters, setters
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                modelo = value;
            }
        }

        public string Cor
        {
            get
            {
                return cor;
            }
            set
            {
                cor = value;
            }
        }

        public int QuantRodas
        {
            get
            {
                return quantRodas;
            }
            set
            {
                quantRodas = value;
            }
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }
            set
            {
                matricula = value;
            }
        }

        public int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public DateTime FreeExpect
        {
            get
            {
                return freeExpect;
            }
            set
            {
                freeExpect = value;
            }
        }

        public float ValorDia
        {
            get
            {
                return valorDia;
            }
            set
            {
                valorDia = value;
            }
        }
        #endregion


        #region constructors
        //constructors
        public Veiculo()
        {
            marca = "";
            modelo = "";
            cor = "";
            quantRodas = 0;
            matricula = "";
            ano = 0;
            status = "";
            freeExpect = DateTime.Now;
            valorDia = 0;
        }

        public Veiculo(string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.cor = cor;
            this.quantRodas = quantRodas;
            this.matricula = matricula;
            this.ano = ano;
            this.status = status;
            this.freeExpect = freeExpect;
            this.valorDia = valorDia;
        }
        #endregion


    }
}