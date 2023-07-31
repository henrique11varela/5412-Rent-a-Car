using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emp = Rent_a_Car.Classes.Empresa;

namespace Rent_a_Car.Components.Tables
{
    internal static class VehicleTable
    {
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

        public static void FillData(DataGridView dgv, ArrayList list)
        {
            dgv.Rows.Clear();
            foreach (var item in list)
            {
                var convertedItem = Emp.ConvertObj(item);
                dgv.Rows.Add(convertedItem.Id, convertedItem.Marca, convertedItem.Modelo, convertedItem.Cor, convertedItem.QuantRodas, convertedItem.Matricula, convertedItem.Ano, convertedItem.Status, convertedItem.FreeExpect, convertedItem.ValorDia, convertedItem.GetType().Name);
            }
        }
    }
}
