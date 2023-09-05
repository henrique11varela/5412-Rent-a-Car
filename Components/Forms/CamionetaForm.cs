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
    internal class CamionetaForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Camioneta camioneta = new Camioneta();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public CamionetaForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public CamionetaForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public CamionetaForm(Camioneta c) : this()
        {
            camioneta = c;
        }

        public CamionetaForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Camioneta c) : this(c)
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

            int id = camioneta.Id;

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

            InputBox maxPassengers = new InputBox();
            maxPassengers.label.Text = "maxPassengers";
            this.Controls.Add(maxPassengers);
            maxPassengers.Size = new Size(this.Width / 2 - (25 * 2), maxPassengers.Height);
            maxPassengers.Location = new Point(this.Width / 2 + 25, 25 + (25 + maxPassengers.Height) * 3);

            InputBox quantAxis = new InputBox();
            quantAxis.label.Text = "quantAxis";
            this.Controls.Add(quantAxis);
            quantAxis.Size = new Size(this.Width / 2 - (25 * 2), quantAxis.Height);
            quantAxis.Location = new Point(25, 25 + (25 + quantAxis.Height) * 4);

            if (id != -1)
            {
                marca.textBox.Text = camioneta.Marca;
                modelo.textBox.Text = camioneta.Modelo;
                cor.textBox.Text = camioneta.Cor;
                matricula.textBox.Text = camioneta.Matricula;
                ano.textBox.Text = camioneta.Ano.ToString();
                quantRodas.textBox.Text = camioneta.QuantRodas.ToString();
                valorDia.textBox.Text = camioneta.ValorDia.ToString();
                maxPassengers.textBox.Text = camioneta.MaxPassengers.ToString();
                quantAxis.textBox.Text = camioneta.QuantAxis.ToString();
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
                        if (prop.Length > 0)
                        {
                            prop = textBoxText;
                        }
                        else
                        {
                            throw new Exception("string vazia!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }

                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    validateEmptyString(camioneta.Marca, matricula.textBox.Text);
                    validateEmptyString(camioneta.Modelo, modelo.textBox.Text);
                    validateEmptyString(camioneta.Cor, cor.textBox.Text);
                    validateEmptyString(camioneta.Matricula, matricula.textBox.Text);
                    try
                    {
                        //validar se ano é numero e se é um ano valido 
                        int anoParsed = Int32.Parse(ano.textBox.Text);
                        if (anoParsed.ToString() == ano.textBox.Text)
                        {
                            if (anoParsed >= 1980 && anoParsed <= DateTime.Now.Year)
                            {
                                camioneta.Ano = anoParsed;
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
                            camioneta.QuantRodas = quantRodasParsed;
                        }
                        else
                        {
                            throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                        }



                        //validar se valorDia é um valor decimal
                        float valorDiaParsed = float.Parse(valorDia.textBox.Text);
                        if (valorDiaParsed.ToString() == valorDia.textBox.Text)
                        {
                            camioneta.ValorDia = valorDiaParsed;
                        }
                        else
                        {
                            throw new Exception("O valor tem de ser número decimal!");
                        }


                        //validar se MaxPassengers é numero inteiro
                        int maxPassengersParsed = Int32.Parse(maxPassengers.textBox.Text);
                        if (maxPassengers.textBox.Text == maxPassengersParsed.ToString())
                        {
                            camioneta.MaxPassengers = maxPassengersParsed;
                        }
                        else
                        {
                            throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                        }


                        //validar se quantAxis é numero inteiro
                        int quantAxisParsed = Int32.Parse(quantAxis.textBox.Text);
                        if (quantAxis.textBox.Text == quantAxis.ToString())
                        {
                            camioneta.QuantAxis = quantAxisParsed;
                        }
                        else
                        {
                            throw new Exception("A quantidade de rodas tem de ser um número inteiro");
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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                    Emp.AddCamioneta(camioneta);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.CamionetasList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Camioneta c = Emp.ConvertObj(Emp.CamionetasList[i]);
                        if (c.Id == id)
                        {
                            validateEmptyString(camioneta.Marca, matricula.textBox.Text);
                            validateEmptyString(camioneta.Modelo, modelo.textBox.Text);
                            validateEmptyString(camioneta.Cor, cor.textBox.Text);
                            validateEmptyString(camioneta.Matricula, matricula.textBox.Text);
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
                                    c.QuantRodas = quantRodasParsed;
                                }
                                else
                                {
                                    throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                                }



                                //validar se valorDia é um valor decimal
                                float valorDiaParsed = float.Parse(valorDia.textBox.Text);
                                if (valorDiaParsed.ToString() == valorDia.textBox.Text)
                                {
                                    c.ValorDia = valorDiaParsed;
                                }
                                else
                                {
                                    throw new Exception("O valor tem de ser número decimal!");
                                }


                                //validar se MaxPassengers é numero inteiro
                                int maxPassengersParsed = Int32.Parse(maxPassengers.textBox.Text);
                                if (maxPassengers.textBox.Text == maxPassengersParsed.ToString())
                                {
                                    c.MaxPassengers = maxPassengersParsed;
                                }
                                else
                                {
                                    throw new Exception("A quantidade de rodas tem de ser um número inteiro");
                                }


                                //validar se quantAxis é numero inteiro
                                int quantAxisParsed = Int32.Parse(quantAxis.textBox.Text);
                                if (quantAxis.textBox.Text == quantAxis.ToString())
                                {
                                    c.QuantAxis = quantAxisParsed;
                                }
                                else
                                {
                                    throw new Exception("A quantidade de rodas tem de ser um número inteiro");
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
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro: " + ex.Message);
                            }
                            break;
                        }
                    }
                }
                DAL.DAL.storeCamioneta();
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
