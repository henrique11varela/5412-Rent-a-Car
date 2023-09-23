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
    internal class AlugadoDetails : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Alugado alugado = new Alugado(-1, "", DateTime.Now, DateTime.Now, -1);

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public AlugadoDetails()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public AlugadoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public AlugadoDetails(Alugado c) : this()
        {
            alugado = c;
        }

        public AlugadoDetails(int margin_top, int margin_right, int margin_bottom, int margin_left, Alugado c) : this(c)
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




            DetailBox vehicleID = new DetailBox();
            vehicleID.label.Text = "ID Veiculo";
            vehicleID.textBox.Text = alugado.IdVeiculo.ToString();
            this.Controls.Add(vehicleID);
            vehicleID.Size = new Size(this.Width / 2 - (25 * 2), vehicleID.Height);
            vehicleID.Location = new Point(25, 25);

            DetailBox vehicleType = new DetailBox();
            vehicleType.label.Text = "Tipo de Veiculo";
            vehicleType.textBox.Text = alugado.TipoVeiculo;
            this.Controls.Add(vehicleType);
            vehicleType.Size = new Size(this.Width / 2 - (25 * 2), vehicleType.Height);
            vehicleType.Location = new Point(this.Width / 2 + 25, 25);

            DetailBox client = new DetailBox();
            client.label.Text = "ID Cliente";
            client.textBox.Text = alugado.IdCliente.ToString();
            this.Controls.Add(client);
            client.Size = new Size(this.Width / 2 - (25 * 2), client.Height);
            client.Location = new Point(25, 25 + (25 + client.Height) * 1);

            DetailBox startDate = new DetailBox();
            startDate.label.Text = "Data Inicio";
            startDate.textBox.Text = alugado.DataInicio.ToString();
            this.Controls.Add(startDate);
            startDate.Size = new Size(this.Width / 2 - (25 * 2), startDate.Height);
            startDate.Location = new Point(25, 25 + (25 + startDate.Height) * 2);

            DetailBox endDate = new DetailBox();
            endDate.label.Text = "Data Fim";
            endDate.textBox.Text = alugado.DataInicio.ToString();
            this.Controls.Add(endDate);
            endDate.Size = new Size(this.Width / 2 - (25 * 2), endDate.Height);
            endDate.Location = new Point(this.Width / 2 + 25, 25 + (25 + endDate.Height) * 2);



            //Terminar Button
            FlatButton Terminar = new FlatButton();
            Terminar.Text = "Terminar Aluguer";
            this.Controls.Add(Terminar);
            Terminar.Location = new Point(25, this.Height - Terminar.Height - 25);
            Terminar.Size = new Size(this.Width / 2 - 2 * 25, Terminar.Height);
            Terminar.BGC = ts.dark;
            Terminar.BGC_HOVER = ts.dark_emphasis;
            Terminar.ForeColor = ts.light;
            void terminarClick(object sender, EventArgs e)
            {
                var parent = this.Parent;
                parent.Controls.Add(new AlugadoValorForm(alugado));
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

