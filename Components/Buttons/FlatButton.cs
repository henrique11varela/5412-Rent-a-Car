using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Buttons
{
    internal class FlatButton : Button
    {
        private Color bgc = ts.dark_emphasis;
        private Color bgcHover = ts.dark;

        public Color BGC
        {
            get
            {
                return bgc;
            }
            set
            {
                bgc = value;
                this.BackColor = BGC;
            }
        }
        public Color BGC_HOVER
        {
            get
            {
                return bgcHover;
            }
            set
            {
                bgcHover = value;
            }
        }
        public FlatButton() : base()
        {
            this.ParentChanged += Setup;
            this.Font = ts.mediumFont;
            this.Text = "Placeholder";
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = BGC;
        }

        private void Setup(object sender, EventArgs e)
        {
            this.Size = new Size((TextRenderer.MeasureText(this.Text, this.Font).Width + this.Font.Height), this.Font.Height * 2);
            void newVehicleEnter(object sender, EventArgs e)
            {
                this.BackColor = BGC_HOVER;
            }
            void newVehicleLeave(object sender, EventArgs e)
            {
                this.BackColor = BGC;
            }
            void newVehicleClick(object sender, EventArgs e)
            {
                this.BackColor = BGC;
            }
            this.Enter += newVehicleEnter;
            this.Leave += newVehicleLeave;
            this.Click += newVehicleClick;
        }
    }
}
