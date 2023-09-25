using Rent_a_Car.Classes;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;

namespace Rent_a_Car.Components.Forms
{
    internal class AlugadoValorForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Alugado alugado;

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public AlugadoValorForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public AlugadoValorForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public AlugadoValorForm(Alugado m) : this()
        {
            alugado = m;
        }

        public AlugadoValorForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Alugado m) : this(m)
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

            float valor = 0;
            foreach (dynamic item in Emp.VehicleList)
            {
                if (item.Id == alugado.IdVeiculo && item.GetType().Name == alugado.TipoVeiculo)
                {
                    valor = ((alugado.DataInicio - DateTime.Now).Days + 1) * item.ValorDia;
                    break;
                }
            }

            Label label = new Label();
            label.Font = ts.largeFont;
            label.Text = "Valor";
            label.Size = new Size(TextRenderer.MeasureText(label.Text, label.Font).Width, label.Font.Height) ;
            label.Location = new Point((this.Width - label.Width) / 2, label.Font.Height);
            this.Controls.Add(label);

            TextBox valorPagar = new TextBox();
            valorPagar.Text = valor.ToString() + "€";
            valorPagar.ReadOnly = true;
            valorPagar.Location = new Point(25, label.Height * 3);
            valorPagar.Size = new Size(this.Width - 2 * 25, ts.mediumFont.Height);
            this.Controls.Add(valorPagar);



            TextBox textBox = new TextBox();
            textBox.Location = new Point(25, label.Height * 3 + 25 + valorPagar.Height);
            textBox.Size = new Size(this.Width - 2 * 25, ts.mediumFont.Height);
            this.Controls.Add(textBox);

            FlatButton Submit = new FlatButton();
            Submit.Text = "Submeter";
            this.Controls.Add(Submit);
            Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.light;
            void submitClick(object sender, EventArgs e)
            {
                try {
                    if (textBox.Text.Length < 1) {
                        throw new Exception("Preencha o campo vazio.");
                    }
                    if (textBox.Text != float.Parse(textBox.Text).ToString())
                    {
                        throw new Exception("O valor tem de ser numerico.");
                    }
                    if (float.Parse(textBox.Text) < valor)
                    {
                        throw new Exception("O valor inserido nao e suficiente.");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro: " + ex.Message);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Terminar aluguer?\nO troco é {float.Parse(textBox.Text) - valor}€", "Confirmacao", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                Emp.AddAlugadoHist(new AlugadoHist(alugado.IdVeiculo, alugado.TipoVeiculo, alugado.DataInicio, DateTime.Now, alugado.IdCliente, valor));
                DAL.DAL.storeAlugadoHist();
                Emp.alugadoHistTable.FillData(Emp.AlugadoHistList);

                Emp.RemoveAlugado(alugado);
                DAL.DAL.storeAlugado();
                DAL.DAL.convertAlugado();
                Emp.alugadoTable.FillData(Emp.AlugadoList);
                foreach (var veiculo in Emp.VehicleList)
                {
                    var veiculoTemp = Emp.ConvertObj(veiculo);
                    if (veiculoTemp.Id == alugado.IdVeiculo && veiculoTemp.GetType().Name == alugado.TipoVeiculo)
                    {
                        veiculoTemp.Status = "Livre";
                        break;
                    }
                }
                Emp.vehicleTable.FillData(Emp.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Submit.Click += submitClick;

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancelar";
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
