using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTable = Rent_a_Car.Components.Tables.VehicleTable;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;

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
            



            ///label creation and styling
            Label pageTitle = new Label();
            pageTitle.Text = "List of Vehicles";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(view.Width, pageTitle.Font.Height); ;
            pageTitle.Location = new Point(0, pageTitle.Font.Height);
            view.Controls.Add(pageTitle);

            //Insert Table
            int[] cols = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var vehicleTable = VehicleTable.Setup(view, pageTitle.Font.Height * 3, 25, 25, 25, cols);
            VehicleTable.FillData(vehicleTable, Emp.VehicleList);

            ///button with label
            Color bgc = ts.dark_emphasis;
            Color bgcHover = ts.dark;

            Button newVehicle = new Button();
            newVehicle.Location = new Point(550, (pageTitle.Font.Height * 3 - ts.mediumFont.Height * 2) / 2);
            newVehicle.Size = new Size(150, ts.mediumFont.Height * 2);
            newVehicle.Name = "newVehicle";
            newVehicle.Text = "Add Vehicle |  +  ";
            newVehicle.TextAlign = ContentAlignment.MiddleCenter;
            newVehicle.Font = ts.mediumFont;
            newVehicle.FlatStyle = FlatStyle.Flat;
            newVehicle.FlatAppearance.BorderSize = 0;
            newVehicle.BackColor = bgc;
            void newVehicleEnter(object sender, EventArgs e)
            {
                newVehicle.BackColor = bgcHover;
            }
            void newVehicleLeave(object sender, EventArgs e)
            {
                newVehicle.BackColor = bgc;
            }
            void newVehicleClick(object sender, EventArgs e)
            {
                newVehicle.BackColor = bgc;
                Empresa.AddCarro(new Carro()); ;
                VehicleTable.FillData(vehicleTable, Emp.VehicleList);
            }
            newVehicle.Click += newVehicleClick;
            newVehicle.Enter += newVehicleEnter;
            newVehicle.Leave += newVehicleLeave;
            view.Controls.Add(newVehicle);
            newVehicle.BringToFront();


        }
    }
}
