using Rent_a_Car.Views;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;
using vehicleList = Rent_a_Car.Views.vehicleList;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;

namespace Rent_a_Car
{
    public partial class Form1 : Form
    {
        //CONSTANTS
        int form_width = Screen.PrimaryScreen.WorkingArea.Width;
        int form_height = Screen.PrimaryScreen.WorkingArea.Height;
        const int number_of_views = 5;
        int nav_bar_height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.05);

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
            }

            int tempId = 1;
            Emp.AddMota(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 2, "11-11-11", 2000, "free", DateTime.Now, 2, 50);
            Emp.AddCarro(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5, true);
            Emp.AddCamiao(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5);
            Emp.AddCamioneta(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 4, 100);
            Emp.AddMota(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 2, "11-11-11", 2000, "free", DateTime.Now, 2, 50);
            Emp.AddCarro(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5, true);
            Emp.AddCamiao(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5);
            Emp.AddCamioneta(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 4, 100);
            Emp.AddMota(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 2, "11-11-11", 2000, "free", DateTime.Now, 2, 50);
            Emp.AddCarro(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5, true);
            Emp.AddCamiao(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 5);
            Emp.AddCamioneta(tempId, "marcaTeste" + tempId++, "modeloTeste", "corTeste", 4, "11-11-11", 2000, "free", DateTime.Now, 2, 4, 100);


            //Example of change of view
            vehicleList.Setup(Tabs[0], Views[0]);

            //give names to tabs
            
            Tabs[1].Text = "Maintenance";
            Tabs[2].Text = "History";
            Tabs[3].Text = "Placeholder";


            InitializeComponent();
        }

        /// <summary>Creates the navbar element.</summary>
        /// <returns>Panel element</returns>
        private Button CreateCloseButtonElement()
        {
            //Constants
            Color bgc = ts.danger;
            Color bgcHover = ts.danger_emphasis;

            Button close = new Button();
            close.Location = new Point(this.Size.Width - nav_bar_height, 0);
            close.Size = new Size(nav_bar_height, nav_bar_height);
            close.ForeColor = Color.White;
            close.BackColor = bgc;
            close.Text = "X";
            close.Font = new Font("Segoe UI", (int)(nav_bar_height * 0.2));
            close.TextAlign = ContentAlignment.MiddleCenter;
            close.FlatStyle = FlatStyle.Flat;
            close.FlatAppearance.BorderSize = 0;
            void enter(object sender, EventArgs e)
            {
                close.BackColor = bgcHover;
            }
            void leave(object sender, EventArgs e)
            {
                close.BackColor = bgc;
            }
            void closeWindow(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Exit the program?", "Exit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            close.MouseEnter += enter;
            close.MouseLeave += leave;
            close.Click += closeWindow;
            return close;
        }

        /// <summary>Creates the navbar element.</summary>
        /// <returns>Panel element</returns>
        private Panel CreateNavElement()
        {
            Panel nav = new Panel();
            nav.BackColor = ts.light;
            nav.Location = new Point(0, 0);
            nav.Size = new Size(this.Width, nav_bar_height);
            return nav;
        }

        /// <summary>Creates a view element.</summary>
        /// <returns>Panel element</returns>
        private Panel CreateViewElement()
        {
            Color bgc = ts.light;

            Panel panel = new Panel();
            panel.BackColor = bgc;
            panel.Location = new Point(0, nav_bar_height);
            panel.Size = new Size(this.Width, this.Height);
            return panel;
        }

        /// <summary>Creates a tab element.</summary>
        /// <returns>Button element</returns>
        private Button CreateTabElement(string text, int x, int width, int id)
        {
            //Constants
            Color inactiveColor = ts.dark;
            Color activeColor = ts.light;
            Color hoverColor = ts.dark_emphasis;

            Button button = new Button();
            button.Location = new Point(x, 0);
            button.Size = new Size(width, nav_bar_height);
            button.Font = ts.mediumFont;
            button.Text = text;
            button.UseVisualStyleBackColor = true;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button_leave(new Object(), new EventArgs());
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
                button.ForeColor = ActiveView == id ? inactiveColor : activeColor;
            }
            button.MouseLeave += button_leave;
            //click event
            void button_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < number_of_views; i++)
                {
                    Views[i].Visible = false;
                    Tabs[i].BackColor = inactiveColor;
                    Tabs[i].ForeColor = activeColor;
                }
                ActiveView = id;
                button.ForeColor = inactiveColor;
                button.BackColor = activeColor;
                Views[id].Visible = true;
            }
            button.Click += button_Click;
            return button;
        }

        
    }
}