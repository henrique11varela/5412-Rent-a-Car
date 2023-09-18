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
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rent_a_Car.Components.Forms
{
    internal class CamiaoForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Camiao camiao = new Camiao();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public CamiaoForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CamiaoForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CamiaoForm(Camiao c) : this()
        {
            camiao = c;
        }

        public CamiaoForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Camiao c) : this(c)
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

            int id = camiao.Id;

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

            InputBox maxWeight = new InputBox();
            maxWeight.label.Text = "Peso Máximo";
            this.Controls.Add(maxWeight);
            maxWeight.Size = new Size(this.Width / 2 - (25 * 2), maxWeight.Height);
            maxWeight.Location = new Point(this.Width / 2 + 25, 25 + (25 + maxWeight.Height) * 3);

            if (id != -1)
            {
                marca.textBox.Text = camiao.Marca;
                modelo.textBox.Text = camiao.Modelo;
                cor.textBox.Text = camiao.Cor;
                matricula.textBox.Text = camiao.Matricula;
                ano.textBox.Text = camiao.Ano.ToString();
                quantRodas.textBox.Text = camiao.QuantRodas.ToString();
                valorDia.textBox.Text = camiao.ValorDia.ToString();
                maxWeight.textBox.Text = camiao.MaxWeight.ToString();
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
                float tempMaxWeight;

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
                    Regex reg = new Regex("(^\\d{2}-[A-Za-z]{2}-\\d{2}$)|(^[A-Za-z]{2}-\\d{2}-\\d{2}$)|(^\\d{2}-\\d{2}-[A-Za-z]{2}$)|(^\\d{2}-[A-Za-z]{2}-[A-Za-z]{2}$)|(^[A-Za-z]{2}-\\d{2}-[A-Za-z]{2}$)|(^[A-Za-z]{2}-[A-Za-z]{2}-\\d{2}$)");
                    tempMatricula = reg.Match(tempMatricula).ToString();
                    if (tempMatricula.Length < 1)
                    {
                        throw new Exception("Campo Matricula não é válido!");
                    }



                    //validar se campo Ano está preenchido
                    if (ano.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Ano não pode estar vazio!");
                    }
                    //validar se ano é numero inteiro
                    try
                    {
                        tempAno = Int32.Parse(ano.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O ano tem de ser um número inteiro!");
                    }
                    //validar se ano é numero valido
                    if (tempAno < 1980 || tempAno >= DateTime.Now.Year)
                    {
                        throw new Exception("Ano tem de ser um numero entre 1980 e " + DateTime.Now.Year);
                    }




                    //validar se campo quantRodas está preenchido
                    if (quantRodas.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Quantidade de Rodas não pode estar vazio!");
                    }
                    //validar se quantRodas é numero inteiro
                    try
                    {
                        tempQuantRodas = Int32.Parse(quantRodas.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O número de rodas tem de ser um número inteiro!");
                    }
                    //validar se quantRodas é superior a zero
                    if (tempQuantRodas <= 0)
                    {
                        throw new Exception("O número de rodas tem de ser maior que zero!");
                    }


                    //validar se campo valorDia está preenchido
                    if (valorDia.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Valor Dia não pode estar vazio!");
                    }
                    //validar se valorDia é um valor decimal
                    try
                    {
                        tempValorDia = float.Parse(valorDia.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O Valor Dia tem de ser um número inteiro ou decimal maior que zero!");
                    }
                    //validar se valorDia é superior a zero
                    if (tempValorDia <= 0)
                    {
                        throw new Exception("O campo Valor Dia tem de ser maior que zero!");
                    }


                    //validar se campo maxWeight está preenchido
                    if (maxWeight.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Peso Máximo não pode estar vazio!");
                    }
                    //validar se maxWeight é um valor decimal
                    try
                    {
                        tempMaxWeight = float.Parse(maxWeight.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O Peso Máximo tem de ser um número inteiro ou decimal maior que zero!");
                    }
                    //validar se maxWeight é superior a zero
                    if (tempMaxWeight <= 0)
                    {
                        throw new Exception("O Peso Máximo tem de ser maior que zero!");
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
                    //assign variables
                    camiao.Id = Emp.LastCamiaoId++;
                    camiao.Marca = tempMarca;
                    camiao.Modelo = tempModelo;
                    camiao.Cor = tempCor;
                    camiao.Matricula = tempMatricula;
                    camiao.Ano = tempAno;
                    camiao.QuantRodas = tempQuantRodas;
                    camiao.ValorDia = tempValorDia;
                    camiao.MaxWeight = tempMaxWeight;

                    Emp.AddCamiao(camiao);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.CamioesList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Camiao c = Emp.ConvertObj(Emp.CamioesList[i]);
                        if (c.Id == id)
                        {
                            //assign variables
                            c.Marca = tempMarca;
                            c.Modelo = tempModelo;
                            c.Cor = tempCor;
                            c.Matricula = tempMatricula;
                            c.Ano = tempAno;
                            c.QuantRodas = tempQuantRodas;
                            c.ValorDia = tempValorDia;
                            c.MaxWeight = tempMaxWeight;

                            break;
                        }
                    }
                }
                DAL.DAL.storeCamiao();
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
