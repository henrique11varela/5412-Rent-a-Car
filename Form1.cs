using Rent_a_Car.Views;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using vehicleList = Rent_a_Car.Views.vehicleList;

namespace Rent_a_Car
{
    public partial class Form1 : Form
    {
        //CONSTANTS
        int form_width = Screen.PrimaryScreen.WorkingArea.Width;
        int form_height = Screen.PrimaryScreen.WorkingArea.Height;
        int nav_bar_height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.05);
        const int number_of_views = 5;

        int ActiveView = 0;
        Panel nav = new Panel();
        List<Button> Tabs = new List<Button>();
        List<Panel> Views = new List<Panel>();

        public Form1()
        {
            //FORM1 SETUP
            this.Size = new Size(form_width, form_height);
            this.Font = new Font("Segoe UI", 9);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

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
            vehicleList.Setup(Tabs[0], Views[0]);

            InitializeComponent();
        }

        /// <summary>Creates the navbar element.</summary>
        /// <returns>Panel element</returns>
        private Button CreateCloseButtonElement()
        {
            //Constants
            Color bgc = Color.FromArgb(255, 102, 102);
            Color bgcHover = Color.FromArgb(255, 153, 153);

            Button close = new Button();
            close.Location = new Point(this.Size.Width - nav_bar_height, 0);
            close.Size = new Size(nav_bar_height, nav_bar_height);
            close.ForeColor = Color.White;
            close.BackColor = bgc;
            close.Text = "X";
            close.Font = new Font("Segoe UI", (int)(nav_bar_height * 0.2));
            close.TextAlign = ContentAlignment.MiddleCenter;
            void enter(object sender, EventArgs e)
            {
                close.BackColor = bgcHover;
            }
            close.MouseEnter += enter;
            void leave(object sender, EventArgs e)
            {
                close.BackColor = bgc;
            }
            close.MouseLeave += leave;
            //ACTION
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
            nav.Location = new Point(0, 0);
            nav.Size = new Size(this.Width, nav_bar_height);
            return nav;
        }

        /// <summary>Creates a view element.</summary>
        /// <returns>Panel element</returns>
        private Panel CreateViewElement()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(255, 192, 192);
            panel.Location = new Point(0, nav_bar_height);
            panel.Size = new Size(this.Width, this.Height);
            return panel;
        }

        /// <summary>Creates a tab element.</summary>
        /// <returns>Button element</returns>
        private Button CreateTabElement(string text, int x, int width, int id)
        {
            //Constants
            Color inactiveColor = Color.White;
            Color activeColor = Color.IndianRed;
            Color hoverColor = Color.Pink;

            Button button = new Button();
            button.Location = new Point(x, 0);
            button.Size = new Size(width, nav_bar_height);
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            //enter event
            void button_enter(object sender, EventArgs e)
            {
                button.BackColor = hoverColor;
            }
            button.MouseEnter += button_enter;
            //leave event
            void button_leave(object sender, EventArgs e)
            {
                button.BackColor = ActiveView == id ? activeColor : inactiveColor;
            }
            button.MouseLeave += button_leave;
            //click event
            void button_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < number_of_views; i++)
                {
                    Views[i].Visible = false;
                    Tabs[i].BackColor = inactiveColor;
                }
                ActiveView = id;
                Tabs[id].BackColor = activeColor;
                Views[id].Visible = true;
            }
            button.Click += button_Click;
            return button;
        }

    }
}