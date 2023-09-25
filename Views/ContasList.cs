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

            //Ganhos
            float ganhos = 0;
            foreach (AlugadoHist c in Emp.AlugadoHistList)
            {
                ganhos += c.Valor;
            }
            DetailBox ganhosBox = new DetailBox();
            ganhosBox.label.Text = "Ganhos:";
            ganhosBox.textBox.Text = $"{ganhos}€";
            this.Controls.Add(ganhosBox);
            ganhosBox.Location = new Point(100, 100);

            //Gastos
            float gastos = 0;
            foreach (ManutencaoHist c in Emp.ManutencaoHistList)
            {
                gastos += c.Valor;
            }
            DetailBox gastosBox = new DetailBox();
            gastosBox.label.Text = "Gastos:";
            gastosBox.textBox.Text = $"{gastos}€";
            this.Controls.Add(gastosBox);
            gastosBox.Location = new Point(100, 200);

            //Lucros
            float lucro = ganhos - gastos;
            DetailBox lucroBox = new DetailBox();
            lucroBox.label.Text = "Lucro:";
            lucroBox.textBox.Text = $"{lucro}€";
            this.Controls.Add(lucroBox);
            lucroBox.Location = new Point(100, 300);

            //Quantidade de reservas atuais
            DetailBox qReservas = new DetailBox();
            qReservas.label.Text = "Quantidade de Reservas:";
            qReservas.textBox.Text = $"{Emp.ReservadoList.Count}";
            qReservas.Size = new Size(qReservas.Width * 3, qReservas.Height);
            this.Controls.Add(qReservas);
            qReservas.Location = new Point(100, 400);

            //Quantidade de alugueres atuais
            DetailBox qAlugueres = new DetailBox();
            qAlugueres.label.Text = "Quantidade de Alugueres Ativos:";
            qAlugueres.textBox.Text = $"{Emp.AlugadoList.Count}";
            qAlugueres.Size = new Size(qAlugueres.Width * 3, qAlugueres.Height);
            this.Controls.Add(qAlugueres);
            qAlugueres.Location = new Point(100, 500);

            //Quantidade de alugueres terminados
            DetailBox qAlugueresHist = new DetailBox();
            qAlugueresHist.label.Text = "Quantidade de Alugueres terminados:";
            qAlugueresHist.textBox.Text = $"{Emp.AlugadoHistList.Count}";
            qAlugueresHist.Size = new Size(qAlugueresHist.Width * 3, qAlugueresHist.Height);
            this.Controls.Add(qAlugueresHist);
            qAlugueresHist.Location = new Point(100, 600);

            //Quantidade de manutençoes atuais
            DetailBox qManutencao = new DetailBox();
            qManutencao.label.Text = "Quantidade de Manutencoes Ativas:";
            qManutencao.textBox.Text = $"{Emp.ManutencaoList.Count}";
            qManutencao.Size = new Size(qManutencao.Width * 3, qManutencao.Height);
            this.Controls.Add(qManutencao);
            qManutencao.Location = new Point(100, 700);

            //Quantidade de manutençoes terminados
            DetailBox qManutencaoHist = new DetailBox();
            qManutencaoHist.label.Text = "Quantidade de Manutencoes Terminadas:";
            qManutencaoHist.textBox.Text = $"{Emp.ManutencaoHistList.Count}";
            qManutencaoHist.Size = new Size(qManutencaoHist.Width * 3, qManutencaoHist.Height);
            this.Controls.Add(qManutencaoHist);
            qManutencaoHist.Location = new Point(100, 800);

            //quantidade clientes
            DetailBox qClientes = new DetailBox();
            qClientes.label.Text = "Quantidade de Clientes:";
            qClientes.textBox.Text = $"{Emp.ClienteList.Count}";
            qClientes.Size = new Size(qClientes.Width * 3, qClientes.Height);
            this.Controls.Add(qClientes);
            qClientes.Location = new Point(100, 900);

            //quantidade veiculos / por tipo
            DetailBox qCarros = new DetailBox();
            qCarros.label.Text = "Quantidade de Carros:";
            qCarros.textBox.Text = $"{Emp.CarrosList.Count}";
            qCarros.Size = new Size(qCarros.Width * 3, qCarros.Height);
            this.Controls.Add(qCarros);
            qCarros.Location = new Point(100, 1000);

            DetailBox qMotas = new DetailBox();
            qMotas.label.Text = "Quantidade de Motas:";
            qMotas.textBox.Text = $"{Emp.MotasList.Count}";
            qMotas.Size = new Size(qMotas.Width * 3, qMotas.Height);
            this.Controls.Add(qMotas);
            qMotas.Location = new Point(100, 1100);

            DetailBox qCamioes = new DetailBox();
            qCamioes.label.Text = "Quantidade de Camioes:";
            qCamioes.textBox.Text = $"{Emp.CamioesList.Count}";
            qCamioes.Size = new Size(qCamioes.Width * 3, qCamioes.Height);
            this.Controls.Add(qCamioes);
            qCamioes.Location = new Point(100, 1200);

            DetailBox qCamionetas = new DetailBox();
            qCamionetas.label.Text = "Quantidade de Camionetas:";
            qCamionetas.textBox.Text = $"{Emp.CamionetasList.Count}";
            qCamionetas.Size = new Size(qCamionetas.Width * 3, qCamionetas.Height);
            this.Controls.Add(qCamionetas);
            qCamionetas.Location = new Point(100, 1300);


            //By nos

            #region Preset setup
            this.BringToFront();
            #endregion
        }
    }
}
