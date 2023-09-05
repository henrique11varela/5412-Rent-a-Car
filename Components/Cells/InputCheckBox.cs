using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Input
{
    internal class InputCheckBox : Panel
    {
        public Label label = new Label();
        public CheckBox checkBox = new CheckBox();
        public InputCheckBox() : base()
        {
            Font font = ts.mediumFont;
            int gap = 15;
            //label
            label.Font = font;
            label.Location = new Point(0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "Placeholder";

            //checkbox
            checkBox.Font = font;
            checkBox.Location = new Point(0, label.Height + gap);
            checkBox.Text = "";
            checkBox.Size = new Size((TextRenderer.MeasureText(checkBox.Text, checkBox.Font).Width + checkBox.Font.Height), checkBox.Font.Height * 2);

            this.Size = new Size(this.Width, label.Height + gap + checkBox.Height);
            updateSize(new object(),new EventArgs());
            this.Resize += updateSize;
            this.Controls.Add(label);
            this.Controls.Add(checkBox);
        }
        private void updateSize(object sender, EventArgs e) { 
            label.Size = new Size(this.Width, this.Font.Height + 4);
        }
    }
}
