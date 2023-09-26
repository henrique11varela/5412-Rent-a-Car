using Rent_a_Car.Classes;
using Rent_a_Car.Components.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleTable = Rent_a_Car.Components.Tables.VehicleTable;
using CarForm = Rent_a_Car.Components.Forms.CarroForm;
using Emp = Rent_a_Car.Classes.Empresa;
using ts = Rent_a_Car.ThemeScheme;
using Rent_a_Car.Components;
using Rent_a_Car.Components.Buttons;
using Rent_a_Car.Components.Menus;
using Rent_a_Car.Components.Input;

namespace Rent_a_Car.Views
{
    internal class ContasList : Panel
    {
        private int[] _margin = { 0, 0, 0, 0 };
        #region Child elements
        public AlugadoHistTable alugadoHistTable;
        public ManutencaoHistTable manutencaoHistTable;
        #endregion

        public ContasList()
        {
            this.ParentChanged += Setup;
            this.BackColor = ts.light;

            void updateView(Object sender, EventArgs e) {
                this.Controls.Clear();
                Setup(sender, e);
            }
            this.VisibleChanged += updateView;
        }

        /// <summary>
        /// Event that places element after instance is created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            Label pageTitle = new Label();
            pageTitle.Text = "Lista de Contas";
            pageTitle.TextAlign = ContentAlignment.TopCenter;
            pageTitle.Font = ts.largeFont;
            pageTitle.Size = new Size(TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width, pageTitle.Font.Height);
            pageTitle.Location = new Point((this.Width - TextRenderer.MeasureText(pageTitle.Text, pageTitle.Font).Width) / 2, pageTitle.Font.Height);
            this.Controls.Add(pageTitle);

            var content = this.Height - pageTitle.Height * 3;

            //Ganhos
            float ganhos = 0;
            foreach (AlugadoHist c in Emp.AlugadoHistList)
            {
                ganhos += c.Valor;
            }
            DetailBox ganhosBox = new DetailBox();
            ganhosBox.label.Text = "Ganhos:";
            ganhosBox.textBox.Text = $"{ganhos}€";
            ganhosBox.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(ganhosBox);
            Size DBsize = new Size(this.Width / 3 - 50 * 2, ganhosBox.Height);
            ganhosBox.Size = DBsize;
            ganhosBox.Location = new Point(this.Width / 3 + 50, content / 5 - ganhosBox.Height);

            //Gastos
            float gastos = 0;
            foreach (ManutencaoHist c in Emp.ManutencaoHistList)
            {
                gastos += c.Valor;
            }
            DetailBox gastosBox = new DetailBox();
            gastosBox.label.Text = "Gastos:";
            gastosBox.textBox.Text = $"{gastos}€";
            gastosBox.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(gastosBox);
            gastosBox.Size = DBsize;
            gastosBox.Location = new Point(this.Width / 3 + 50, content / 5 * 2 - gastosBox.Height);

            //Lucros
            float lucro = ganhos - gastos;
            DetailBox lucroBox = new DetailBox();
            lucroBox.label.Text = "Lucro:";
            lucroBox.textBox.Text = $"{lucro}€";
            lucroBox.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(lucroBox);
            lucroBox.Size = DBsize;
            lucroBox.Location = new Point(this.Width / 3 + 50, content / 5 * 3 - lucroBox.Height);

            //Quantidade de reservas atuais
            DetailBox qReservas = new DetailBox();
            qReservas.label.Text = "Quantidade de Reservas:";
            qReservas.textBox.Text = $"{Emp.ReservadoList.Count}";
            qReservas.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(qReservas);
            qReservas.Size = DBsize;
            qReservas.Location = new Point(50, content / 5 - qReservas.Height);

            //Quantidade de alugueres atuais
            DetailBox qAlugueres = new DetailBox();
            qAlugueres.label.Text = "Quantidade de Alugueres Ativos:";
            qAlugueres.textBox.Text = $"{Emp.AlugadoList.Count}";
            qAlugueres.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(qAlugueres);
            qAlugueres.Size = DBsize;
            qAlugueres.Location = new Point(50, content / 5 * 2 - qAlugueres.Height);

            //Quantidade de alugueres terminados
            DetailBox qAlugueresHist = new DetailBox();
            qAlugueresHist.label.Text = "Quantidade de Alugueres terminados:";
            qAlugueresHist.textBox.Text = $"{Emp.AlugadoHistList.Count}";
            qAlugueresHist.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(qAlugueresHist);
            qAlugueresHist.Size = DBsize;
            qAlugueresHist.Location = new Point(50, content / 5 * 3 - qAlugueresHist.Height);

            //Quantidade de manutençoes atuais
            DetailBox qManutencao = new DetailBox();
            qManutencao.label.Text = "Quantidade de Manutencoes Ativas:";
            qManutencao.textBox.Text = $"{Emp.ManutencaoList.Count}";
            qManutencao.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(qManutencao);
            qManutencao.Size = DBsize;
            qManutencao.Location = new Point(50, content / 5 * 4 - qManutencao.Height);

            //Quantidade de manutençoes terminados
            DetailBox qManutencaoHist = new DetailBox();
            qManutencaoHist.label.Text = "Quantidade de Manutencoes Terminadas:";
            qManutencaoHist.textBox.Text = $"{Emp.ManutencaoHistList.Count}";
            qManutencaoHist.textBox.TextAlign = HorizontalAlignment.Center;
            this.Controls.Add(qManutencaoHist);
            qManutencaoHist.Size = DBsize;
            qManutencaoHist.Location = new Point(50, content - qManutencaoHist.Height);

            //quantidade clientes
            DetailBox qClientes = new DetailBox();
            qClientes.label.Text = "Quantidade de Clientes:";
            qClientes.textBox.Text = $"{Emp.ClienteList.Count}";
            qClientes.textBox.TextAlign = HorizontalAlignment.Center;
            qClientes.Size = new Size(qClientes.Width * 3, qClientes.Height);
            this.Controls.Add(qClientes);
            qClientes.Size = DBsize;
            qClientes.Location = new Point(2 * this.Width / 3 + 50, content / 5 - qClientes.Height);

            //quantidade veiculos / por tipo
            DetailBox qCarros = new DetailBox();
            qCarros.label.Text = "Quantidade de Carros:";
            qCarros.textBox.Text = $"{Emp.CarrosList.Count}";
            qCarros.textBox.TextAlign = HorizontalAlignment.Center;
            qCarros.Size = new Size(qCarros.Width * 3, qCarros.Height);
            this.Controls.Add(qCarros);
            qCarros.Size = DBsize;
            qCarros.Location = new Point(2 * this.Width / 3 + 50, content / 5 * 4 - qCarros.Height);

            DetailBox qMotas = new DetailBox();
            qMotas.label.Text = "Quantidade de Motas:";
            qMotas.textBox.Text = $"{Emp.MotasList.Count}";
            qMotas.textBox.TextAlign = HorizontalAlignment.Center;
            qMotas.Size = new Size(qMotas.Width * 3, qMotas.Height);
            this.Controls.Add(qMotas);
            qMotas.Size = DBsize;
            qMotas.Location = new Point(2 * this.Width / 3 + 50, content - qMotas.Height);

            DetailBox qCamioes = new DetailBox();
            qCamioes.label.Text = "Quantidade de Camioes:";
            qCamioes.textBox.Text = $"{Emp.CamioesList.Count}";
            qCamioes.textBox.TextAlign = HorizontalAlignment.Center;
            qCamioes.Size = new Size(qCamioes.Width * 3, qCamioes.Height);
            this.Controls.Add(qCamioes);
            qCamioes.Size = DBsize;
            qCamioes.Location = new Point(2 * this.Width / 3 + 50, content / 5 * 2 - qCamioes.Height);

            DetailBox qCamionetas = new DetailBox();
            qCamionetas.label.Text = "Quantidade de Camionetas:";
            qCamionetas.textBox.Text = $"{Emp.CamionetasList.Count}";
            qCamionetas.textBox.TextAlign = HorizontalAlignment.Center;
            qCamionetas.Size = new Size(qCamionetas.Width * 3, qCamionetas.Height);
            this.Controls.Add(qCamionetas);
            qCamionetas.Size = DBsize;
            qCamionetas.Location = new Point(2 * this.Width / 3 + 50, content / 5 * 3 - qCamionetas.Height);


            //By nos

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
