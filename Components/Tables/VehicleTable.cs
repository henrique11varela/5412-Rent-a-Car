using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Tables
{
    internal static class VehicleTable
    {
        #region WIP
        public static DataGridView Setup(Panel view, int margin_top, int margin_right, int margin_bottom, int margin_left)
        {
            int[] cols = new int[0];
            return Setup(view, margin_top, margin_right, margin_bottom, margin_left, cols);
        }

        public static DataGridView Setup(Panel view, int margin_top, int margin_right, int margin_bottom, int margin_left, int[] cols)
        {
            //Constants

            ///daratgridview and respective cells creation
            DataGridView dgv = new DataGridView();
            dgv.CellContentClick += onCellClick;

            //grid and cells stylling
            dgv.Location = new Point(margin_left, margin_top);
            dgv.Size = new Size(view.Width - margin_right - margin_left, view.Height - margin_top - margin_bottom);
            dgv.BackgroundColor = Color.White;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            dgv.ColumnCount = 11;

            dgv.Columns[0].Name = "Id";
            dgv.Columns[1].Name = "Marca";
            dgv.Columns[2].Name = "Modelo";
            dgv.Columns[3].Name = "Cor";
            dgv.Columns[4].Name = "Q Rodas";
            dgv.Columns[5].Name = "Matricula";
            dgv.Columns[6].Name = "Ano";
            dgv.Columns[7].Name = "Status";
            dgv.Columns[8].Name = "FreeExpect";
            dgv.Columns[9].Name = "ValorDia";
            dgv.Columns[10].Name = "Type";
            //Edit button column
            dgv.Columns.Add(new DataGridViewButtonColumn());
            dgv.Columns[11].HeaderText = "Edit";
            //Delete button column
            dgv.Columns.Add(new DataGridViewButtonColumn());
            dgv.Columns[12].HeaderText = "Delete";



            int colCount = dgv.Columns.Count;
            for (int i = 0; i < colCount; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgv.Columns[dgv.ColumnCount - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[dgv.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            if (cols.Length > 0)
            {
                int length = dgv.ColumnCount;
                for (int i = 0; i < length; i++)
                {
                    dgv.Columns[i].Visible = false;
                }
                foreach (var col in cols)
                {
                    dgv.Columns[col].Visible = true;
                }
            }

            view.Controls.Add(dgv);
            return dgv;
        }
        #endregion

        #region todel
        public static Panel Setup2(Panel view, int margin_top, int margin_right, int margin_bottom, int margin_left, int[] cols)
        {
            Font font = ts.mediumFont;
            Panel table = new Panel();
            //grid and cells stylling
            table.AutoScroll = true;
            table.Location = new Point(margin_left, margin_top);
            table.Size = new Size(view.Width - margin_right - margin_left, view.Height - margin_top - margin_bottom);
            table.BackColor = ts.success_emphasis;

            for (int i = 0; i < Emp.VehicleList.Count; i++)
            {
                Panel line = new Panel();
                line.Location = new Point(0, i * font.Height + 6);
                line.Size = new Size(table.Width, font.Height + 6);
                line.BackColor = ts.success;
                line.BorderStyle = BorderStyle.FixedSingle;
                //dgv.Columns[0].Name = "Id";
                //dgv.Columns[1].Name = "Marca";
                //dgv.Columns[2].Name = "Modelo";
                //dgv.Columns[3].Name = "Cor";
                //dgv.Columns[4].Name = "Q Rodas";
                //dgv.Columns[5].Name = "Matricula";
                //dgv.Columns[6].Name = "Ano";
                //dgv.Columns[7].Name = "Status";
                //dgv.Columns[8].Name = "FreeExpect";
                //dgv.Columns[9].Name = "ValorDia";
                //dgv.Columns[10].Name = "Type";
                List<Label> cells = new List<Label>();
                Label lbl = new Label();
                table.Controls.Add(line);
            }

            view.Controls.Add(table);
            return table;
        }
        #endregion



        private static void onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                MessageBox.Show("Edit Logic");
            }
            else if (e.ColumnIndex == 12)
            {
                MessageBox.Show("Delete Logic");
            }
        }

        public static void FillData(DataGridView dgv, ArrayList list)
        {
            Panel test = new Panel();
            test.Size = new Size(5, 5);
            test.BackColor = ts.danger;

            dgv.Rows.Clear();
            int quantCells = dgv.Rows[0].Cells.Count;
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                var convertedItem = Emp.ConvertObj(list[i]);
                dgv.Rows.Add(convertedItem.Id, convertedItem.Marca, convertedItem.Modelo, convertedItem.Cor, convertedItem.QuantRodas, convertedItem.Matricula, convertedItem.Ano, convertedItem.Status, convertedItem.FreeExpect, convertedItem.ValorDia, convertedItem.GetType().Name, "Edit", "Delete");
            }
        }
    }
}
