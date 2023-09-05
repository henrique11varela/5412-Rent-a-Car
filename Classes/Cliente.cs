using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Classes
{
    internal class Cliente
    {
        #region attributes
        //private variables
        private int id;
        private string nome;
        private string contacto;
        #endregion


        #region getset
        //getters, setters
        public int Id
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
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
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
        public Cliente()
        {
            this.id = -1;
            this.nome = "nome";
            this.contacto = "000000000";
        }

        public Cliente(int id, string nome, string contacto)
        {
            this.id = id;
            this.nome = nome;
            this.contacto = contacto;
        }

        public Cliente(Cliente c) : this(c.Id, c.Nome, c.Contacto)
        {
        }
        #endregion

    }
}
