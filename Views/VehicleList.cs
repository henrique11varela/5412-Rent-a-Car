using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTable = Rent_a_Car.Components.Tables.VehicleTable;
using CarForm = Rent_a_Car.Components.Forms.CarForm;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components;
using Rent_a_Car.Components.Buttons;

namespace Rent_a_Car.Views
{
    internal class VehicleList
    {
        /// <summary>Adds elements to view[0].</summary>
        public static void Setup(Button tab, Panel view)
        {
            string title = "Vehicle List";

            //Name
            tab.Text = title;

            ///label creation and styling
            Label pageTitle = new Label();
            pageTitle.Text = title;
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height);
            pageTitle.Location = new Point((view.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            view.Controls.Add(pageTitle);

            //Insert Table
            int[] cols = { 1, 2, 6, 7, 8, 9, 10, 11, 12 };
            var vehicleTable = VehicleTable.Setup(view, pageTitle.Font.Height * 3, view.Width / 2 + 25, 25, 25, cols);
            VehicleTable.FillData(vehicleTable, Emp.VehicleList);

            var carForm = CarForm.Setup(view, pageTitle.Font.Height * 3, 25, 25, view.Width / 2 + 25);

            ///button with label
            var placeholder = new FlatButton();
            void newVehicleClick(object sender, EventArgs e)
            {
                Empresa.AddCarro(new Carro()); ;
                VehicleTable.FillData(vehicleTable, Emp.VehicleList);
                carForm.Show();
            }
            placeholder.Click += newVehicleClick;
            view.Controls.Add(placeholder);
            //placeholder.BringToFront();
        }
    }
}
