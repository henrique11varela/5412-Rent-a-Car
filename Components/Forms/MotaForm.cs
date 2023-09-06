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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            quantRodas.label.Text = "Quantidade de Rodas";
            this.Controls.Add(quantRodas);
            quantRodas.Size = new Size(this.Width / 2 - (25 * 2), quantRodas.Height);
            quantRodas.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantRodas.Height) * 2);

            InputBox valorDia = new InputBox();
            valorDia.label.Text = "Valor Dia";
            this.Controls.Add(valorDia);
            valorDia.Size = new Size(this.Width / 2 - (25 * 2), valorDia.Height);
            valorDia.Location = new Point(25, 25 + (25 + valorDia.Height) * 3);

            //specific inputs

            InputBox cubicCapacity = new InputBox();
            cubicCapacity.label.Text = "Capacidade Cúbica";
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
                string tempMarca;
                string tempModelo;
                string tempCor;
                string tempMatricula;
                int tempAno;
                int tempQuantRodas;
                float tempValorDia;
                int tempCubicCapacity;

                try
                {
                    //validar se marca não é string vazia
                    tempMarca = marca.textBox.Text;
                    if (tempMarca.Length < 1)
                    {
                        throw new Exception("Campo Marca não pode estar vazio!");
                    }

                    //validar se modelo não é string vazia
                    tempModelo = modelo.textBox.Text;
                    if (tempModelo.Length < 1)
                    {
                        throw new Exception("Campo Modelo não pode estar vazio!");
                    }

                    //validar se cor não é string vazia
                    tempCor = cor.textBox.Text;
                    if (tempCor.Length < 1)
                    {
                        throw new Exception("Campo Cor não pode estar vazio!");
                    }

                    //validar se matricula não é string vazia
                    tempMatricula = matricula.textBox.Text;
                    if (tempMatricula.Length < 1)
                    {
                        throw new Exception("Campo Matricula não pode estar vazio!");
                    }




                    //validar se ano é numero e se é um ano valido
                    if (ano.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Ano não pode estar vazio!");
                    }
                    try
                    {
                        tempAno = Int32.Parse(ano.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O ano tem de ser um número inteiro!");
                    }

                    if (tempAno < 1980 || tempAno >= DateTime.Now.Year)
                    {
                        throw new Exception("Ano tem de ser um numero entre 1980 e " + DateTime.Now.Year);
                    }




                    //validar se quantRodas é numero inteiro
                    if (quantRodas.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Quantidade de Rodas não pode estar vazio!");
                    }
                    try
                    {
                        tempQuantRodas = Int32.Parse(quantRodas.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O número de rodas tem de ser um número inteiro!");
                    }


                    //validar se valorDia é um valor decimal
                    if (valorDia.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Valor Dia não pode estar vazio!");
                    }
                    try
                    {
                        tempValorDia = float.Parse(valorDia.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O Valor Dia tem de ser um número inteiro ou decimal!");
                    }


                    //validar se cubicCapacity
                    if (cubicCapacity.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Capacidade Cúbica não pode estar vazio!");
                    }
                    try
                    {
                        tempCubicCapacity = Int32.Parse(cubicCapacity.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("A capacidade cúbica tem de ser um número inteiro!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    return;
                }


                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    mota.Id = 500; //to calculate

                    mota.Marca = tempMarca;
                    mota.Modelo = tempModelo;
                    mota.Cor = tempCor;
                    mota.Matricula = tempMatricula;
                    mota.Ano = tempAno;
                    mota.QuantRodas = tempQuantRodas;
                    mota.ValorDia = tempValorDia;



                    Emp.AddMota(mota);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.MotasList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Mota m = Emp.ConvertObj(Emp.MotasList[i]);
                        if (m.Id == id)
                        {

                            m.Marca = tempMarca;
                            m.Modelo = tempModelo;
                            m.Cor = tempCor;
                            m.Matricula = tempMatricula;
                            m.Ano = tempAno;
                            m.QuantRodas = tempQuantRodas;
                            m.ValorDia = tempValorDia;
                            m.CubicCapacity = tempCubicCapacity;



                            break;
                        }
                    }
                }
                DAL.DAL.storeMota();
                Emp.vehicleTable.FillData(Emp.VehicleList, Emp.ConvertObj(this.Parent).DateRange);
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
