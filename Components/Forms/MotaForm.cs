﻿using Rent_a_Car.Classes;
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
    internal class MotaForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Mota mota = new Mota();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public MotaForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public MotaForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public MotaForm(Mota c) : this()
        {
            mota = c;
        }

        public MotaForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Mota c) : this(c)
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

            int id = mota.Id;

            InputBox marca = new InputBox();
            marca.label.Text = "Marca";
            this.Controls.Add(marca);
            marca.Size = new Size(this.Width / 2 - (25 * 2), marca.Height);
            marca.Location = new Point(25, 25);

            InputBox modelo = new InputBox();
            modelo.label.Text = "Modelo";
            this.Controls.Add(modelo);
            modelo.Size = new Size(this.Width / 2 - (25 * 2), marca.Height);
            modelo.Location = new Point(this.Width / 2 + 25, 25);

            InputBox cor = new InputBox();
            cor.label.Text = "Cor";
            this.Controls.Add(cor);
            cor.Size = new Size(this.Width / 2 - (25 * 2), cor.Height);
            cor.Location = new Point(25, 25 + (25 + cor.Height) * 1);

            InputBox matricula = new InputBox();
            matricula.label.Text = "Matricula";
            this.Controls.Add(matricula);
            matricula.Size = new Size(this.Width / 2 - (25 * 2), matricula.Height);
            matricula.Location = new Point(this.Width / 2 + 25, 25 + (25 + matricula.Height) * 1);

            InputBox ano = new InputBox();
            ano.label.Text = "Ano";
            this.Controls.Add(ano);
            ano.Size = new Size(this.Width / 2 - (25 * 2), ano.Height);
            ano.Location = new Point(25, 25 + (25 + ano.Height) * 2);

            InputBox quantRodas = new InputBox();
            quantRodas.label.Text = "quantRodas";
            this.Controls.Add(quantRodas);
            quantRodas.Size = new Size(this.Width / 2 - (25 * 2), quantRodas.Height);
            quantRodas.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantRodas.Height) * 2);

            InputBox valorDia = new InputBox();
            valorDia.label.Text = "valorDia";
            this.Controls.Add(valorDia);
            valorDia.Size = new Size(this.Width / 2 - (25 * 2), valorDia.Height);
            valorDia.Location = new Point(25, 25 + (25 + valorDia.Height) * 3);

            //specific inputs

            InputBox cubicCapacity = new InputBox();
            cubicCapacity.label.Text = "cubicCapacity";
            this.Controls.Add(cubicCapacity);
            cubicCapacity.Size = new Size(this.Width / 2 - (25 * 2), cubicCapacity.Height);
            cubicCapacity.Location = new Point(this.Width / 2 + 25, 25 + (25 + cubicCapacity.Height) * 3);

            if (id != -1)
            {
                marca.textBox.Text = mota.Marca;
                modelo.textBox.Text = mota.Modelo;
                cor.textBox.Text = mota.Cor;
                matricula.textBox.Text = mota.Matricula;
                ano.textBox.Text = mota.Ano.ToString();
                quantRodas.textBox.Text = mota.QuantRodas.ToString();
                valorDia.textBox.Text = mota.ValorDia.ToString();
                cubicCapacity.textBox.Text = mota.CubicCapacity.ToString();
            }

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
                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    mota.Id = 500; //to calculate
                    mota.Marca = marca.textBox.Text;
                    mota.Modelo = modelo.textBox.Text;
                    mota.Cor = cor.textBox.Text;
                    mota.Matricula = matricula.textBox.Text;
                    mota.Ano = Int32.Parse(ano.textBox.Text);
                    mota.QuantRodas = Int32.Parse(quantRodas.textBox.Text);
                    mota.ValorDia = float.Parse(valorDia.textBox.Text);
                    mota.CubicCapacity = Int32.Parse(cubicCapacity.textBox.Text);
                    Emp.AddMota(mota);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.MotasList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Mota c = Emp.ConvertObj(Emp.MotasList[i]);
                        if (c.Id == id)
                        {
                            c.Marca = marca.textBox.Text;
                            c.Modelo = modelo.textBox.Text;
                            c.Cor = cor.textBox.Text;
                            c.Matricula = matricula.textBox.Text;
                            c.Ano = Int32.Parse(ano.textBox.Text);
                            c.QuantRodas = Int32.Parse(quantRodas.textBox.Text);
                            c.ValorDia = float.Parse(valorDia.textBox.Text);
                            c.CubicCapacity = Int32.Parse(cubicCapacity.textBox.Text);
                            break;
                        }
                    }
                }
                DAL.DAL.storeMota();
                Emp.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Emp.VehicleList);
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
