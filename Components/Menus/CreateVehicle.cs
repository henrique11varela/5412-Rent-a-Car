using Rent_a_Car.Components.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Menus
{
    internal class CreateVehicle : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };

        #region Child elements
        #endregion

        #region Constructors
        public CreateVehicle()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.light;
        }

        public CreateVehicle(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
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
            if (this.Parent == null)
            {
                return;
            }
            this.Location = new Point(_margin[3], _margin[0]);
            this.Size = new Size(this.Parent.Width - _margin[1] - _margin[3], this.Parent.Height - _margin[0] - _margin[2]);
            #endregion

            //Create carro button
            FlatButton createCarro = new FlatButton();
            createCarro.Text = "Carro";
            this.Controls.Add(createCarro);
            createCarro.Location = new Point(25, 25);
            createCarro.Size = new Size(this.Width - 2 * 25, createCarro.Height);
            void openCarroForm(object sender, EventArgs e) { 
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CarroForm());
            }
            createCarro.Click += openCarroForm;
            createCarro.Click += closeThis;

            //Create mota button
            FlatButton createMota = new FlatButton();
            createMota.Text = "Mota";
            this.Controls.Add(createMota);
            createMota.Location = new Point(25, (createMota.Height + 25 * 2));
            createMota.Size = new Size(this.Width - 2 * 25, createMota.Height);
            void openMotaForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.MotaForm());
            }
            createMota.Click += openMotaForm;
            createMota.Click += closeThis;

            //Create camiao button
            FlatButton createCamiao = new FlatButton();
            createCamiao.Text = "Camião";
            this.Controls.Add(createCamiao);
            createCamiao.Location = new Point(25, (createCamiao.Height * 2 + 25 * 3));
            createCamiao.Size = new Size(this.Width - 2 * 25, createCamiao.Height);
            void openCamiaoForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CamiaoForm());
            }
            createCamiao.Click += openCamiaoForm;
            createCamiao.Click += closeThis;

            //Create camioneta button
            FlatButton createCamioneta = new FlatButton();
            createCamioneta.Text = "Camioneta";
            this.Controls.Add(createCamioneta);
            createCamioneta.Location = new Point(25, (createCamioneta.Height * 3 + 25 * 4));
            createCamioneta.Size = new Size(this.Width - 2 * 25, createCamioneta.Height);
            void openCamionetaForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CamionetaForm());
            }
            createCamioneta.Click += openCamionetaForm;
            createCamioneta.Click += closeThis;

            //Cancel button
            FlatButton cancel = new FlatButton();
            cancel.Text = "Cancel";
            this.Controls.Add(cancel);
            cancel.Location = new Point(25, this.Height - (cancel.Height + 25));
            cancel.Size = new Size(this.Width - 2 * 25, cancel.Height);
            cancel.Click += closeThis;


            #region Preset setup
            this.BringToFront();
            #endregion
        }

        private void closeThis(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
