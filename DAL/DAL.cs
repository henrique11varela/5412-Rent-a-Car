using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Rent_a_Car.Classes;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rent_a_Car.DAL
{
    internal static class DAL
    {
        #region ALL
        public static void readAll()
        {
            csvCarro.read();
            csvMota.read();
            csvCamioneta.read();
            csvCamiao.read();
            csvManutencao.read();
            csvAlugado.read();
            csvReservado.read();
            csvHistmanutencao.read();
            csvHistalugado.read();
            csvCliente.read();
            csvIds.read();
        }
        public static void writeAll()
        {
            csvCarro.write();
            csvMota.write();
            csvCamioneta.write();
            csvCamiao.write();
            csvManutencao.write();
            csvAlugado.write();
            csvReservado.write();
            csvHistmanutencao.write();
            csvHistalugado.write();
            csvCliente.write();
            csvIds.write();
        }
        #endregion

        #region From matrix to obj list

        public static List<Carro> convertCarro()
        {
            List<Carro> list = new List<Carro>();
            if (csvCarro.Carro.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCarro.Carro)
            {
                //status, freeExpect
                string status = "Livre";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Carro(Int32.Parse(item[0]), item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[2].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[3].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[4]), item[5].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8]), Boolean.Parse(item[9])));
            }
            return list;
        }

        //csvMota;
        public static List<Mota> convertMota()
        {
            List<Mota> list = new List<Mota>();
            if (csvMota.Mota.Count < 1)
            {
                return list;
            }
            foreach (var item in csvMota.Mota)
            {
                //status, freeExpect
                string status = "Livre";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Mota(Int32.Parse(item[0]), item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[2].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[3].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[4]), item[5], Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8])));
            }
            return list;
        }

        //csvCamiao;
        public static List<Camiao> convertCamiao()
        {
            List<Camiao> list = new List<Camiao>();
            if (csvCamiao.Camiao.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCamiao.Camiao)
            {
                //status, freeExpect
                string status = "Livre";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Camiao(Int32.Parse(item[0]), item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[2].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[3].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[4]), item[5].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), float.Parse(item[8])));
            }
            return list;
        }

        //csvCamioneta;
        public static List<Camioneta> convertCamioneta()
        {
            List<Camioneta> list = new List<Camioneta>();
            if (csvCamioneta.Camioneta.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCamioneta.Camioneta)
            {
                //status, freeExpect
                string status = "Livre";
                DateTime freeExpect = DateTime.Now;
                //DateTime freeExpect = DateTime.ParseExact(strDate, "O", CultureInfo.InvariantCulture);
                list.Add(new Camioneta(Int32.Parse(item[0]), item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[2].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), item[3].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[4]), item[5].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), Int32.Parse(item[6]), status, freeExpect, float.Parse(item[7]), Int32.Parse(item[8]), Int32.Parse(item[9])));
            }
            return list;
        }



        //csvAlugado;
        public static List<Alugado> convertAlugado()
        {
            List<Alugado> list = new List<Alugado>();
            if (csvAlugado.Alugado.Count < 1)
            {
                return list;
            }
            foreach (var item in csvAlugado.Alugado)
            {
                string tipo = item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";");
                DateTime freeExpect = DateTime.ParseExact(item[3], "d", CultureInfo.InvariantCulture);
                list.Add(new Alugado(Int32.Parse(item[0]), tipo, DateTime.ParseExact(item[2], "d", CultureInfo.InvariantCulture), freeExpect, Int32.Parse(item[4])));
                if (tipo == "Carro")
                {
                    foreach (Carro carro in Empresa.CarrosList)
                    {
                        if (carro.Id == Int32.Parse(item[0]))
                        {
                            carro.Status = "Alugado";
                            carro.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Camiao")
                {
                    foreach (Camiao camiao in Empresa.CamioesList)
                    {
                        if (camiao.Id == Int32.Parse(item[0]))
                        {
                            camiao.Status = "Alugado";
                            camiao.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Camioneta")
                {
                    foreach (Camioneta camioneta in Empresa.CamionetasList)
                    {
                        if (camioneta.Id == Int32.Parse(item[0]))
                        {
                            camioneta.Status = "Alugado";
                            camioneta.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Mota")
                {
                    foreach (Mota mota in Empresa.MotasList)
                    {
                        if (mota.Id == Int32.Parse(item[0]))
                        {
                            mota.Status = "Alugado";
                            mota.FreeExpect = freeExpect;
                        }
                    }
                }
            }
            return list;
        }

        //csvManutencao;
        public static List<Manutencao> convertManutencao()
        {
            List<Manutencao> list = new List<Manutencao>();
            if (csvManutencao.Manutencao.Count < 1)
            {
                return list;
            }
            foreach (var item in csvManutencao.Manutencao)
            {
                string tipo = item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";");
                DateTime freeExpect = DateTime.ParseExact(item[3], "d", CultureInfo.InvariantCulture);
                list.Add(new Manutencao(Int32.Parse(item[0]), tipo, DateTime.ParseExact(item[2], "d", CultureInfo.InvariantCulture), freeExpect, item[4].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";")));
                if (tipo == "Carro")
                {
                    foreach (Carro carro in Empresa.CarrosList)
                    {
                        if (carro.Id == Int32.Parse(item[0]))
                        {
                            carro.Status = "Manutencao";
                            carro.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Camiao")
                {
                    foreach (Camiao camiao in Empresa.CamioesList)
                    {
                        if (camiao.Id == Int32.Parse(item[0]))
                        {
                            camiao.Status = "Manutencao";
                            camiao.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Camioneta")
                {
                    foreach (Camioneta camioneta in Empresa.CamionetasList)
                    {
                        if (camioneta.Id == Int32.Parse(item[0]))
                        {
                            camioneta.Status = "Manutencao";
                            camioneta.FreeExpect = freeExpect;
                        }
                    }
                }
                else if (tipo == "Mota")
                {
                    foreach (Mota mota in Empresa.MotasList)
                    {
                        if (mota.Id == Int32.Parse(item[0]))
                        {
                            mota.Status = "Manutencao";
                        mota.FreeExpect = freeExpect;
                        }
                    }
                }
            }
            return list;
        }

        //csvReservado;
        public static List<Reservado> convertReservado()
        {
            List<Reservado> list = new List<Reservado>();
            if (csvReservado.Reservado.Count < 1)
            {
                return list;
            }
            foreach (var item in csvReservado.Reservado)
            {
                string tipo = item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";");
                list.Add(new Reservado(Int32.Parse(item[0]), tipo, Int32.Parse(item[2])));
                if (tipo == "Carro")
                {
                    foreach (Carro carro in Empresa.CarrosList)
                    {
                        if (carro.Id == Int32.Parse(item[0]))
                        {
                            carro.Status = "Reservado";
                        }
                    }
                }
                else if (tipo == "Camiao")
                {
                    foreach (Camiao camiao in Empresa.CamioesList)
                    {
                        if (camiao.Id == Int32.Parse(item[0]))
                        {
                            camiao.Status = "Reservado";
                        }
                    }
                }
                else if (tipo == "Camioneta")
                {
                    foreach (Camioneta camioneta in Empresa.CamionetasList)
                    {
                        if (camioneta.Id == Int32.Parse(item[0]))
                        {
                            camioneta.Status = "Reservado";
                        }
                    }
                }
                else if (tipo == "Mota")
                {
                    foreach (Mota mota in Empresa.MotasList)
                    {
                        if (mota.Id == Int32.Parse(item[0]))
                        {
                            mota.Status = "Reservado";
                        }
                    }
                }
            }
            return list;
        }

        //csvCliente;
        public static List<Cliente> convertCliente()
        {
            List<Cliente> list = new List<Cliente>();
            if (csvCliente.Clientes.Count < 1)
            {
                return list;
            }
            foreach (var item in csvCliente.Clientes)
            {
                list.Add(new Cliente(Int32.Parse(item[0]), item[1], item[2]));
            }
            return list;
        }

        //csvHistmanutencao;
        public static List<ManutencaoHist> convertManutencaoHist()
        {
            List<ManutencaoHist> list = new List<ManutencaoHist>();
            if (csvHistmanutencao.Histmanutencao.Count < 1)
            {
                return list;
            }
            foreach (var item in csvHistmanutencao.Histmanutencao)
            {
                string tipo = item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";");
                DateTime free = DateTime.ParseExact(item[3], "d", CultureInfo.InvariantCulture);
                list.Add(new ManutencaoHist(Int32.Parse(item[0]), tipo, DateTime.ParseExact(item[2], "d", CultureInfo.InvariantCulture), free, item[4].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";"), float.Parse(item[5])));
            }
            return list;
        }

        //csvHistalugado;
        public static List<AlugadoHist> convertAlugadoHist()
        {
            List<AlugadoHist> list = new List<AlugadoHist>();
            if (csvHistalugado.Histalugado.Count < 1)
            {
                return list;
            }
            foreach (var item in csvHistalugado.Histalugado)
            {
                string tipo = item[1].Replace(" || ", "\n").Replace(" ||| ", ",").Replace(" |||| ", ";");
                DateTime free = DateTime.ParseExact(item[3], "d", CultureInfo.InvariantCulture);
                list.Add(new AlugadoHist(Int32.Parse(item[0]), tipo, DateTime.ParseExact(item[2], "d", CultureInfo.InvariantCulture), free, Int32.Parse(item[4]), float.Parse(item[5])));
            }
            return list;
        }

        //string strDate = now1.ToString(FMT);
            #endregion

        #region From obj list to matrix

        public static void storeCarro()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CarrosList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Modelo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Cor.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).QuantDoors.ToString());
                line.Add(Empresa.ConvertObj(item).IsManual.ToString());
                list.Add(line);
            }
            csvCarro.Carro = list;
        }

        public static void storeMota()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.MotasList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Modelo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Cor.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).CubicCapacity.ToString());
                list.Add(line);
            }
            csvMota.Mota = list;
        }

        public static void storeCamiao()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CamioesList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Modelo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Cor.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).MaxWeight.ToString());
                list.Add(line);
            }
            csvCamiao.Camiao = list;
        }

        public static void storeCamioneta()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.CamionetasList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Marca.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Modelo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Cor.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).QuantRodas.ToString());
                line.Add(Empresa.ConvertObj(item).Matricula.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Ano.ToString());
                line.Add(Empresa.ConvertObj(item).ValorDia.ToString());
                line.Add(Empresa.ConvertObj(item).QuantAxis.ToString());
                line.Add(Empresa.ConvertObj(item).MaxPassengers.ToString());
                list.Add(line);
            }
            csvCamioneta.Camioneta = list;
        }

        public static void storeAlugado()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.AlugadoList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).IdVeiculo.ToString());
                line.Add(Empresa.ConvertObj(item).TipoVeiculo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).DataInicio.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).DataPrevistaFim.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).IdCliente.ToString());
                list.Add(line);
            }
            csvAlugado.Alugado = list;
        }

        public static void storeManutencao()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.ManutencaoList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).IdVeiculo.ToString());
                line.Add(Empresa.ConvertObj(item).TipoVeiculo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).DataInicio.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).DataPrevistaFim.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).Problema.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                list.Add(line);
            }
            csvManutencao.Manutencao = list;
        }

        public static void storeReservado()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.ReservadoList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).IdVeiculo.ToString());
                line.Add(Empresa.ConvertObj(item).TipoVeiculo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).IdCliente.ToString());
                list.Add(line);
            }
            csvReservado.Reservado = list;
        }

        public static void storeCliente()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.ClienteList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).Id.ToString());
                line.Add(Empresa.ConvertObj(item).Nome.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Contacto.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                list.Add(line);
            }
            csvCliente.Clientes = list;
        }

        public static void storeManutencaoHist()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.ManutencaoHistList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).IdVeiculo.ToString());
                line.Add(Empresa.ConvertObj(item).TipoVeiculo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).DataInicio.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).DataFim.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).Problema.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).Valor.ToString());
                list.Add(line);
            }
            csvHistmanutencao.Histmanutencao = list;
        }

        public static void storeAlugadoHist()
        {
            List<List<string>> list = new List<List<string>>();
            foreach (var item in Empresa.AlugadoHistList)
            {
                List<string> line = new List<string>();
                line.Add(Empresa.ConvertObj(item).IdVeiculo.ToString());
                line.Add(Empresa.ConvertObj(item).TipoVeiculo.Replace("\n", " || ").Replace(",", " ||| ").Replace(";", " |||| ").Replace("\r", " || "));
                line.Add(Empresa.ConvertObj(item).DataInicio.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).DataFim.ToString("d", CultureInfo.InvariantCulture));
                line.Add(Empresa.ConvertObj(item).IdCliente.ToString());
                line.Add(Empresa.ConvertObj(item).Valor.ToString());
                list.Add(line);
            }
            csvHistalugado.Histalugado = list;
        }


        //string strDate = now1.ToString(FMT);
        #endregion

    }
}
