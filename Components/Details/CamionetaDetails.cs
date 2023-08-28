using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;
using Rent_a_Car.Components.Input;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Rent_a_Car.Components.Tables;
using System.Windows.Forms;

namespace Rent_a_Car.Components.Details
{
    internal class CamionetaDetails : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Camioneta camioneta = new Camioneta();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public CamionetaDetails()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CamionetaDetails(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CamionetaDetails(Camioneta c) : this()
        {
            camioneta = c;
        }

        public CamionetaDetails(int margin_top, int margin_right, int margin_bottom, int margin_left, Camioneta c) : this(c)
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }
        #endregion

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

            int id = camioneta.Id;


            //marca.textBox.Text = camioneta.Marca;
            //modelo.textBox.Text = camioneta.Modelo;
            //cor.textBox.Text = camioneta.Cor;
            //matricula.textBox.Text = camioneta.Matricula;
            //ano.textBox.Text = camioneta.Ano.ToString();
            //quantRodas.textBox.Text = camioneta.QuantRodas.ToString();
            //valorDia.textBox.Text = camioneta.ValorDia.ToString();
            //quantDoors.textBox.Text = camioneta.QuantDoors.ToString();
            //isManual.textBox.Text = camioneta.IsManual.ToString();


            FlatButton Select = new FlatButton();
            Select.Text = "Select";
            this.Controls.Add(Select);
            Select.Location = new Point(25, this.Height - Select.Height - 25);
            Select.Size = new Size(this.Width / 2 - 2 * 25, Select.Height);
            Select.BGC = ts.dark;
            Select.BGC_HOVER = ts.dark_emphasis;
            Select.ForeColor = ts.light;
            void selectClick(object sender, EventArgs e)
            {
                MessageBox.Show("Select logic" + id);
                //validate inputs

                //DAL.DAL.storeCamioneta();
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Select.Click += selectClick;

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
            this.Controls.Add(Cancel);
            Cancel.Location = new Point(this.Width / 2 + 25, this.Height - Cancel.Height - 25);
            Cancel.Size = new Size(this.Width / 2 - 2 * 25, Cancel.Height);
            Cancel.BGC = ts.dark;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.light;
            void cancelClick(object sender, EventArgs e)
            {
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Cancel.Click += cancelClick;

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}

