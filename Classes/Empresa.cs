﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Rent_a_Car.Views;

namespace Rent_a_Car.Classes
{
    internal static class Empresa
    {
        #region attributes
        private static List<Camiao> camioes = new List<Camiao>();
        private static List<Camioneta> camionetas = new List<Camioneta>();
        private static List<Carro> carros = new List<Carro>();
        private static List<Mota> motas = new List<Mota>();
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
        
        //Add Carro
        public static void AddCarro(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantDoors, bool isManual)
        {
            carros.Add(new Carro(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, quantDoors, isManual));
        }
        
        public static void AddCarro(Carro c)
        {
            carros.Add(new Carro(c));
        }
        
        //Add Camiao
        public static void AddCamiao(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, float maxWeight)
        {
            camioes.Add(new Camiao(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, maxWeight));
        }
        
        public static void AddCamiao(Camiao c)
        {
            camioes.Add(new Camiao(c));
        }
        
        //Add Camioneta
        public static void AddCamioneta(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int quantAxis, int maxPassengers)
        {
            camionetas.Add(new Camioneta(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, quantAxis, maxPassengers));
        }
        
        public static void AddCamioneta(Camioneta c)
        {
            camionetas.Add(new Camioneta(c));
        }
        
        //Add Mota
        public static void AddMota(int id, string marca, string modelo, string cor, int quantRodas, string matricula, int ano, string status, DateTime freeExpect, float valorDia, int cubicCapacity)
        {
            motas.Add(new Mota(id, marca, modelo, cor, quantRodas, matricula, ano, status, freeExpect, valorDia, cubicCapacity));
        }
        
        public static void AddMota(Mota c)
        {
            motas.Add(new Mota(c));
        }
        #endregion

        #region methods

        public static dynamic ConvertObj(dynamic source)
        {
            return Convert.ChangeType(source, source.GetType());
        }

        #endregion

    }
}
