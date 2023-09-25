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
    internal class ClienteForm : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        private Cliente cliente = new Cliente();

        #region Child elements
        #endregion

        #region Constructors
        //Create contructors
        public ClienteForm()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.dark_emphasis;
        }

        public ClienteForm(int margin_top, int margin_right, int margin_bottom, int margin_left) : this()
        {
            _margin[0] = margin_top;
            _margin[1] = margin_right;
            _margin[2] = margin_bottom;
            _margin[3] = margin_left;
        }

        //Edit constructors
        public ClienteForm(Cliente c) : this()
        {
            cliente = c;
        }

        public ClienteForm(int margin_top, int margin_right, int margin_bottom, int margin_left, Cliente c) : this(c)
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

            int id = cliente.Id;

            InputBox nome = new InputBox();
            nome.label.Text = "Nome";
            this.Controls.Add(nome);
            nome.Size = new Size(this.Width / 2 - (25 * 2), nome.Height);
            nome.Location = new Point(25, 25);

            InputBox contacto = new InputBox();
            contacto.label.Text = "Contacto";
            this.Controls.Add(contacto);
            contacto.Size = new Size(this.Width / 2 - (25 * 2), contacto.Height);
            contacto.Location = new Point(this.Width / 2 + 25, 25);

            if (id != -1)
            {
                nome.textBox.Text = cliente.Nome;
                contacto.textBox.Text = cliente.Contacto;
            }

            FlatButton Submit = new FlatButton();
            Submit.Text = "Submit";
            Submit.Image = Image.FromFile("..\\..\\..\\assets\\icons\\submit.png");
            Submit.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Submit);

            //size/location before
            //Submit.Location = new Point(25, this.Height - Submit.Height - 25);
            //Submit.Size = new Size(this.Width / 2 - 2 * 25, Submit.Height);

            //size/location after
            Submit.Location = new Point(this.Width / 2 - this.Width / 4, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            Submit.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            Submit.BGC = ts.white;
            Submit.BGC_HOVER = ts.dark_emphasis;
            Submit.ForeColor = ts.dark;
            void submitClick(object sender, EventArgs e)
            {
                MessageBox.Show("Submit logic" + id);
                //validate inputs
                if (id == -1)
                {
                    cliente.Id = Emp.LastClienteId++;
                    cliente.Nome = nome.textBox.Text;
                    cliente.Contacto = contacto.textBox.Text;
                    Emp.AddCliente(cliente);
                }
                else
                {
                    //find obj and edit
                    int length = Emp.ClienteList.Count;
                    for (int i = 0; i < length; i++)
                    {
                        Cliente c = Emp.ConvertObj(Emp.ClienteList[i]);
                        if (c.Id == id)
                        {
                            c.Nome = nome.textBox.Text;
                            cliente.Contacto = contacto.textBox.Text;
                            break;
                        }
                    }
                }
                DAL.DAL.storeCliente();
                Emp.ConvertObj(this.Parent.Parent).clienteTable.FillData(Emp.ClienteList);
                Emp.clienteTable.FillData(Emp.ClienteList);
                var parent = this.Parent;
                parent.Controls.Remove(this);
            }
            Submit.Click += submitClick;

            FlatButton Cancel = new FlatButton();
            Cancel.Text = "Cancel";
            Cancel.Image = Image.FromFile("..\\..\\..\\assets\\icons\\cancelar.png");
            Cancel.TextAlign = ContentAlignment.BottomCenter;
            this.Controls.Add(Cancel);

            //size/location before
            //Cancel.Location = new Point(this.Width / 2 + 25, this.Height - Cancel.Height - 25);
            //Cancel.Size = new Size(this.Width / 2 - 2 * 25, Cancel.Height);

            //size/location after
            Cancel.Location = new Point(this.Width - this.Width / 2 + 25, this.Height / 2 + this.Width / 4 - 2 * 25 + 2 * 25);
            Cancel.Size = new Size(this.Width / 4 - 25, this.Width / 4 - 2 * 25);

            Cancel.BGC = ts.white;
            Cancel.BGC_HOVER = ts.dark_emphasis;
            Cancel.ForeColor = ts.dark;
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
