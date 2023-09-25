using Rent_a_Car.Classes;
using Rent_a_Car.Components.Details;
using Rent_a_Car.Components.Forms;
using Rent_a_Car.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Schema;
using Timer = System.Windows.Forms.Timer;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rent_a_Car.Components.Tables
{
    /// <summary>
    /// A DataGridView Element that shows a vehicle list
    /// </summary>
    internal class ClienteSelectTable : DataGridView
    {
        private Reservado reserva = null;
        private Alugado alugado = null;
        private int[] _margin = { 0, 0, 0, 0 };

        public ClienteSelectTable()
        {
            this.ParentChanged += Setup;
            this.CellContentClick += onCellClick;

            //grid and cells stylling
            this.BackgroundColor = ts.light;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            this.ColumnCount = 3;

            int col = 0;
            this.Columns[col++].Name = "Id";
            this.Columns[col++].Name = "Nome";
            this.Columns[col++].Name = "Contacto";

            //Select button column
            this.Columns.Add(new DataGridViewButtonColumn());
            this.Columns[col].HeaderText = "Select";


            int colCount = this.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.Columns[this.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public ClienteSelectTable(Reservado reserva) : this()
        {
            this.reserva = reserva;
        }

        public ClienteSelectTable(Alugado alugado) : this()
        {
            this.alugado = alugado;
        }

        public ClienteSelectTable(int margin_top, int margin_right, int margin_bottom, int margin_left, Reservado reserva) : this(reserva)
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        public ClienteSelectTable(int margin_top, int margin_right, int margin_bottom, int margin_left, Alugado alugado) : this(alugado)
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

            this.FillData(Emp.ClienteList);

            #region Preset setup
            this.BringToFront();
            #endregion
        }

        private void onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            dynamic acontecimento;

            if (reserva != null)
            {
                acontecimento = reserva;
            }
            else
            {
                acontecimento = alugado;
            }

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int idClicked = Int32.Parse(this.Rows[e.RowIndex].Cells[0].Value.ToString());

            string clickedVehicleType = acontecimento.TipoVeiculo;

            var clickedCarro = new Carro();
            var clickedMota = new Mota();
            var clickedCamiao = new Camiao();
            var clickedCamioneta = new Camioneta();

            if (clickedVehicleType == "Carro")
            {
                foreach (Carro vehicle in Emp.CarrosList)
                {
                    if (acontecimento.IdVeiculo == vehicle.Id)
                    {
                        clickedCarro = vehicle;
                        break;
                    }
                }
            }
            else if (clickedVehicleType == "Mota")
            {
                foreach (Mota vehicle in Emp.MotasList)
                {
                    if (acontecimento.IdVeiculo == vehicle.Id)
                    {
                        clickedMota = vehicle;
                        break;
                    }
                }
            }
            else if (clickedVehicleType == "Camiao")
            {
                foreach (Camiao vehicle in Emp.CamioesList)
                {
                    if (acontecimento.IdVeiculo == vehicle.Id)
                    {
                        clickedCamiao = vehicle;
                        break;
                    }
                }
            }
            else if (clickedVehicleType == "Camioneta")
            {
                foreach (Camioneta vehicle in Emp.CamionetasList)
                {
                    if (acontecimento.IdVeiculo == vehicle.Id)
                    {
                        clickedCamioneta = vehicle;
                        break;
                    }
                }
            }

            var clickedCliente = new Cliente();
            foreach (Cliente cliente in Emp.ClienteList)
            {
                if (idClicked == cliente.Id)
                {
                    clickedCliente = cliente;
                    break;
                }
            }


            if (e.ColumnIndex == this.ColumnCount - 1)
            {
                DialogResult dialogResult = DialogResult.No;
                if (reserva != null)
                {
                    if (clickedVehicleType == "Carro")
                    {
                        dialogResult = MessageBox.Show($"Reservar o carro {clickedCarro.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Mota")
                    {
                        dialogResult = MessageBox.Show($"Reservar a mota {clickedMota.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Camiao")
                    {
                        dialogResult = MessageBox.Show($"Reservar o camiao {clickedCamiao.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Camioneta")
                    {
                        dialogResult = MessageBox.Show($"Reservar a camioneta {clickedCamioneta.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                }
                else
                {
                    if (clickedVehicleType == "Carro")
                    {
                        dialogResult = MessageBox.Show($"Alugar o carro {clickedCarro.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Mota")
                    {
                        dialogResult = MessageBox.Show($"Alugar a mota {clickedMota.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Camiao")
                    {
                        dialogResult = MessageBox.Show($"Alugar o camiao {clickedCamiao.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                    else if (clickedVehicleType == "Camioneta")
                    {
                        dialogResult = MessageBox.Show($"Alugar a camioneta {clickedCamioneta.Matricula} para o cliente {clickedCliente.Nome}?", "Exit", MessageBoxButtons.YesNo);
                    }
                }

                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                if (reserva != null)
                {
                    reserva.IdCliente = idClicked;
                    Emp.AddReservado(reserva);
                    Emp.reservadoTable.FillData(Emp.ReservadoList);
                    DAL.DAL.storeReservado();
                    DAL.DAL.convertReservado();
                    Emp.vehicleTable.FillData(Emp.VehicleList);
                }
                else
                {
                    int length = Emp.ReservadoList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Reservado reservaTemp = Emp.ConvertObj(Emp.ReservadoList[i]);
                        if (reservaTemp.IdVeiculo == acontecimento.IdVeiculo && reservaTemp.IdCliente == idClicked && reservaTemp.TipoVeiculo == acontecimento.TipoVeiculo)
                        {
                            Emp.RemoveReservado(reservaTemp);
                            Emp.reservadoTable.FillData(Emp.ReservadoList);
                            DAL.DAL.storeReservado();
                            DAL.DAL.convertReservado();
                        }
                        else if (reservaTemp.IdVeiculo == acontecimento.IdVeiculo && reservaTemp.IdCliente != idClicked && reservaTemp.TipoVeiculo == acontecimento.TipoVeiculo)
                        {
                            MessageBox.Show("Veiculo reservado para outro cliente.");
                            this.Parent.Controls.Remove(this);
                            return;
                        }
                    }
                    alugado.IdCliente = idClicked;
                    Emp.AddAlugado(alugado);
                    Emp.alugadoTable.FillData(Emp.AlugadoList);
                    DAL.DAL.storeAlugado();
                    DAL.DAL.convertAlugado();
                    Emp.vehicleTable.FillData(Emp.VehicleList);
                }


                this.Parent.Controls.Remove(this);
            }
        }

        /// <summary>
        /// Fills the DataGridView with the info of the list.
        /// It expects a Vehicle List
        /// </summary>
        /// <param name="list"></param>
        public void FillData(ArrayList list, int days = 0)
        {
            this.Rows.Clear();
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                var convertedItem = Emp.ConvertObj(list[i]);
                this.Rows.Add(convertedItem.Id, convertedItem.Nome, convertedItem.Contacto, "Select");
            }
        }
    }
}
