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
            Submit.Text = "Submit";
            this.Controls.Add(Submit);
            Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);
            Submit.BGC = ts.dark;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.light;
            void submitClick(object sender, EventArgs e)
            {
                static void validateEmptyString(string prop, string textBoxText)
                {
                    try
                    {
                        if(prop.Length > 0)
                        {
                            prop = textBoxText;
                        }
                        else
                        {
                            throw new Exception("string vazia!");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }

                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    carro.Id = 500; //to calculate
                    validateEmptyString(carro.Marca, matricula.textBox.Text);
                    validateEmptyString(carro.Modelo, modelo.textBox.Text);
                    validateEmptyString(carro.Cor, cor.textBox.Text);
                    validateEmptyString(carro.Matricula, matricula.textBox.Text);
                    try
                    {
                        //validar se ano é numero e se é um ano valido 
                        int anoParsed = Int32.Parse(ano.textBox.Text);
                        if (anoParsed.ToString() == ano.textBox.Text)
                        {
                            if (anoParsed >= 1980 && anoParsed <= DateTime.Now.Year)
                            {
                                carro.Ano = anoParsed;
                            }
                            else
                            {
                                throw new ArgumentOutOfRangeException("Ano tem de ser um numero entre 1980 e " + DateTime.Now.Year);
                            }
                        }
                        else
                        {
                            throw new Exception("O ano tem de ser um número inteiro!");
                        }




                        //validar se quantRodas é numero inteiro
                        int quantRodasParsed = Int32.Parse(quantRodas.textBox.Text);
                        if (quantRodas.textBox.Text == quantRodasParsed.ToString())
                        {
                            carro.QuantRodas = Int32.Parse(quantRodas.textBox.Text);
                        }
                        else
                        {
                            throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                        }



                        //validar se valorDia é um valor decimal
                        float valorDiaParsed = float.Parse(valorDia.textBox.Text);
                        if(valorDiaParsed.ToString() == valorDia.textBox.Text)
                        {
                            carro.ValorDia = float.Parse(valorDia.textBox.Text);
                        }
                        else
                        {
                            throw new Exception("O valor tem de ser número decimal!");
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }


                    

                    //validar input da checkbox
                    if (isManual.checkBox.Checked)
                    {
                        carro.IsManual = true;
                    }
                    else
                    {
                        carro.IsManual = false;
                    }

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
                            validateEmptyString(c.Marca, marca.textBox.Text);
                            validateEmptyString(c.Modelo, modelo.textBox.Text);
                            validateEmptyString(c.Cor, cor.textBox.Text);
                            validateEmptyString(c.Matricula, matricula.textBox.Text);
                            try
                            {
                                //validar se ano é numero e se é um ano valido 
                                int anoParsed = Int32.Parse(ano.textBox.Text);
                                if (anoParsed.ToString() == ano.textBox.Text)
                                {
                                    if (anoParsed >= 1980 && anoParsed <= DateTime.Now.Year)
                                    {
                                        c.Ano = anoParsed;
                                    }
                                    else
                                    {
                                        throw new ArgumentOutOfRangeException("Ano tem de ser um numero entre 1980 e " + DateTime.Now.Year);
                                    }
                                }
                                else
                                {
                                    throw new Exception("O ano tem de ser um número inteiro!");
                                }



                                //validar se quantRodas é numero inteiro
                                int quantRodasParsed = Int32.Parse(quantRodas.textBox.Text);
                                if (quantRodas.textBox.Text == quantRodasParsed.ToString())
                                {
                                    c.QuantRodas = Int32.Parse(quantRodas.textBox.Text);
                                }
                                else
                                {
                                    throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                                }



                                //validar se quantDoors é numero inteiro
                                int quantDoorsParsed = Int32.Parse(quantDoors.textBox.Text);
                                if (quantDoors.textBox.Text == quantDoorsParsed.ToString())
                                {
                                    c.QuantDoors = Int32.Parse(quantDoors.textBox.Text);
                                }
                                else
                                {
                                    throw new Exception("A quantidade de portas tem de ser um número inteiro");
                                }



                                //validar se valorDia é um valor decimal
                                float valorDiaParsed = float.Parse(valorDia.textBox.Text);
                                if (valorDiaParsed.ToString() == valorDia.textBox.Text)
                                {
                                    c.ValorDia = float.Parse(valorDia.textBox.Text);
                                }
                                else
                                {
                                    throw new Exception("O valor tem de ser número decimal!");
                                }
                            }
                            catch (FormatException ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message);
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message);
                            }




                            //validar se isManual é um input bool
                            if (isManual.checkBox.Checked)
                            {
                                c.IsManual = true;
                            }
                            else
                            {
                                c.IsManual = false;
                            }
                            
                            break;
                        }
                    }
                }
                DAL.DAL.storeCarro();
                Empresa.ConvertObj(this.Parent.Parent).vehicleTable.FillData(Empresa.VehicleList);
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
