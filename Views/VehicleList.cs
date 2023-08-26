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
using Rent_a_Car.Components.Forms;

namespace Rent_a_Car.Views
{
    internal class VehicleList : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        public VehicleTable vehicleTable;
        public VehicleControls vehicleControls;

        public VehicleList()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.light; 
        }

        /// <summary>
        /// Event that places element after instance is created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setup(object sender, EventArgs e)
        {
            if (this.Parent == null)
            {
                return;
            }
            this.Location = new Point(_margin[3], _margin[0]);
            this.Size = new Size(this.Parent.Width - _margin[1] - _margin[3], this.Parent.Height - _margin[0] - _margin[2]);

            Label pageTitle = new Label();
            pageTitle.Text = "Vehicle List";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height);
            pageTitle.Location = new Point((this.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            this.Controls.Add(pageTitle);

            vehicleTable = new VehicleTable(pageTitle.Font.Height * 3, this.Width / 2 + 25, 25, 25);
            vehicleTable.FillData(Emp.VehicleList);
            this.Controls.Add(vehicleTable);

            vehicleControls = new VehicleControls(pageTitle.Font.Height * 3, 25, 25, this.Width / 2 + 25);
            this.Controls.Add(vehicleControls);

            this.BringToFront();
        }
    }
}
