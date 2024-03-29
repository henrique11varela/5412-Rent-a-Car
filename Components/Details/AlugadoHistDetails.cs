﻿using System;
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
using System.Threading.Channels;

namespace Rent_a_Car.Components.Details
{
    internal class AlugadoHistDetails : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private AlugadoHist alugado = new AlugadoHist(-1, "", DateTime.Now, DateTime.Now, -1, -1);

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public AlugadoHistDetails()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public AlugadoHistDetails(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public AlugadoHistDetails(AlugadoHist c) : this()
        {
            alugado = c;
        }

        public AlugadoHistDetails(int margin_top, int margin_right, int margin_bottom, int margin_left, AlugadoHist c) : this(c)
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




            DetailBox vehicleBrand = new DetailBox();
            vehicleBrand.label.Text = "Marca Veiculo";
            this.Controls.Add(vehicleBrand);
            vehicleBrand.Size = new Size(this.Width / 2 - (25 * 2), vehicleBrand.Height);
            vehicleBrand.Location = new Point(25, 25);

            DetailBox vehicleModel = new DetailBox();
            vehicleModel.label.Text = "Modelo Veiculo";
            this.Controls.Add(vehicleModel);
            vehicleModel.Size = new Size(this.Width / 2 - (25 * 2), vehicleModel.Height);
            vehicleModel.Location = new Point(this.Width / 2 + 25, 25);

            DetailBox vehicleType = new DetailBox();
            vehicleType.label.Text = "Tipo Veiculo";
            this.Controls.Add(vehicleType);
            vehicleType.Size = new Size(this.Width / 2 - (25 * 2), vehicleType.Height);
            vehicleType.Location = new Point(25, 25 + (25 + vehicleType.Height) * 1);

            DetailBox client = new DetailBox();
            client.label.Text = "Cliente";
            this.Controls.Add(client);
            client.Size = new Size(this.Width / 2 - (25 * 2), client.Height);
            client.Location = new Point(this.Width / 2 + 25, 25 + (25 + client.Height) * 1);

            DetailBox valor = new DetailBox();
            valor.label.Text = "Valor";
            valor.textBox.Text = alugado.Valor.ToString();
            this.Controls.Add(valor);
            valor.Size = new Size(this.Width / 2 - (25 * 2), valor.Height);
            valor.Location = new Point(25, 25 + (25 + valor.Height) * 2);

            DetailBox matricula = new DetailBox();
            matricula.label.Text = "Matricula";
            this.Controls.Add(matricula);
            matricula.Size = new Size(this.Width / 2 - (25 * 2), matricula.Height);
            matricula.Location = new Point(this.Width / 2 + 25, 25 + (25 + valor.Height) * 2);

            DetailBox startDate = new DetailBox();
            startDate.label.Text = "Data Inicio";
            startDate.textBox.Text = alugado.DataInicio.ToString();
            this.Controls.Add(startDate);
            startDate.Size = new Size(this.Width / 2 - (25 * 2), startDate.Height);
            startDate.Location = new Point(25, 25 + (25 + startDate.Height) * 3);

            DetailBox endDate = new DetailBox();
            endDate.label.Text = "Data Fim";
            endDate.textBox.Text = alugado.DataFim.ToString();
            this.Controls.Add(endDate);
            endDate.Size = new Size(this.Width / 2 - (25 * 2), endDate.Height);
            endDate.Location = new Point(this.Width / 2 + 25, 25 + (25 + endDate.Height) * 3);




            if (alugado.TipoVeiculo.ToString() == "Carro")
            {
                foreach (Carro car in Emp.CarrosList)
                {
                    if (alugado.IdVeiculo == car.Id)
                    {
                        vehicleBrand.textBox.Text = car.Marca;
                        vehicleModel.textBox.Text = car.Modelo;
                        vehicleType.textBox.Text = alugado.TipoVeiculo;
                        matricula.textBox.Text = car.Matricula;
                    }
                }
            }
            else if (alugado.TipoVeiculo.ToString() == "Camiao")
            {
                foreach (Camiao camO in Emp.CamioesList)
                {
                    if (alugado.IdVeiculo == camO.Id)
                    {
                        vehicleBrand.textBox.Text = camO.Marca;
                        vehicleModel.textBox.Text = camO.Modelo;
                        vehicleType.textBox.Text = alugado.TipoVeiculo;
                        matricula.textBox.Text = camO.Matricula;
                    }
                }
            }
            else if (alugado.TipoVeiculo.ToString() == "Camioneta")
            {
                foreach (Camioneta camA in Emp.CamionetasList)
                {
                    if (alugado.IdVeiculo == camA.Id)
                    {
                        vehicleBrand.textBox.Text = camA.Marca;
                        vehicleModel.textBox.Text = camA.Modelo;
                        vehicleType.textBox.Text = alugado.TipoVeiculo;
                        matricula.textBox.Text = camA.Matricula;
                    }
                }
            }
            else if (alugado.TipoVeiculo.ToString() == "Mota")
            {
                foreach (Mota mot in Emp.MotasList)
                {
                    if (alugado.IdVeiculo == mot.Id)
                    {
                        vehicleBrand.textBox.Text = mot.Marca;
                        vehicleModel.textBox.Text = mot.Modelo;
                        vehicleType.textBox.Text = alugado.TipoVeiculo;
                        matricula.textBox.Text = mot.Matricula;
                    }
                }
            }


            foreach (Cliente cli in Emp.ClienteList)
            {
                if (alugado.IdCliente == cli.Id)
                {
                    client.textBox.Text = cli.Nome;
                }
            }

            //Cancel Button
            FlatButton Fechar = new FlatButton();
            Fechar.Text = "Fechar";
            this.Controls.Add(Fechar);
            Fechar.Location = new Point(25, this.Height - Fechar.Height - 25);
            Fechar.Size = new Size(this.Width - 2 * 25, Fechar.Height);
            Fechar.BGC = ts.dark;
            Fechar.BGC_HOVER = ts.dark_emphasis;
            Fechar.ForeColor = ts.white;
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

