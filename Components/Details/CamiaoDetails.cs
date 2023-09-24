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
using Rent_a_Car.Components.Menus;
using Rent_a_Car.Components.Forms;

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

            DetailBox marca = new DetailBox();
            marca.label.Text = "Marca";
            marca.textBox.Text = camiao.Marca;
            this.Controls.Add(marca);
            marca.Size = new Size(this.Width / 2 - (25 * 2), marca.Height);
            marca.Location = new Point(25, 25);

            DetailBox modelo = new DetailBox();
            modelo.label.Text = "Modelo";
            modelo.textBox.Text = camiao.Modelo;
            this.Controls.Add(modelo);
            modelo.Size = new Size(this.Width / 2 - (25 * 2), modelo.Height);
            modelo.Location = new Point(this.Width / 2 + 25, 25);

            DetailBox cor = new DetailBox();
            cor.label.Text = "Cor";
            cor.textBox.Text = camiao.Cor;
            this.Controls.Add(cor);
            cor.Size = new Size(this.Width / 2 - (25 * 2), cor.Height);
            cor.Location = new Point(25, 25 + (25 + cor.Height) * 1);

            DetailBox matricula = new DetailBox();
            matricula.label.Text = "Matrícula";
            matricula.textBox.Text = camiao.Matricula.ToString();
            this.Controls.Add(matricula);
            matricula.Size = new Size(this.Width / 2 - (25 * 2), matricula.Height);
            matricula.Location = new Point(this.Width / 2 + 25, 25 + (25 + matricula.Height) * 1);

            DetailBox ano = new DetailBox();
            ano.label.Text = "Ano";
            ano.textBox.Text = camiao.Ano.ToString();
            this.Controls.Add(ano);
            ano.Size = new Size(this.Width / 2 - (25 * 2), ano.Height);
            ano.Location = new Point(25, 25 + (25 + ano.Height) * 2);

            DetailBox quantRodas = new DetailBox();
            quantRodas.label.Text = "Quantidade de Rodas";
            quantRodas.textBox.Text = camiao.QuantRodas.ToString();
            this.Controls.Add(quantRodas);
            quantRodas.Size = new Size(this.Width / 2 - (25 * 2), quantRodas.Height);
            quantRodas.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantRodas.Height) * 2);

            DetailBox valorDia = new DetailBox();
            valorDia.label.Text = "Valor Dia";
            valorDia.textBox.Text = camiao.ValorDia.ToString();
            this.Controls.Add(valorDia);
            valorDia.Size = new Size(this.Width / 2 - (25 * 2), valorDia.Height);
            valorDia.Location = new Point(25, 25 + (25 + valorDia.Height) * 3);

            DetailBox maxWeight = new DetailBox();
            maxWeight.label.Text = "Peso Máximo";
            maxWeight.textBox.Text = camiao.MaxWeight.ToString();
            this.Controls.Add(maxWeight);
            maxWeight.Size = new Size(this.Width / 2 - (25 * 2), maxWeight.Height);
            maxWeight.Location = new Point(this.Width / 2 + 25, 25 + (25 + maxWeight.Height) * 3);


            //Reservar Button
            FlatButton Reservar = new FlatButton();
            Reservar.Text = "Reservar";
            Reservar.Image = Image.FromFile("C:\\Users\\berna\\Documents\\ATEC\\Módulos\\Atec-modulos\\C#\\5412_Rent-a-Car\\5412-Rent-a-Car\\assets\\icons\\reserva.png");
            Reservar.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Reservar);

            //size/location before
            //Reservar.Location = new Point(25, this.Height - Reservar.Height - 25);
            //Reservar.Size = new Size(this.Width / 2 - 2 * 25, Reservar.Height);

            //size/location after
            Reservar.Location = new Point(this.Width / 2 - this.Width / 4, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            Reservar.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            Reservar.BGC = ts.white;
            Reservar.BGC_HOVER = ts.dark_emphasis;
            Reservar.ForeColor = ts.dark;
            void reservarClick(object sender, EventArgs e)
            {
                if (camiao.Status != "Free")
                {
                    MessageBox.Show($"Este Camião está com o estado {camiao.Status}");
                    return;
                }
                Reservado reserva = new Reservado(id, "Camiao", -1);
                var parent = this.Parent;
                parent.Controls.Add(new ClienteSelectTable(reserva));
                parent.Controls.Remove(this);
            }
            Reservar.Click += reservarClick;

            //Alugar Button
            FlatButton Alugar = new FlatButton();
            Alugar.Text = "Alugar";
            Alugar.Image = Image.FromFile("C:\\Users\\berna\\Documents\\ATEC\\Módulos\\Atec-modulos\\C#\\5412_Rent-a-Car\\5412-Rent-a-Car\\assets\\icons\\aluguer.png");
            Alugar.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Alugar);
            //size/location before
            //Alugar.Location = new Point(25, this.Height - Alugar.Height * 2 - 25 * 2);
            //Alugar.Size = new Size(this.Width / 2 - 2 * 25, Alugar.Height);

            //size/location after
            Alugar.Location = new Point(this.Width / 2 - this.Width / 4, this.Height / 2 + 25);
            Alugar.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);



            Alugar.BGC = Color.White;
            Alugar.BGC_HOVER = ts.dark_emphasis;
            Alugar.ForeColor = ts.dark;
            //Alugar.Image = 
            void alugarClick(object sender, EventArgs e)
            {
                if (camiao.Status != "Free" && camiao.Status != "Reservado")
                {
                    MessageBox.Show($"Este Camião está com o estado {camiao.Status}");
                    return;
                }
                VehicleControls controls = Emp.ConvertObj(this.Parent);
                Alugado alugado = new Alugado(id, "Camiao", controls.StartCalendar.SelectionStart, controls.EndCalendar.SelectionStart, -1);
                var parent = this.Parent;
                parent.Controls.Add(new ClienteSelectTable(alugado));
                parent.Controls.Remove(this);
            }
            Alugar.Click += alugarClick;

            //Manutencao Button
            FlatButton Manutencao = new FlatButton();
            Manutencao.Text = "Manutencao";
            Manutencao.ForeColor = ts.dark;
            Manutencao.TextAlign = ContentAlignment.BottomCenter;
            Manutencao.Image = Image.FromFile("C:\\Users\\berna\\Documents\\ATEC\\Módulos\\Atec-modulos\\C#\\5412_Rent-a-Car\\5412-Rent-a-Car\\assets\\icons\\manutencao.png");
            this.Controls.Add(Manutencao);
            //size/location before
            //Manutencao.Location = new Point(this.Width / 2 + 25, this.Height - Manutencao.Height * 2 - 25 * 2);
            //Manutencao.Size = new Size(this.Width / 2 - 2 * 25, Manutencao.Height);

            Manutencao.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);
            Manutencao.Location = new Point(this.Width - this.Width / 2 + 25, this.Height / 2 + 25);
            Manutencao.BGC = ts.white;
            Manutencao.BGC_HOVER = ts.dark_emphasis;
            void manutencaoClick(object sender, EventArgs e)
            {
                if (camiao.Status != "Free")
                {
                    MessageBox.Show($"Este Camião está com o estado {camiao.Status}");  
                    return;
                }
                VehicleControls controls = Emp.ConvertObj(this.Parent);
                Manutencao manutencao = new Manutencao(id, "Camiao", controls.StartCalendar.SelectionStart, controls.EndCalendar.SelectionStart, "");
                var parent = this.Parent;
                parent.Controls.Add(new ManutencaoForm(manutencao));
                parent.Controls.Remove(this);
            }
            Manutencao.Click += manutencaoClick;

            //Cancel Button
            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
            Cancel.Image = Image.FromFile("C:\\Users\\berna\\Documents\\ATEC\\Módulos\\Atec-modulos\\C#\\5412_Rent-a-Car\\5412-Rent-a-Car\\assets\\icons\\cancelar.png");
            Cancel.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Cancel);

            //size/location before
            Cancel.Location = new Point(this.Width - this.Width / 2 + 25, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            Cancel.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            //size/location after
            Cancel.BGC = ts.white;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.dark;
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

