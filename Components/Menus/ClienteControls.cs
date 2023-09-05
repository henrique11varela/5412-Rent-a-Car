using Rent_a_Car.Classes;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;

namespace Rent_a_Car.Components.Menus
{
    internal class ClienteControls : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };

        #region Child elements
        public ClienteForm clienteForm;
        #endregion

        #region Constructors
        public ClienteControls()
        {
            ParentChanged += Setup;
            BackColor = ts.light;
        }

        public ClienteControls(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }
        #endregion

        /// <summary>
        /// Event that places element after instance is created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setup(object sender, EventArgs e)
        {
            #region Preset setup
            if (Parent == null)
            {
                return;
            }
            Location = new Point(_margin[3], _margin[0]);
            Size = new Size(Parent.Width - _margin[1] - _margin[3], Parent.Height - _margin[0] - _margin[2]);
            #endregion


            


            //Create vehicle button
            FlatButton createCliente = new FlatButton();
            createCliente.Text = "Create Cliente";
            this.Controls.Add(createCliente);
            createCliente.Location = new Point(this.Width / 2 + 25, this.Height - 25 - createCliente.Height);
            createCliente.Size = new Size(this.Width / 2 - 2 * 25, createCliente.Height);
            createCliente.Click += newCliente;

            #region Preset setup
            BringToFront();
            #endregion
        }


        private void newCliente(object sender, EventArgs e)
        {
            clienteForm = new ClienteForm();
            Controls.Add(clienteForm);
        }
    }
}
