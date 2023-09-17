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
using Rent_a_Car.Components.Forms;
using System.Windows.Forms;
using Rent_a_Car.Components.Menus;

namespace Rent_a_Car.Components.Details
{
    internal class ManutencaoDetails : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Manutencao manutencao = new Manutencao(-1, "", DateTime.Now, DateTime.Now, "");

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public ManutencaoDetails()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public ManutencaoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public ManutencaoDetails(Manutencao c) : this()
        {
            manutencao = c;
        }

        public ManutencaoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left, Manutencao c) : this(c)
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


            //marca.textBox.Text = carro.Marca;
            //modelo.textBox.Text = carro.Modelo;
            //cor.textBox.Text = carro.Cor;
            //matricula.textBox.Text = carro.Matricula;
            //ano.textBox.Text = carro.Ano.ToString();
            //quantRodas.textBox.Text = carro.QuantRodas.ToString();
            //valorDia.textBox.Text = carro.ValorDia.ToString();
            //quantDoors.textBox.Text = carro.QuantDoors.ToString();
            //isManual.textBox.Text = carro.IsManual.ToString();


            //Terminar Button
            FlatButton Terminar = new FlatButton();
            Terminar.Text = "Terminar Manutenção";
            this.Controls.Add(Terminar);
            Terminar.Location = new Point(25, this.Height - Terminar.Height - 25);
            Terminar.Size = new Size(this.Width / 2 - 2 * 25, Terminar.Height);
            Terminar.BGC = ts.dark;
            Terminar.BGC_HOVER = ts.dark_emphasis;
            Terminar.ForeColor = ts.light;
            void terminarClick(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Terminar manutenção?", "Terminar manutenção?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                Emp.RemoveManutencao(manutencao);
                DAL.DAL.storeManutencao();
                DAL.DAL.convertManutencao();
                Emp.manutencaoTable.FillData(Emp.ManutencaoList);
                Emp.vehicleTable.FillData(Emp.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Terminar.Click += terminarClick;

            //Cancel Button
            FlatButton Fechar = new FlatButton();
            Fechar.Text = "Fechar";
            this.Controls.Add(Fechar);
            Fechar.Location = new Point(this.Width / 2 + 25, this.Height - Fechar.Height - 25);
            Fechar.Size = new Size(this.Width / 2 - 2 * 25, Fechar.Height);
            Fechar.BGC = ts.dark;
            Fechar.BGC_HOVER = ts.dark_emphasis;
            Fechar.ForeColor = ts.light;
            void fecharClick(object sender, EventArgs e)
            {
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Fechar.Click += fecharClick;

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}

