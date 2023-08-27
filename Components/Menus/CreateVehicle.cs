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
            createCarro.Location = new Point(0, 0);
            void openCarroForm(object sender, EventArgs e) { 
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CarroForm());
            }
            createCarro.Click += openCarroForm;
            createCarro.Click += closeThis;

            //Create mota button
            FlatButton createMota = new FlatButton();
            createMota.Text = "Mota";
            this.Controls.Add(createMota);
            createMota.Location = new Point(0, createMota.Height);
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
            createCamiao.Location = new Point(0, createCamiao.Height * 2);
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
            createCamioneta.Location = new Point(0, createCamioneta.Height * 3);
            void openCamionetaForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CamionetaForm());
            }
            createCamioneta.Click += openCamionetaForm;
            createCamioneta.Click += closeThis;


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
