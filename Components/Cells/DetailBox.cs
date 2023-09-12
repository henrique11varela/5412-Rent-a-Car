using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Components.Input
{
    internal class DetailBox : Panel
    {
        public Label label = new Label();
        public TextBox textBox = new TextBox();
        public DetailBox() : base()
        {
            Font font = ts.mediumFont;
            int gap = 15;
            //label
            label.Font = font;
            label.Location = new Point(0, 0);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "Placeholder";

            //textbox
            textBox.Font = font;
            textBox.Location = new Point(0, label.Height + gap);
            textBox.Text = "Placeholder";
            textBox.ReadOnly = true;
            textBox.Enabled = false;

            this.Size = new Size(this.Width, label.Height + gap + textBox.Height);
            updateSize(new object(), new EventArgs());
            this.Resize += updateSize;
            this.Controls.Add(label);
            this.Controls.Add(textBox);
        }
        private void updateSize(object sender, EventArgs e)
        {
            label.Size = new Size(this.Width, this.Font.Height + 4);
            textBox.Size = new Size(this.Width, this.Font.Height + 4);
        }
    }
}
