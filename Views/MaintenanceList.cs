using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car.Views
{
    internal class MaintenanceList
    {
        public static void Setup(Button tab, Panel view)
        {
            string title = "Maintenance";

            //Name
            tab.Text = title;

            //Content


            ///label creation and styling
            Label pageTitle = new Label();
            pageTitle.Text = title;
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height); ;
            pageTitle.Location = new Point((view.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            
            
            
            view.Controls.Add(pageTitle);
        }
    }
}
