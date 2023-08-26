using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components.Input;
using Rent_a_Car.Components.Buttons;

namespace Rent_a_Car.Components.Forms
{
    internal static class CarForm
    {
        public static Panel Setup(Panel view, int margin_top, int margin_right, int margin_bottom, int margin_left)
        {
            Panel vForm = new Panel();

            vForm.Location = new Point(margin_left, margin_top);
            vForm.Size = new Size(view.Width - margin_right - margin_left, view.Height - margin_top - margin_bottom);

            vForm.BackColor = ts.dark_emphasis;

            InputBox marca = new InputBox();
            marca.Size = new Size(vForm.Width / 2 - (25 * 2), marca.Height);
            marca.Location = new Point(25, 25);
            marca.label.Text = "Marca";
            vForm.Controls.Add(marca);

            InputBox modelo = new InputBox();
            modelo.Size = new Size(vForm.Width / 2 - (25 * 2), marca.Height);
            modelo.Location = new Point(vForm.Width / 2 + 25, 25);
            modelo.label.Text = "Modelo";
            vForm.Controls.Add(modelo);

            InputBox cor = new InputBox();
            cor.Size = new Size(vForm.Width / 2 - (25 * 2), cor.Height);
            cor.Location = new Point(25, 25 + (25 + cor.Height) * 1);
            cor.label.Text = "Cor";
            vForm.Controls.Add(cor);

            InputBox matricula = new InputBox();
            matricula.Size = new Size(vForm.Width / 2 - (25 * 2), matricula.Height);
            matricula.Location = new Point(vForm.Width / 2 + 25, 25 + (25 + matricula.Height) * 1);
            matricula.label.Text = "Matricula";
            vForm.Controls.Add(matricula);

            InputBox ano = new InputBox();
            ano.Size = new Size(vForm.Width / 2 - (25 * 2), ano.Height);
            ano.Location = new Point(25, 25 + (25 + ano.Height) * 2);
            ano.label.Text = "Ano";
            vForm.Controls.Add(ano);

            InputBox quantRodas = new InputBox();
            quantRodas.Size = new Size(vForm.Width / 2 - (25 * 2), quantRodas.Height);
            quantRodas.Location = new Point(vForm.Width / 2 + 25, 25 + (25 + quantRodas.Height) * 2);
            quantRodas.label.Text = "quantRodas";
            vForm.Controls.Add(quantRodas);

            InputBox valorDia = new InputBox();
            valorDia.Size = new Size(vForm.Width / 2 - (25 * 2), valorDia.Height);
            valorDia.Location = new Point(25, 25 + (25 + valorDia.Height) * 3);
            valorDia.label.Text = "valorDia";
            vForm.Controls.Add(valorDia);

            InputBox quantDoors = new InputBox();
            quantDoors.Size = new Size(vForm.Width / 2 - (25 * 2), quantDoors.Height);
            quantDoors.Location = new Point(vForm.Width / 2 + 25, 25 + (25 + quantDoors.Height) * 3);
            quantDoors.label.Text = "quantDoors";
            vForm.Controls.Add(quantDoors);

            InputBox isManual = new InputBox();
            isManual.Size = new Size(vForm.Width / 2 - (25 * 2), isManual.Height);
            isManual.Location = new Point(25, 25 + (25 + isManual.Height) * 4);
            isManual.label.Text = "isManual";
            vForm.Controls.Add(isManual);




            FlatButton Submit = new FlatButton();
            Submit.Text = "Submit";
            Submit.Location = new Point(25, vForm.Height - Submit.Height - 25);
            Submit.Size = new Size(vForm.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.light;
            void submitClick(object sender, EventArgs e)
            {
                MessageBox.Show("Submit logic");
            }
            Submit.Click += submitClick;
            vForm.Controls.Add(Submit);

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
            Cancel.Location = new Point(vForm.Width / 2 + 25, vForm.Height - Cancel.Height - 25);
            Cancel.Size = new Size(vForm.Width / 2 - 2 * 25, Cancel.Height);
            Cancel.BGC = ts.dark;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.light;
            void cancelClick(object sender, EventArgs e)
            {
                MessageBox.Show("Cancel logic");
                vForm.Hide();
            }
            Cancel.Click += cancelClick;
            vForm.Controls.Add(Cancel);

            vForm.Hide();
            view.Controls.Add(vForm);
            return vForm;
        }

        private static void Cancel_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
