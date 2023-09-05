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
    internal class CamiaoDetails : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Camiao camiao = new Camiao();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public CamiaoDetails()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CamiaoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CamiaoDetails(Camiao c) : this()
        {
            camiao = c;
        }

        public CamiaoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left, Camiao c) : this(c)
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

            int id = camiao.Id;


            //marca.textBox.Text = camiao.Marca;
            //modelo.textBox.Text = camiao.Modelo;
            //cor.textBox.Text = camiao.Cor;
            //matricula.textBox.Text = camiao.Matricula;
            //ano.textBox.Text = camiao.Ano.ToString();
            //quantRodas.textBox.Text = camiao.QuantRodas.ToString();
            //valorDia.textBox.Text = camiao.ValorDia.ToString();
            //quantDoors.textBox.Text = camiao.QuantDoors.ToString();
            //isManual.textBox.Text = camiao.IsManual.ToString();


            //Reservar Button
            FlatButton Reservar = new FlatButton();
            Reservar.Text = "Reservar";
            this.Controls.Add(Reservar);
            Reservar.Location = new Point(25, this.Height - Reservar.Height - 25);
            Reservar.Size = new Size(this.Width / 2 - 2 * 25, Reservar.Height);
            Reservar.BGC = ts.dark;
            Reservar.BGC_HOVER = ts.dark_emphasis;
            Reservar.ForeColor = ts.light;
            void reservarClick(object sender, EventArgs e)
            {
                MessageBox.Show("Reservar logic" + id);
                //validate inputs

                //DAL.DAL.storeCarro();
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Reservar.Click += reservarClick;

            //Alugar Button
            FlatButton Alugar = new FlatButton();
            Alugar.Text = "Alugar";
            this.Controls.Add(Alugar);
            Alugar.Location = new Point(25, this.Height - Alugar.Height * 2 - 25 * 2);
            Alugar.Size = new Size(this.Width / 2 - 2 * 25, Alugar.Height);
            Alugar.BGC = ts.dark;
            Alugar.BGC_HOVER = ts.dark_emphasis;
            Alugar.ForeColor = ts.light;
            void alugarClick(object sender, EventArgs e)
            {
                MessageBox.Show("Alugar logic" + id);
                //validate inputs

                //DAL.DAL.storeCarro();
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Alugar.Click += alugarClick;

            //Manutencao Button
            FlatButton Manutencao = new FlatButton();
            Manutencao.Text = "Manutencao";
            this.Controls.Add(Manutencao);
            Manutencao.Location = new Point(this.Width / 2 + 25, this.Height - Manutencao.Height * 2 - 25 * 2);
            Manutencao.Size = new Size(this.Width / 2 - 2 * 25, Manutencao.Height);
            Manutencao.BGC = ts.dark;
            Manutencao.BGC_HOVER = ts.dark_emphasis;
            Manutencao.ForeColor = ts.light;
            void manutencaoClick(object sender, EventArgs e)
            {
                MessageBox.Show("Manutencao logic" + id);
                //validate inputs

                //DAL.DAL.storeCarro();
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Manutencao.Click += manutencaoClick;

            //Cancel Button
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

