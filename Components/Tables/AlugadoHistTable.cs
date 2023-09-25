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

namespace Rent_a_Car.Components.Tables
{
    /// <summary>
    /// A DataGridView Element that shows a vehicle list
    /// </summary>
    internal class AlugadoHistTable : DataGridView
    {
        private int[] _margin = { 0, 0, 0, 0 };

        public AlugadoHistTable()
        {
            Emp.alugadoHistTable = this;

            this.ParentChanged += Setup;
            this.CellContentClick += onCellClick;

            //grid and cells stylling
            this.BackgroundColor = ts.light;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            this.ColumnCount = 7;

            int col = 0;
            this.Columns[col++].Name = "Id";
            this.Columns[col++].Name = "Carro";
            this.Columns[col++].Name = "Tipo Carro";
            this.Columns[col++].Name = "Data Inicio";
            this.Columns[col++].Name = "Data Prevista Fim";
            this.Columns[col++].Name = "Cliente";
            this.Columns[col++].Name = "Valor";

            //Details button column
            this.Columns.Add(new DataGridViewButtonColumn());
            this.Columns[col].HeaderText = "Detalhes";
            this.Columns[0].Visible = false;

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

        public AlugadoHistTable(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
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
            string tipoClicked = this.Rows[e.RowIndex].Cells[2].Value.ToString();

            AlugadoHist clickedAlugado = new AlugadoHist(-1, "", DateTime.Now, DateTime.Now, -1, -1);

            int length = Emp.AlugadoHistList.Count;
            for (int i = 0; i < length; i++)
            {
                AlugadoHist r = Emp.ConvertObj(Emp.AlugadoHistList[i]);
                if (r.IdVeiculo == idClicked && r.TipoVeiculo == tipoClicked)
                {

                    clickedAlugado = r;
                    break;
                }
            }
            if (clickedAlugado.IdVeiculo == -1)
            {
                return;
            }

            //Details
            if (e.ColumnIndex == this.ColumnCount - 1)
            {
                MessageBox.Show("details alugado hist");
                //Emp.stateListControls.Controls.Add(new AlugadoDetails(clickedAlugado));
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
                string matricula = "";
                foreach (var veiculo in Emp.VehicleList)
                {
                    var v = Emp.ConvertObj(veiculo);
                    if (v.Id == convertedItem.IdVeiculo && v.GetType().Name == convertedItem.TipoVeiculo)
                    {
                        matricula = v.Matricula;
                        break;
                    }
                }
                string nome = "";
                foreach (var cliente in Emp.ClienteList)
                {
                    Cliente c = Emp.ConvertObj(cliente);
                    if (c.Id == convertedItem.IdCliente)
                    {
                        nome = c.Nome;
                        break;
                    }
                }
                this.Rows.Add(convertedItem.IdVeiculo, matricula, convertedItem.TipoVeiculo, convertedItem.DataInicio.Date.ToShortDateString(), convertedItem.DataFim.Date.ToShortDateString(), nome, convertedItem.Valor, "Detalhes");
            }
        }
    }
}
