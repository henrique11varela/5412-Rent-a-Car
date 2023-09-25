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
            createCarro.Image = Image.FromFile("..\\..\\..\\assets\\icons\\carro.png");
            createCarro.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(createCarro);

            //size/location before
            //createCarro.Location = new Point(25, 25);
            //createCarro.Size = new Size(this.Width - 2 * 25, createCarro.Height);

            //size/location after
            createCarro.Location = new Point(this.Width / 2 - this.Width / 4, 25);
            createCarro.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            createCarro.BGC = ts.white;
            createCarro.BGC_HOVER = ts.dark_emphasis;
            createCarro.ForeColor = ts.dark;
            void openCarroForm(object sender, EventArgs e) { 
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CarroForm());
            }
            createCarro.Click += openCarroForm;
            createCarro.Click += closeThis;





            //Create mota button
            FlatButton createMota = new FlatButton();
            createMota.Text = "Mota";
            createMota.Image = Image.FromFile("..\\..\\..\\assets\\icons\\mota.png");
            createMota.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(createMota);

            //size/location before
            //createMota.Location = new Point(25, (createMota.Height + 25 * 2));
            //createMota.Size = new Size(this.Width - 2 * 25, createMota.Height);

            //size/location after
            createMota.Location = new Point(this.Width - this.Width / 2 + 25, 25);
            createMota.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            createMota.BGC = ts.white;
            createMota.BGC_HOVER = ts.dark_emphasis;
            createMota.ForeColor = ts.dark;
            void openMotaForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.MotaForm());
            }
            createMota.Click += openMotaForm;
            createMota.Click += closeThis;





            //Create camiao button
            FlatButton createCamiao = new FlatButton();
            createCamiao.Text = "Camião";
            createCamiao.Image = Image.FromFile("..\\..\\..\\assets\\icons\\camiao.png");
            createCamiao.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(createCamiao);

            //size/location before
            //createCamiao.Location = new Point(25, (createCamiao.Height * 2 + 25 * 3));
            //createCamiao.Size = new Size(this.Width - 2 * 25, createCamiao.Height);

            //size/location after
            createCamiao.Location = new Point(this.Width / 2 - this.Width / 4, this.Width / 4 - 25 + 2 * 25);
            createCamiao.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            createCamiao.BGC = ts.white;
            createCamiao.BGC_HOVER = ts.dark_emphasis;
            createCamiao.ForeColor = ts.dark;
            void openCamiaoForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CamiaoForm());
            }
            createCamiao.Click += openCamiaoForm;
            createCamiao.Click += closeThis;

            
            
            
            
            
            
            //Create camioneta button
            FlatButton createCamioneta = new FlatButton();
            createCamioneta.Text = "Camioneta";
            createCamioneta.Image = Image.FromFile("..\\..\\..\\assets\\icons\\camioneta.png");
            createCamioneta.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(createCamioneta);

            //size/location before
            //createCamioneta.Location = new Point(25, (createCamioneta.Height * 3 + 25 * 4));
            //createCamioneta.Size = new Size(this.Width - 2 * 25, createCamioneta.Height);

            //size/location after
            createCamioneta.Location = new Point(this.Width - this.Width / 2 + 25, this.Width / 4 - 25 + 2 * 25);
            createCamioneta.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            createCamioneta.BGC = ts.white;
            createCamioneta.BGC_HOVER = ts.dark_emphasis;
            createCamioneta.ForeColor = ts.dark;
            void openCamionetaForm(object sender, EventArgs e)
            {
                this.Parent.Controls.Add(new Rent_a_Car.Components.Forms.CamionetaForm());
            }
            createCamioneta.Click += openCamionetaForm;
            createCamioneta.Click += closeThis;

            //Cancel button
            FlatButton cancel = new FlatButton();
            cancel.Text = "Cancel";
            cancel.Image = Image.FromFile("..\\..\\..\\assets\\icons\\cancelar.png");
            cancel.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(cancel);

            //size/location before
            //cancel.Location = new Point(25, this.Height - (cancel.Height + 25));
            //cancel.Size = new Size(this.Width - 2 * 25, cancel.Height);

            //size/location after
            cancel.Location = new Point(this.Width / 2 - (this.Width / 4 - 25) / 2, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            cancel.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            cancel.BGC = ts.white;
            cancel.BGC_HOVER = ts.dark_emphasis;
            cancel.ForeColor = ts.dark;
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
