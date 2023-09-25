using Rent_a_Car.Classes;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;

namespace Rent_a_Car.Components.Menus
{
    internal class VehicleControls : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private int _dateRange;
        public int DateRange { 
            get { 
                return _dateRange;
            } 
        }

        #region Child elements
        public MonthCalendar StartCalendar; 
        public MonthCalendar EndCalendar;
        #endregion

        #region Constructors
        public VehicleControls()
        {
            ParentChanged += Setup;
            BackColor = ts.light;
            _dateRange = 0;
        }

        public VehicleControls(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }
        #endregion

        /// <summary>
        /// Event that places element after instance is created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setup(object sender, EventArgs e)
        {
            #region Preset setup
            if (Parent == null)
            {
                return;
            }
            Location = new Point(_margin[3], _margin[0]);
            Size = new Size(Parent.Width - _margin[1] - _margin[3], Parent.Height - _margin[0] - _margin[2]);
            #endregion

            _dateRange = 0;

            //Logica reserva
            StartCalendar = new MonthCalendar();
            this.Controls.Add(StartCalendar);
            StartCalendar.MaxSelectionCount = 1;
            StartCalendar.Location = new Point(this.Width / 4 - (StartCalendar.Right - StartCalendar.Left), 25);
            StartCalendar.DateSelected += StartClick;

            EndCalendar = new MonthCalendar();
            this.Controls.Add(EndCalendar);
            EndCalendar.MaxSelectionCount = 1;
            EndCalendar.Size = EndCalendar.Size;
            EndCalendar.Location = new Point(this.Width / 4 * 3 - (EndCalendar.Right - EndCalendar.Left), 25);
            EndCalendar.DateSelected += EndClick;
            EndCalendar.MinDate = StartCalendar.SelectionStart;


            //Create vehicle button
            FlatButton createVehicle = new FlatButton();
            createVehicle.Text = "Criar Veiculo";
            createVehicle.Image = Emp.ResizeImage(Image.FromFile("..\\..\\..\\assets\\icons\\create.png"), createVehicle.Font.Height * 5, createVehicle.Font.Height * 5);
            createVehicle.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(createVehicle);

            //size/location before
            //createVehicle.Location = new Point(this.Width / 2 + 25, this.Height - 25 - createVehicle.Height);
            //createVehicle.Size = new Size(this.Width / 2 - 2 * 25, createVehicle.Height);

            //size/location after
            createVehicle.Location = new Point(this.Width / 2 - (this.Width / 4 - 25) / 2, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            createVehicle.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            createVehicle.BGC = ts.white;
            createVehicle.BGC_HOVER = ts.dark_emphasis;
            createVehicle.ForeColor = ts.dark;
            createVehicle.Click += newCarro;

            #region Preset setup
            BringToFront();
            #endregion
        }

        private void StartClick(object sender, EventArgs e)
        {
            EndCalendar.MinDate = StartCalendar.SelectionStart;
            EndCalendar.SelectionStart = StartCalendar.SelectionStart.AddDays(_dateRange);
            Emp.ConvertObj(this.Parent).vehicleTable.FillData(Emp.VehicleList, _dateRange);
        }

        private void EndClick(object sender, EventArgs e)
        {
            _dateRange = (EndCalendar.SelectionStart - StartCalendar.SelectionStart).Days;
            Emp.ConvertObj(this.Parent).vehicleTable.FillData(Emp.VehicleList, _dateRange);
        }

        private void newCarro(object sender, EventArgs e)
        {
            Controls.Add(new CreateVehicle());
        }
    }
}
