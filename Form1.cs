using Rent_a_Car.Views;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using View0 = Rent_a_Car.Views.View0;

namespace Rent_a_Car
{
    public partial class Form1 : Form
    {
        //CONSTANTS
        const int form_width = 800;
        const int form_height = 450;
        const int nav_bar_height = 30;
        const int number_of_views = 5;

        Panel nav = new Panel();
        List<Button> Tabs = new List<Button>();
        List<Panel> Views = new List<Panel>();

        public Form1()
        {
            //FORM1 SETUP
            this.Size = new Size(form_width, form_height);

            //NAV SETUP
            nav = CreateNavElement();
            this.Controls.Add(nav);
            nav.Controls.Add(CreateCloseButtonElement());

            int tabWidth = (this.ClientSize.Width - nav_bar_height) / number_of_views;
            for (int i = 0; i < number_of_views; i++)
            {
                //TABS
                Button tab = CreateTabElement("button" + Tabs.Count, tabWidth * i, tabWidth, i);
                Tabs.Add(tab);
                nav.Controls.Add(tab);

                //VIEWS
                Panel view = CreateViewElement();
                Views.Add(view);
                this.Controls.Add(view);

                //TESTING
                int test = 255 / (1 + i);
                Views[i].BackColor = Color.FromArgb(test, test, test);
            }

            //Example of change of view
            View0.Setup(Tabs[0], Views[0]);

            InitializeComponent();
        }

        /// <summary>Creates the navbar element.</summary>
        /// <returns>Panel element</returns>
        private Button CreateCloseButtonElement()
        {
            Button close = new Button();
            close.Text = "X";
            close.Location = new Point(this.Size.Width - nav_bar_height, 0);
            close.Size = new Size(nav_bar_height, nav_bar_height);
            void closeWindow(object sender, EventArgs e)
            {
                this.Close();
            }
            close.Click += closeWindow;
            return close;
        }

        /// <summary>Creates the navbar element.</summary>
        /// <returns>Panel element</returns>
        private Panel CreateNavElement()
        {
            Panel nav = new Panel();
            nav.BackColor = SystemColors.ActiveCaption;
            nav.Dock = DockStyle.Top;
            nav.Location = new Point(0, 0);
            nav.Size = new Size(this.ClientSize.Width, nav_bar_height);
            nav.TabIndex = 0;
            return nav;
        }

        /// <summary>Creates a view element.</summary>
        /// <returns>Panel element</returns>
        private Panel CreateViewElement()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(255, 192, 192);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, nav_bar_height);
            panel.Size = new Size(this.Size.Width, this.Size.Height - nav_bar_height);
            panel.TabIndex = 1;
            return panel;
        }

        /// <summary>Creates a tab element.</summary>
        /// <returns>Button element</returns>
        private Button CreateTabElement(string text, int x, int width, int id)
        {
            Button button = new Button();
            button.Location = new Point(x, 0);
            button.Size = new Size(width, nav_bar_height);
            button.TabIndex = 0;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            void button_Click(object sender, EventArgs e)
            {
                foreach (Panel view in Views)
                {
                    view.Visible = false;
                }
                Views[id].Visible = true;
            }
            button.Click += button_Click;
            return button;
        }

    }
}