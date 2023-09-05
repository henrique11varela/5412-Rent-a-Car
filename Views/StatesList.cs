using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservadoTable = Rent_a_Car.Components.Tables.ReservadoTable;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Menus;
using System.Diagnostics.Contracts;

namespace Rent_a_Car.Views
{
    internal class StatesList : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        #region Child elements
        public ReservadoTable reservadoTable;
        public AlugadoTable alugadoTable;
        public ManutencaoTable manutencaoTable;
        #endregion

        public StatesList()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.light;

            //Emp.AddAlugado(new Alugado(1, "Carro", DateTime.Now, DateTime.Now, "000009"));
            DAL.DAL.storeAlugado();
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

            Label reservadoTitle = new Label();
            reservadoTitle.Text = "Reservas";
            reservadoTitle.TextAlign = ContentAlignment.TopCenter;
            reservadoTitle.Font = ts.largeFont;
            reservadoTitle.Size = new Size(TextRenderer.MeasureText(reservadoTitle.Text, reservadoTitle.Font).Width, reservadoTitle.Font.Height);
            reservadoTitle.Location = new Point((this.Width / 2 - TextRenderer.MeasureText(reservadoTitle.Text, reservadoTitle.Font).Width) / 2, reservadoTitle.Font.Height);
            this.Controls.Add(reservadoTitle);


            reservadoTable = new ReservadoTable(reservadoTitle.Font.Height * 3, this.Width / 2 + 25, this.Height / 3 * 2 + 25, 25);
            reservadoTable.FillData(Emp.ReservadoList);
            this.Controls.Add(reservadoTable);

            Label alugadoTitle = new Label();
            alugadoTitle.Text = "Aluguer";
            alugadoTitle.TextAlign = ContentAlignment.TopCenter;
            alugadoTitle.Font = ts.largeFont;
            alugadoTitle.Size = new Size(TextRenderer.MeasureText(alugadoTitle.Text, alugadoTitle.Font).Width, alugadoTitle.Font.Height);
            alugadoTitle.Location = new Point((this.Width / 2 - TextRenderer.MeasureText(alugadoTitle.Text, alugadoTitle.Font).Width) / 2, alugadoTitle.Font.Height + reservadoTitle.Font.Height * 3 + reservadoTable.Height);
            this.Controls.Add(alugadoTitle);

            alugadoTable = new AlugadoTable(alugadoTitle.Font.Height * 3 + reservadoTable.Height + reservadoTitle.Font.Height * 3, this.Width / 2 + 25, this.Height / 3 + 25, 25);
            alugadoTable.FillData(Emp.AlugadoList);
            this.Controls.Add(alugadoTable);

            
            Label manutencaoTitle = new Label();
            manutencaoTitle.Text = "Manutencao";
            manutencaoTitle.TextAlign = ContentAlignment.TopCenter;
            manutencaoTitle.Font = ts.largeFont;
            manutencaoTitle.Size = new Size(TextRenderer.MeasureText(manutencaoTitle.Text, manutencaoTitle.Font).Width, manutencaoTitle.Font.Height);
            manutencaoTitle.Location = new Point((this.Width / 2 - TextRenderer.MeasureText(manutencaoTitle.Text, manutencaoTitle.Font).Width) / 2, alugadoTitle.Font.Height + reservadoTitle.Font.Height * 3 + manutencaoTitle.Font.Height * 3 + reservadoTable.Height + alugadoTable.Height);
            this.Controls.Add(manutencaoTitle);
            manutencaoTitle.BringToFront();

            manutencaoTable = new ManutencaoTable(alugadoTitle.Font.Height * 3 + reservadoTitle.Font.Height * 3 + manutencaoTitle.Font.Height * 3 + alugadoTable.Height + reservadoTable.Height, this.Width / 2 + 25, 25, 25);
            manutencaoTable.FillData(Emp.ManutencaoList);
            this.Controls.Add(manutencaoTable);
            

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
