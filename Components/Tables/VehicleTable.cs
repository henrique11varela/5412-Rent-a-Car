using Rent_a_Car.Classes;
using Rent_a_Car.Components.Details;
using Rent_a_Car.Components.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Tables
{
    /// <summary>
    /// A DataGridView Element that shows a vehicle list
    /// </summary>
    internal class VehicleTable : DataGridView
    {
        private int[] _margin = { 0, 0, 0, 0 };

        public VehicleTable()
        {
            this.ParentChanged += Setup;
            this.CellContentClick += onCellClick;

            //grid and cells stylling
            this.BackgroundColor = ts.light;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            this.ColumnCount = 9;

            int col = 0;
            this.Columns[col++].Name = "Id";
            this.Columns[col++].Name = "Marca";
            this.Columns[col++].Name = "Modelo";
            //this.Columns[col++].Name = "Cor";
            //this.Columns[col++].Name = "Q Rodas";
            this.Columns[col++].Name = "Matricula";
            this.Columns[col++].Name = "Ano";
            this.Columns[col++].Name = "Status";
            this.Columns[col++].Name = "FreeExpect";
            this.Columns[col++].Name = "ValorDia";
            this.Columns[col++].Name = "Type";
            //Details button column
            this.Columns.Add(new DataGridViewButtonColumn());
            this.Columns[col++].HeaderText = "Details";
            //Edit button column
            this.Columns.Add(new DataGridViewButtonColumn());
            this.Columns[col++].HeaderText = "Edit";
            //Delete button column
            this.Columns.Add(new DataGridViewButtonColumn());
            this.Columns[col].HeaderText = "Delete";


            int colCount = this.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                this.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.Columns[this.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.Columns[this.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.Columns[0].Visible = false;
        }

        public VehicleTable(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
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

            #region Preset setup
            this.BringToFront();
            #endregion
        }

        private void onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            int idClicked = Int32.Parse(this.Rows[e.RowIndex].Cells[0].Value.ToString());
            string clickedVehicleType = this.Rows[e.RowIndex].Cells[8].Value.ToString();

            var clickedCarro = new Carro();
            var clickedMota = new Mota();
            var clickedCamiao = new Camiao();
            var clickedCamioneta = new Camioneta();

            if (clickedVehicleType == "Carro")
            {
                foreach (Carro vehicle in Emp.CarrosList)
                {
                    if (idClicked == vehicle.Id)
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
                    if (idClicked == vehicle.Id)
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
                    if (idClicked == vehicle.Id)
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
                    if (idClicked == vehicle.Id)
                    {
                        clickedCamioneta = vehicle;
                        break;
                    }
                }
            }

            if (e.ColumnIndex == this.ColumnCount - 3)
            {
                if (clickedVehicleType == "Carro")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CarroDetails(clickedCarro));
                }
                else if (clickedVehicleType == "Mota")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new MotaDetails(clickedMota));
                }
                else if (clickedVehicleType == "Camiao")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CamiaoDetails(clickedCamiao));
                }
                else if (clickedVehicleType == "Camioneta")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CamionetaDetails(clickedCamioneta));
                }
            }
            else if (e.ColumnIndex == this.ColumnCount - 2)
            {
                if (clickedVehicleType == "Carro")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CarroForm(clickedCarro));
                }
                else if (clickedVehicleType == "Mota")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new MotaForm(clickedMota));
                }
                else if (clickedVehicleType == "Camiao")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CamiaoForm(clickedCamiao));
                }
                else if (clickedVehicleType == "Camioneta")
                {
                    Emp.ConvertObj(this.Parent).vehicleControls.Controls.Add(new CamionetaForm(clickedCamioneta));
                }


            }
            else if (e.ColumnIndex == this.ColumnCount - 1)
            {
                if (clickedVehicleType == "Carro")
                {
                    int length = Emp.CarrosList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Carro c = Emp.ConvertObj(Emp.CarrosList[i]);
                        if (c.Id == idClicked)
                        {
                            Emp.RemoveCarro(c);
                            break;
                        }
                    }
                    DAL.DAL.storeCarro();
                    this.FillData(Emp.VehicleList);
                }
                else if (clickedVehicleType == "Mota")
                {
                    int length = Emp.MotasList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Mota m = Emp.ConvertObj(Emp.MotasList[i]);
                        if (m.Id == idClicked)
                        {
                            Emp.RemoveMota(m);
                            break;
                        }
                    }
                    DAL.DAL.storeMota();
                    this.FillData(Emp.VehicleList);
                }
                else if (clickedVehicleType == "Camiao")
                {
                    int length = Emp.CamioesList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Camiao c = Emp.ConvertObj(Emp.CamioesList[i]);
                        if (c.Id == idClicked)
                        {
                            Emp.RemoveCamiao(c);
                            break;
                        }
                    }
                    DAL.DAL.storeCamiao();
                    this.FillData(Emp.VehicleList);
                }
                else if (clickedVehicleType == "Camioneta")
                {
                    int length = Emp.CamionetasList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Camioneta c = Emp.ConvertObj(Emp.CamionetasList[i]);
                        if (c.Id == idClicked)
                        {
                            Emp.RemoveCamioneta(c);
                            break;
                        }
                    }
                    DAL.DAL.storeCamioneta();
                    this.FillData(Emp.VehicleList);
                }
            }
        }

        /// <summary>
        /// Fills the DataGridView with the info of the list.
        /// It expects a Vehicle List
        /// </summary>
        /// <param name="list"></param>
        public void FillData(ArrayList list)
        {
            this.Rows.Clear();
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                var convertedItem = Emp.ConvertObj(list[i]);
                this.Rows.Add(convertedItem.Id, convertedItem.Marca, convertedItem.Modelo, convertedItem.Matricula, convertedItem.Ano, convertedItem.Status, convertedItem.FreeExpect.Date.ToShortDateString(), convertedItem.ValorDia, convertedItem.GetType().Name,"Details", "Edit", "Delete");
            }
        }
    }
}
