using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Rent_a_Car.Views;

namespace Rent_a_Car.Classes
{
    internal class Empresa
    {
        #region attributes
        private List<Camiao> camioes = new List<Camiao>();
        private List<Camioneta> camionetas = new List<Camioneta>();
        private List<Carro> carros = new List<Carro>();
        private List<Mota> motas = new List<Mota>();
        #endregion


        public void blabla(Label a, ArrayList b) {
            a.Text = b[0].GetType().Name;
        }

        #region getset
        public ArrayList VeicleList
        {
            get
            {
                //ArrayList sortArrayListById(ArrayList inputList) { 
                //    ArrayList beforeList = new ArrayList();
                //    ArrayList afterList = new ArrayList();
                //    Type currType = inputList[0].GetType();
                //    currType currentItem;
                //    int length = inputList.Count;
                //    for (int i = 1; i < length; i++)
                //    {
                //        if (((Camiao)inputList[i]).Id < ((currType)currentItem).Id)
                //        {
                //            beforeList.Add(inputList[i]);
                //        }
                //        else if (inputList[i].Id > currentItem.Id)
                //        {
                //            afterList.Add(inputList[i]);
                //        }
                //    }

                //    ArrayList parentList = new ArrayList();
                //    parentList.AddRange(beforeList);
                //    //parentList.Add(currentItem);
                //    parentList.AddRange(afterList);
                //    return parentList;
                //}
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(camioes);
                arrayList.AddRange(camionetas);
                arrayList.AddRange(carros);
                arrayList.AddRange(motas);
                
                return arrayList;
            }
        }
        public ArrayList VeicleList_SortedById
        {
            get
            {
                ArrayList arrayList = new ArrayList();
                arrayList.AddRange(camioes);
                arrayList.AddRange(camionetas);
                arrayList.AddRange(carros);
                arrayList.AddRange(motas);

                arrayList.Add(new Camiao());

                return arrayList;
            }
        }
        #endregion

        #region constructors

        public Empresa() {

        }

        #endregion

    }
}
