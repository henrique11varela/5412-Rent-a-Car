using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.Views
{
    internal class View0
    {
        /// <summary>Adds elements to view[0].</summary>
        public static void Setup(Button tab, Panel view)
        {
            //Name
            tab.Text = "test name";

            //Content
            Label lbl = new Label();
            lbl.Text = "this is a test";
            lbl.Location = new Point(50, 50);

            //Add content to view
            view.Controls.Add(lbl);
        }
    }
}
