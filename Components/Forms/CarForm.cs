using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components.Input;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Rent_a_Car.Components.Tables;
using System.Windows.Forms;

namespace Rent_a_Car.Components.Forms
{
    internal class CarForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Carro carro = new Carro();

        //Create contructors
        public CarForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CarForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CarForm(Carro c) : this()
        {
            carro = c;
        }

        public CarForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Carro c) : this(c)
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        private void Setup(object sender, EventArgs e)
        {
            if (this.Parent == null)
            {
                return;
            }
            this.Location = new Point(_margin[3], _margin[0]);
            this.Size = new Size(this.Parent.Width - _margin[1] - _margin[3], this.Parent.Height - _margin[0] - _margin[2]);
            int id = carro.Id;

            InputBox marca = new InputBox();
            marca.Size = new Size(this.Width / 2 - (25 * 2), marca.Height);
            marca.Location = new Point(25, 25);
            marca.label.Text = "Marca";
            this.Controls.Add(marca);

            InputBox modelo = new InputBox();
            modelo.Size = new Size(this.Width / 2 - (25 * 2), marca.Height);
            modelo.Location = new Point(this.Width / 2 + 25, 25);
            modelo.label.Text = "Modelo";
            this.Controls.Add(modelo);

            InputBox cor = new InputBox();
            cor.Size = new Size(this.Width / 2 - (25 * 2), cor.Height);
            cor.Location = new Point(25, 25 + (25 + cor.Height) * 1);
            cor.label.Text = "Cor";
            this.Controls.Add(cor);

            InputBox matricula = new InputBox();
            matricula.Size = new Size(this.Width / 2 - (25 * 2), matricula.Height);
            matricula.Location = new Point(this.Width / 2 + 25, 25 + (25 + matricula.Height) * 1);
            matricula.label.Text = "Matricula";
            this.Controls.Add(matricula);

            InputBox ano = new InputBox();
            ano.Size = new Size(this.Width / 2 - (25 * 2), ano.Height);
            ano.Location = new Point(25, 25 + (25 + ano.Height) * 2);
            ano.label.Text = "Ano";
            this.Controls.Add(ano);

            InputBox quantRodas = new InputBox();
            quantRodas.Size = new Size(this.Width / 2 - (25 * 2), quantRodas.Height);
            quantRodas.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantRodas.Height) * 2);
            quantRodas.label.Text = "quantRodas";
            this.Controls.Add(quantRodas);

            InputBox valorDia = new InputBox();
            valorDia.Size = new Size(this.Width / 2 - (25 * 2), valorDia.Height);
            valorDia.Location = new Point(25, 25 + (25 + valorDia.Height) * 3);
            valorDia.label.Text = "valorDia";
            this.Controls.Add(valorDia);

            InputBox quantDoors = new InputBox();
            quantDoors.Size = new Size(this.Width / 2 - (25 * 2), quantDoors.Height);
            quantDoors.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantDoors.Height) * 3);
            quantDoors.label.Text = "quantDoors";
            this.Controls.Add(quantDoors);

            InputBox isManual = new InputBox();
            isManual.Size = new Size(this.Width / 2 - (25 * 2), isManual.Height);
            isManual.Location = new Point(25, 25 + (25 + isManual.Height) * 4);
            isManual.label.Text = "isManual";
            this.Controls.Add(isManual);

            if (id != -1)
            {
                marca.textBox.Text = carro.Marca;
                modelo.textBox.Text = carro.Modelo;
                cor.textBox.Text = carro.Cor;
                matricula.textBox.Text = carro.Matricula;
                ano.textBox.Text = carro.Ano.ToString();
                quantRodas.textBox.Text = carro.QuantRodas.ToString();
                valorDia.textBox.Text = carro.ValorDia.ToString();
                quantDoors.textBox.Text = carro.QuantDoors.ToString();
                isManual.textBox.Text = carro.IsManual.ToString();
            }


            FlatButton Submit = new FlatButton();
            Submit.Text = "Submit";
            Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.light;
            void submitClick(object sender, EventArgs e)
            {
                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    carro.Id = 500; //to calculate
                    carro.Marca = marca.textBox.Text;
                    carro.Modelo = modelo.textBox.Text;
                    carro.Cor = cor.textBox.Text;
                    carro.Matricula = matricula.textBox.Text;
                    carro.Ano = Int32.Parse(ano.textBox.Text);
                    carro.QuantRodas = Int32.Parse(quantRodas.textBox.Text);
                    carro.ValorDia = Int32.Parse(valorDia.textBox.Text);
                    carro.QuantDoors = Int32.Parse(quantDoors.textBox.Text);
                    carro.IsManual = Boolean.Parse(isManual.textBox.Text);
                    Empresa.AddCarro(carro);
                }
                else
                {
                    //find obj and edit
                }
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Submit.Click += submitClick;
            this.Controls.Add(Submit);

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
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
            this.Controls.Add(Cancel);

            this.BringToFront();
        }
    }
}
