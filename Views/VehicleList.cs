using Rent_a_Car.Components.Tables;
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



            ///label creation and styling
            Label pageTitle = new Label();
            pageTitle.Text = "List of Vehicles";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.AutoSize = true;
            pageTitle.Location = new Point((view.Width - pageTitle.Width) / 2, 0);   //(widthWindow - widthLabel) / 2
            pageTitle.Font = largeFont;



            //Insert Table
            VehicleTable.Setup(view, 25);





            ///button with label

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
            view.Controls.Add(newVehicle);
            view.Controls.Add(pageTitle);
        }
    }
}
