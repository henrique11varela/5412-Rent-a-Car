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
        public Color bgc = ts.dark_emphasis;
        public Color bgcHover = ts.dark;
        public FlatButton() : base() {
            this.Font = ts.mediumFont;
            this.Text = "Placeholder";
            this.Size = new Size((TextRenderer.MeasureText(this.Text, this.Font).Width + this.Font.Height), this.Font.Height * 2);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = bgc;
            void newVehicleEnter(object sender, EventArgs e)
            {
                this.BackColor = bgcHover;
            }
            void newVehicleLeave(object sender, EventArgs e)
            {
                this.BackColor = bgc;
            }
            void newVehicleClick(object sender, EventArgs e)
            {
                this.BackColor = bgc;
            }
            this.Enter += newVehicleEnter;
            this.Leave += newVehicleLeave;
            this.Click += newVehicleClick;
        }
    }
}
