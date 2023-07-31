using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Components.Tables
{
    internal static class VehicleTable
    {
        public static DataGridView Setup(Panel view, int margin_top, int margin_right, int margin_bottom, int margin_left) {
            //Constants

            ///daratgridview and respective cells creation
            DataGridView dgv = new DataGridView();

            //grid and cells stylling
            dgv.Location = new Point(margin_left, margin_top);
            dgv.Size = new Size(view.Width - margin_right * 2, view.Height - margin_top - margin_bottom);
            dgv.BackgroundColor = Color.White;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            dgv.ColumnCount = 8;
            dgv.RowCount = 15;

            dgv.Columns[0].Name = "Id";
            dgv.Columns[1].Name = "Marca";
            dgv.Columns[2].Name = "Modelo";
            dgv.Columns[3].Name = "Matricula";
            dgv.Columns[4].Name = "Status";
            dgv.Columns[5].Name = "Type";

            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            view.Controls.Add(dgv);
            return dgv;
        }
    }
}
