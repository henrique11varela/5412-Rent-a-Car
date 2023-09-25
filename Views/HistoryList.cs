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
    internal class HistoryList : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        #region Child elements
        public AlugadoHistTable alugadoHistTable;
        public ManutencaoHistTable manutencaoHistTable;
        public HistControls histControls;
        #endregion

        public HistoryList()
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
            pageTitle.Text = "Historico";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height);
            pageTitle.Location = new Point((this.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            this.Controls.Add(pageTitle);

            Label reservadoTitle = new Label();
            reservadoTitle.Text = "Aluguer";
            reservadoTitle.TextAlign = ContentAlignment.TopCenter;
            reservadoTitle.Font = ts.largeFont;
            reservadoTitle.Size = new Size(TextRenderer.MeasureText(reservadoTitle.Text, reservadoTitle.Font).Width, reservadoTitle.Font.Height);
            reservadoTitle.Location = new Point((this.Width / 2 - TextRenderer.MeasureText(reservadoTitle.Text, reservadoTitle.Font).Width) / 2, reservadoTitle.Font.Height * 2);
            this.Controls.Add(reservadoTitle);


            alugadoHistTable = new AlugadoHistTable(reservadoTitle.Font.Height * 4, this.Width / 2 + 25, (this.Height - reservadoTitle.Font.Height * 3) / 2 + reservadoTitle.Font.Height, 25);
            alugadoHistTable.FillData(Emp.AlugadoHistList);
            this.Controls.Add(alugadoHistTable);

            Label alugadoTitle = new Label();
            alugadoTitle.Text = "Manutencao";
            alugadoTitle.TextAlign = ContentAlignment.TopCenter;
            alugadoTitle.Font = ts.largeFont;
            alugadoTitle.Size = new Size(TextRenderer.MeasureText(alugadoTitle.Text, alugadoTitle.Font).Width, alugadoTitle.Font.Height);
            alugadoTitle.Location = new Point((this.Width / 2 - TextRenderer.MeasureText(alugadoTitle.Text, alugadoTitle.Font).Width) / 2, this.Height / 2 + alugadoTitle.Font.Height);
            this.Controls.Add(alugadoTitle);

            manutencaoHistTable = new ManutencaoHistTable(this.Height / 2 + alugadoTitle.Font.Height * 3, this.Width / 2 + 25, 25, 25);
            manutencaoHistTable.FillData(Emp.ManutencaoHistList);
            this.Controls.Add(manutencaoHistTable);

            histControls = new HistControls(reservadoTitle.Font.Height * 3, 25, 25, this.Width / 2 + 25);

            this.Controls.Add(histControls);


            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
