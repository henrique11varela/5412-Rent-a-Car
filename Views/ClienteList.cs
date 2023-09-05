using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTable = Rent_a_Car.Components.Tables.VehicleTable;
using CarForm = Rent_a_Car.Components.Forms.CarroForm;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Menus;

namespace Rent_a_Car.Views
{
    internal class ClienteList : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        #region Child elements
        public ClienteTable clienteTable;
        public ClienteControls clienteControls;
        #endregion

        public ClienteList()
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
            #region Preset setup
            if (this.Parent == null)
            {
                return;
            }
            this.Location = new Point(_margin[3], _margin[0]);
            this.Size = new Size(this.Parent.Width - _margin[1] - _margin[3], this.Parent.Height - _margin[0] - _margin[2]);
            #endregion

            Label pageTitle = new Label();
            pageTitle.Text = "Client List";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height);
            pageTitle.Location = new Point((this.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            this.Controls.Add(pageTitle);

            clienteControls = new ClienteControls(pageTitle.Font.Height * 3, 25, 25, this.Width / 2 + 25);
            this.Controls.Add(clienteControls);

            clienteTable = new ClienteTable(pageTitle.Font.Height * 3, this.Width / 2 + 25, 25, 25);
            clienteTable.FillData(Emp.ClienteList);
            this.Controls.Add(clienteTable);

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
