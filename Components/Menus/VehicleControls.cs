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
using Rent_a_Car.Components.Tables;

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


            Label filter = new Label();
            filter.Text = "Filtrar veiculos";
            filter.Font = ts.largeFont;
            filter.Size = new Size(TextRenderer.MeasureText(filter.Text, filter.Font).Width, filter.Font.Height);
            filter.Location = new Point(this.Width / 2 - (filter.Width / 2), this.Height / 2 - 25 - filter.Height * 5);
            this.Controls.Add(filter);

            FlatButton Camiao = new FlatButton();
            Camiao.Text = "Camiao";
            this.Controls.Add(Camiao);
            Camiao.Size = new Size(this.Width / 2 - 2 * 25, Camiao.Height);
            Camiao.Location = new Point(25, this.Height / 2 - Camiao.Height - 25);
            Camiao.BGC = ts.dark;
            Camiao.BGC_HOVER = ts.dark_emphasis;
            Camiao.ForeColor = ts.white;
            void camiaoFilter(Object sender, EventArgs e)
            {
                Emp.vehicleTable.FillData(Emp.CamioesList, DateRange);
            }
            Camiao.Click += camiaoFilter;


            //Logica reserva
            StartCalendar = new MonthCalendar();
            this.Controls.Add(StartCalendar);
            StartCalendar.MaxSelectionCount = 1;
            StartCalendar.Location = new Point(25 + Camiao.Width / 2 - 110, 25);
            StartCalendar.DateSelected += StartClick;

            EndCalendar = new MonthCalendar();
            this.Controls.Add(EndCalendar);
            EndCalendar.MaxSelectionCount = 1;
            EndCalendar.Size = StartCalendar.Size;
            EndCalendar.Location = new Point(this.Width - 25 - Camiao.Width / 2 - 110, 25);
            EndCalendar.DateSelected += EndClick;
            EndCalendar.MinDate = StartCalendar.SelectionStart;

            FlatButton Camioneta = new FlatButton();
            Camioneta.Text = "Camioneta";
            this.Controls.Add(Camioneta);
            Camioneta.Size = new Size(this.Width / 2 - 2 * 25, Camioneta.Height);
            Camioneta.Location = new Point(this.Width / 2 + 25, this.Height / 2 - Camioneta.Height - 25);
            Camioneta.BGC = ts.dark;
            Camioneta.BGC_HOVER = ts.dark_emphasis;
            Camioneta.ForeColor = ts.white;
            void camionetaFilter(Object sender, EventArgs e)
            {
                Emp.vehicleTable.FillData(Emp.CamionetasList, DateRange);
            }
            Camioneta.Click += camionetaFilter;

            FlatButton Carro = new FlatButton();
            Carro.Text = "Carro";
            this.Controls.Add(Carro);
            Carro.Size = new Size(this.Width / 2 - 2 * 25, Carro.Height);
            Carro.Location = new Point(25, this.Height / 2);
            Carro.BGC = ts.dark;
            Carro.BGC_HOVER = ts.dark_emphasis;
            Carro.ForeColor = ts.white;
            void carroFilter(Object sender, EventArgs e)
            {
                Emp.vehicleTable.FillData(Emp.CarrosList, DateRange);
            }
            Carro.Click += carroFilter;

            FlatButton Mota = new FlatButton();
            Mota.Text = "Mota";
            this.Controls.Add(Mota);
            Mota.Size = new Size(this.Width / 2 - 2 * 25, Mota.Height);
            Mota.Location = new Point(this.Width / 2 + 25, this.Height / 2);
            Mota.BGC = ts.dark;
            Mota.BGC_HOVER = ts.dark_emphasis;
            Mota.ForeColor = ts.white;
            void motaFilter(Object sender, EventArgs e)
            {
                Emp.vehicleTable.FillData(Emp.MotasList, DateRange);
            }
            Mota.Click += motaFilter;

            FlatButton Todos = new FlatButton();
            Todos.Text = "Todos";
            this.Controls.Add(Todos);
            Todos.Size = new Size(this.Width / 2 - 2 * 25, Todos.Height);
            Todos.Location = new Point(this.Width / 2 - Todos.Width / 2, this.Height / 2 + Todos.Height + 25);
            Todos.BGC = ts.dark;
            Todos.BGC_HOVER = ts.dark_emphasis;
            Todos.ForeColor = ts.white;
            void allFilter(Object sender, EventArgs e)
            {
                Emp.vehicleTable.FillData(Emp.VehicleList, DateRange);
            }
            Todos.Click += allFilter;



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
