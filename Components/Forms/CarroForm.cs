﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ts = Rent_a_Car.ThemeScheme;
using Emp = Rent_a_Car.Classes.Empresa;
using Rent_a_Car.Components.Input;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Rent_a_Car.Components.Tables;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Rent_a_Car.Components.Forms
{
    internal class CarroForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Carro carro = new Carro();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public CarroForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CarroForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CarroForm(Carro c) : this()
        {
            carro = c;
        }

        public CarroForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Carro c) : this(c)
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

            int id = carro.Id;

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

            InputBox quantDoors = new InputBox();
            quantDoors.label.Text = "Quantidade de Portas";
            this.Controls.Add(quantDoors);
            quantDoors.Size = new Size(this.Width / 2 - (25 * 2), quantDoors.Height);
            quantDoors.Location = new Point(this.Width / 2 + 25, 25 + (25 + quantDoors.Height) * 3);


            
            InputCheckBox isManual = new InputCheckBox();
            isManual.label.Text = "Manual?";
            this.Controls.Add(isManual);
            isManual.Size = new Size(this.Width / 2 - (25 * 2), isManual.Height);
            isManual.Location = new Point(25, 25 + (25 + isManual.Height) * 4);
            
            

            if (id != -1)
            {
                marca.textBox.Text = carro.Marca;
                modelo.textBox.Text = carro.Modelo;
                cor.textBox.Text = carro.Cor;
                matricula.textBox.Text = carro.Matricula;
                ano.textBox.Text = carro.Ano.ToString();
                quantRodas.textBox.Text = carro.QuantRodas.ToString();
                valorDia.textBox.Text = carro.ValorDia.ToString();
                quantDoors.textBox.Text = carro.QuantDoors.ToString();
                isManual.checkBox.Checked = carro.IsManual;
            }

            FlatButton Submit = new FlatButton();
            Submit.Text = "Submeter";
            this.Controls.Add(Submit);
            Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.white;
            void submitClick(object sender, EventArgs e)
            {
                string tempMarca;
                string tempModelo;
                string tempCor;
                string tempMatricula;
                int tempAno;
                int tempQuantRodas;
                float tempValorDia;
                int tempQuantDoors;
                bool tempIsManual;

                try
                {
                    //validar se marca não é string vazia
                    tempMarca = marca.textBox.Text;
                    if(tempMarca.Length < 1)
                    {
                        throw new Exception("Campo Marca nao pode estar vazio!");
                    }

                    //validar se modelo não é string vazia
                    tempModelo = modelo.textBox.Text;
                    if (tempModelo.Length < 1)
                    {
                        throw new Exception("Campo Modelo nao pode estar vazio!");
                    }

                    //validar se cor não é string vazia
                    tempCor = cor.textBox.Text;
                    if (tempCor.Length < 1)
                    {
                        throw new Exception("Campo Cor nao pode estar vazio!");
                    }

                    //validar se matricula não é string vazia
                    tempMatricula = matricula.textBox.Text;
                    if (tempMatricula.Length < 1)
                    {
                        throw new Exception("Campo Matricula nao pode estar vazio!");
                    }
                    Regex reg = new Regex("(^\\d{2}-[A-Za-z]{2}-\\d{2}$)|(^[A-Za-z]{2}-\\d{2}-\\d{2}$)|(^\\d{2}-\\d{2}-[A-Za-z]{2}$)|(^\\d{2}-[A-Za-z]{2}-[A-Za-z]{2}$)|(^[A-Za-z]{2}-\\d{2}-[A-Za-z]{2}$)|(^[A-Za-z]{2}-[A-Za-z]{2}-\\d{2}$)");
                    tempMatricula = reg.Match(tempMatricula).ToString();
                    if (tempMatricula.Length < 1)
                    {
                        throw new Exception("Campo Matricula nao e valido!");
                    }




                    //validar se ano é numero e se é um ano valido
                    if (ano.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Ano nao pode estar vazio!");
                    }
                    try
                    {
                        tempAno = Int32.Parse(ano.textBox.Text);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception("O ano tem de ser um numero inteiro!");
                    }

                    if (tempAno < 1980 || tempAno > DateTime.Now.Year)
                    {
                        throw new Exception("Ano tem de ser um numero entre 1980 e " + DateTime.Now.Year);
                    }




                    //validar se campo quantRodas está preenchido
                    if (quantRodas.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Quantidade de Rodas nao pode estar vazio!");
                    }
                    //validar se quantRodas é numero inteiro
                    try
                    {
                        tempQuantRodas = Int32.Parse(quantRodas.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O numero de rodas tem de ser um numero inteiro!");
                    }
                    //validar se quantRodas é superior a zero
                    if (tempQuantRodas <= 0)
                    {
                        throw new Exception("Campo Quantidade de Rodas tem de ser maior que zero!");
                    }


                    //validar se campo valorDia está preenchido
                    if (valorDia.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Valor Dia nao pode estar vazio!");
                    }
                    //validar se valorDia é um valor decimal
                    try
                    {
                        tempValorDia = float.Parse(valorDia.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O Valor Dia tem de ser um numero inteiro ou decimal!");
                    }
                    //validar se valorDia é superior a zero
                    if (tempValorDia <= 0)
                    {
                        throw new Exception("O campo Valor Dia tem de ser maior que zero!");
                    }


                    //validar se campo quantDoors está preenchido
                    if (quantDoors.textBox.Text.Length < 1)
                    {
                        throw new Exception("Campo Quantidade de Portas nao pode estar vazio!");
                    }
                    //validar se quantDoors é numero inteiro
                    try
                    {
                        tempQuantDoors = Int32.Parse(quantDoors.textBox.Text);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("O numero de portas tem de ser um numero inteiro!");
                    }
                    //validar se quantDoors é superior a zero
                    if (tempQuantDoors <= 0)
                    {
                        throw new Exception("Campo Quantidade de Portas tem de ser maior que zero!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    return;
                }



                //validar input da checkbox
                tempIsManual = isManual.checkBox.Checked;
                


                MessageBox.Show("Veiculo adicionado!", "Sucesso");
                //validate inputs
                if (id == -1)
                {
                    carro.Id = Emp.LastCarroId++;

                    carro.Marca = tempMarca;
                    carro.Modelo = tempModelo;
                    carro.Cor = tempCor;
                    carro.Matricula = tempMatricula;
                    carro.Ano = tempAno;
                    carro.QuantRodas = tempQuantRodas;
                    carro.ValorDia = tempValorDia;
                    carro.QuantDoors = tempQuantDoors;

                    carro.IsManual = tempIsManual;
                    Emp.AddCarro(carro);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.CarrosList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Carro c = Emp.ConvertObj(Emp.CarrosList[i]);
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
                            c.QuantDoors = tempQuantDoors;

                            c.IsManual = tempIsManual;
                            break;
                        }
                    }
                }
                DAL.DAL.storeCarro();
                Emp.vehicleTable.FillData(Emp.VehicleList, Emp.ConvertObj(this.Parent).DateRange);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Submit.Click += submitClick;

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancelar";
            this.Controls.Add(Cancel);
            Cancel.Location = new Point(this.Width / 2 + 25, this.Height - Cancel.Height - 25);
            Cancel.Size = new Size(this.Width / 2 - 2 * 25, Cancel.Height);
            Cancel.BGC = ts.dark;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.white;
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
