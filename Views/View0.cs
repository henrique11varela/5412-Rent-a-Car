using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridView = System.Windows.Forms.DataGridView;

namespace Rent_a_Car.Views
{
    internal class vehicleList
    {
        /// <summary>Adds elements to view[0].</summary>
        public static void Setup(Button tab, Panel view)
        {
            //Name
            tab.Text = "Vehicle List";

            //Content
            Font mediumFont = new Font("Segoe UI", 10);
            Font largeFont = new Font("Segoe UI", 16);



            ///<summary>label creation and styling</summary>
            Label pageTitle = new Label();
            pageTitle.Text = "List of Vehicles";
            pageTitle.Location = new Point(320, 40);   //(widthWindow - widthLabel) / 2
            pageTitle.Size = new Size(200, 30);
            pageTitle.Font = largeFont;




            ///<summary>daratgridview and respective cells creation</summary>
            DataGridView dgv1 = new DataGridView();

            ///<summary>grid and cells stylling</summary>
            dgv1.Location = new Point(25, 80);
            dgv1.Name = "dgv1";
            dgv1.Size = new Size(750, 350);
            dgv1.BackgroundColor = Color.White;

            //columns:
            //id, marca, modelo, matricula, status (icon), tipo, details, edit
            dgv1.ColumnCount = 8;
            dgv1.RowCount = 15;

            dgv1.Columns[0].Name = "Id";
            dgv1.Columns[1].Name = "Marca";
            dgv1.Columns[2].Name = "Modelo";
            dgv1.Columns[3].Name = "Matricula";
            dgv1.Columns[4].Name = "Status";
            dgv1.Columns[5].Name = "Type";

            dgv1.RowHeadersVisible = false;
            dgv1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;





            ///<summary>button with label</summary>

            Button newVehicle = new Button();
            newVehicle.Location = new Point(550, 40);
            newVehicle.Name = "newVehicle";
            newVehicle.Size = new Size(150, 30);
            newVehicle.Text = "Add Vehicle          |  +  ";
            newVehicle.TextAlign = ContentAlignment.MiddleLeft;
            newVehicle.Font = mediumFont;

            static void newVehicleClick(object sender, EventArgs e)
            {

            }







            //Add content to view
            view.Controls.Add(dgv1);
            view.Controls.Add(newVehicle);
            view.Controls.Add(pageTitle);
        }

        private DataGridView dgv1;
        private Button newVehicle;
    }
}
