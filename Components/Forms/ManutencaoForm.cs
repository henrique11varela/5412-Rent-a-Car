using Rent_a_Car.Classes;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;

namespace Rent_a_Car.Components.Forms
{
    internal class ManutencaoForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Manutencao manutencao;

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public ManutencaoForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public ManutencaoForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public ManutencaoForm(Manutencao m) : this()
        {
            manutencao = m;
        }

        public ManutencaoForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Manutencao m) : this(m)
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }
        #endregion

        private void Setup(object sender, EventArgs e)
        {
            #region Preset setup
            if (this.Parent == null)
            {
                return;
            }
            this.Location = new Point(_margin[3], _margin[0]);
            this.Size = new Size(this.Parent.Width - _margin[1] - _margin[3], this.Parent.Height - _margin[0] - _margin[2]);
            #endregion

            Label label = new Label();
            label.Font = ts.largeFont;
            label.Text = "Problema";
            label.Size = new Size(TextRenderer.MeasureText(label.Text, label.Font).Width, label.Font.Height) ;
            label.Location = new Point((this.Width - label.Width) / 2, label.Font.Height);
            this.Controls.Add(label);

            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Location = new Point(25, label.Height * 3);
            textBox.Size = new Size(this.Width - 2 * 25, this.Height - 25 - label.Height * 3 - ts.mediumFont.Height * 3);
            this.Controls.Add(textBox);

            FlatButton Submit = new FlatButton();
            Submit.Text = "Submit";
            this.Controls.Add(Submit);
            Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.light;
            void submitClick(object sender, EventArgs e)
            {
                try {
                    if (textBox.Text.Length < 1) {
                        throw new Exception("Preencha o campo vazio.");
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }

                manutencao.Problema = textBox.Text;

                Emp.AddManutencao(manutencao);
                DAL.DAL.storeManutencao();
                Emp.manutencaoTable.FillData(Emp.ManutencaoList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Submit.Click += submitClick;

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
            this.Controls.Add(Cancel);
            Cancel.Location = new Point(this.Width / 2 + 25, this.Height - Cancel.Height - 25);
            Cancel.Size = new Size(this.Width / 2 - 2 * 25, Cancel.Height);
            Cancel.BGC = ts.dark;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.light;
            void cancelClick(object sender, EventArgs e)
            {
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Cancel.Click += cancelClick;

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
