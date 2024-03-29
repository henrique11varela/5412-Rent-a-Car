﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Rent_a_Car.Views;
using Rent_a_Car.DAL;
using System.Diagnostics.Contracts;
using Rent_a_Car.Components.Tables;
using Rent_a_Car.Components.Menus;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Rent_a_Car.Classes
{
    internal static class Empresa
    {
        public static VehicleTable vehicleTable;
        public static AlugadoTable alugadoTable;
        public static ReservadoTable reservadoTable;
        public static ManutencaoTable manutencaoTable;
        public static ManutencaoHistTable manutencaoHistTable;
        public static AlugadoHistTable alugadoHistTable;
        public static ClienteTable clienteTable;
        public static StateListControls stateListControls;
        public static HistControls histControls;
        public static DateTime runDate;

        #region attributes
        private static int[] ids = new int[5];
        private static List<Camiao> camioes = new List<Camiao>();
        private static List<Camioneta> camionetas = new List<Camioneta>();
        private static List<Carro> carros = new List<Carro>();
        private static List<Mota> motas = new List<Mota>();
        private static List<Alugado> alugados = new List<Alugado>();
        private static List<AlugadoHist> alugadosHist = new List<AlugadoHist>();
        private static List<Manutencao> manutencao = new List<Manutencao>();
        private static List<ManutencaoHist> manutencaoHist = new List<ManutencaoHist>();
        private static List<Reservado> reservados = new List<Reservado>();
        private static List<Cliente> clientes = new List<Cliente>();
        #endregion

        #region getset
        public static ArrayList VehicleList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(camioes);
                arrayList.AddRange(camionetas);
                arrayList.AddRange(carros);
                arrayList.AddRange(motas);
                return arrayList;
            }
        }

        public static ArrayList CamioesList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(camioes);
                return arrayList;
            }
        }

        public static ArrayList CamionetasList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(camionetas);
                return arrayList;
            }
        }

        public static ArrayList CarrosList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(carros);
                return arrayList;
            }
        }

        public static ArrayList MotasList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(motas);
                return arrayList;
            }
        }

        public static ArrayList AlugadoList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(alugados);
                return arrayList;
            }
        }

        public static ArrayList ManutencaoList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(manutencao);
                return arrayList;
            }
        }

        public static ArrayList ReservadoList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(reservados);
                return arrayList;
            }
        }

        public static ArrayList ClienteList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(clientes);
                return arrayList;
            }
        }

        public static ArrayList ManutencaoHistList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(manutencaoHist);
                return arrayList;
            }
        }

        public static ArrayList AlugadoHistList
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(alugadosHist);
                return arrayList;
            }
        }

        public static int LastCarroId
        {
            get
            {
                return ids[0];
            }
            set
            {
                ids[0] = value;
            }
        }

        public static int LastCamiaoId
        {
            get
            {
                return ids[1];
            }
            set
            {
                ids[1] = value;
            }
        }

        public static int LastCamionetaId
        {
            get
            {
                return ids[2];
            }
            set
            {
                ids[2] = value;
            }
        }

        public static int LastMotaId
        {
            get
            {
                return ids[3];
            }
            set
            {
                ids[3] = value;
            }
        }

        public static int LastClienteId
        {
            get
            {
                return ids[4];
            }
            set
            {
                ids[4] = value;
            }
        }


        //Add Carro
        public static void AddCarro(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantDoors, bool isManual)
        {
            AddCarro(new Carro(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, quantDoors, isManual));
        }

        public static void AddCarro(Carro c)
        {
            carros.Add(c);

        }

        public static void RemoveCarro(Carro c)
        {
            carros.Remove(c);
        }

        //Add Camiao
        public static void AddCamiao(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, float maxWeight)
        {
            AddCamiao(new Camiao(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, maxWeight));
        }

        public static void AddCamiao(Camiao c)
        {
            camioes.Add(c);
        }

        public static void RemoveCamiao(Camiao c)
        {
            camioes.Remove(c);
        }

        //Add Camioneta
        public static void AddCamioneta(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantAxis, int maxPassengers)
        {
            AddCamioneta(new Camioneta(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, quantAxis, maxPassengers));
        }

        public static void AddCamioneta(Camioneta c)
        {
            camionetas.Add(c);
        }

        public static void RemoveCamioneta(Camioneta c)
        {
            camionetas.Remove(c);
        }

        //Add Mota
        public static void AddMota(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int cubicCapacity)
        {
            AddMota(new Mota(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, cubicCapacity));
        }

        public static void AddMota(Mota c)
        {
            motas.Add(c);
        }

        public static void RemoveMota(Mota m)
        {
            motas.Remove(m);
        }

        //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        public static void AddAlugado(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, int idCliente)
        {
            AddAlugado(new Alugado(idVeiculo, tipoVeiculo, dataInicio, dataPrevistaFim, idCliente));
        }

        public static void AddAlugado(Alugado a)
        {
            alugados.Add(a);
        }

        public static void RemoveAlugado(Alugado a)
        {
            alugados.Remove(a);
        }

        public static void AddManutencao(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, string problema)
        {
            AddManutencao(new Manutencao(idVeiculo, tipoVeiculo, dataInicio, dataPrevistaFim, problema));
        }

        public static void AddManutencao(Manutencao m)
        {
            manutencao.Add(m);
        }

        public static void RemoveManutencao(Manutencao m)
        {
            manutencao.Remove(m);
        }

        //OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        public static void AddReservado(int idVeiculo, string tipoVeiculo, int idCliente)
        {
            AddReservado(new Reservado(idVeiculo, tipoVeiculo, idCliente));
        }

        public static void AddReservado(Reservado r)
        {
            reservados.Add(r);
        }

        public static void RemoveReservado(Reservado r)
        {
            reservados.Remove(r);
        }

        public static void AddCliente(int id, string nome, string contacto)
        {
            AddCliente(new Cliente(id, nome, contacto));
        }

        public static void AddCliente(Cliente c)
        {
            clientes.Add(c);
        }

        public static void RemoveCliente(Cliente c)
        {
            clientes.Remove(c);
        }

        public static void AddManutencaoHist(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, string problema, float valor)
        {
            AddManutencaoHist(new ManutencaoHist(idVeiculo, tipoVeiculo, dataInicio, dataPrevistaFim, problema, valor));
        }

        public static void AddManutencaoHist(ManutencaoHist m)
        {
            manutencaoHist.Add(m);
        }

        public static void RemoveManutencaoHist(ManutencaoHist m)
        {
            manutencaoHist.Remove(m);
        }

        public static void AddAlugadoHist(int idVeiculo, string tipoVeiculo, DateTime dataInicio, DateTime dataPrevistaFim, int cliente, float valor)
        {
            AddAlugadoHist(new AlugadoHist(idVeiculo, tipoVeiculo, dataInicio, dataPrevistaFim, cliente, valor));
        }

        public static void AddAlugadoHist(AlugadoHist m)
        {
            alugadosHist.Add(m);
        }

        public static void RemoveAlugadoHist(AlugadoHist m)
        {
            alugadosHist.Remove(m);
        }
        #endregion

        #region methods

        public static dynamic ConvertObj(dynamic source)
        {
            return Convert.ChangeType(source, source.GetType());
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void InicialSetup()
        {
            carros = DAL.DAL.convertCarro();
            motas = DAL.DAL.convertMota();
            camioes = DAL.DAL.convertCamiao();
            camionetas = DAL.DAL.convertCamioneta();
            alugados = DAL.DAL.convertAlugado();
            manutencao = DAL.DAL.convertManutencao();
            manutencaoHist = DAL.DAL.convertManutencaoHist();
            alugadosHist = DAL.DAL.convertAlugadoHist();
            reservados = DAL.DAL.convertReservado();
            clientes = DAL.DAL.convertCliente();
        }

        #endregion

    }
}
