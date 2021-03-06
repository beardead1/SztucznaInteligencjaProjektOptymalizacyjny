using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_plecakowy
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            List<Paczka> paczka = new List<Paczka>();
            var lines = System.IO.File.ReadAllLines("baza.csv");
            lines = lines.Skip(1).ToArray();
            int licz_foreach = 0;
            int obj = 0; 
            foreach (var item in lines)
            {
                var values = item.Split(';');
                int lp = Convert.ToInt32(values[0]);
                String id = values[1];
                int wysokosc = Convert.ToInt32(values[2]);
                int szerokosc = Convert.ToInt32(values[3]);
                int dlugosc = Convert.ToInt32(values[4]);
                int waga = Convert.ToInt32(values[5]);

                Paczka paczka1 = new Paczka(lp, id, wysokosc, szerokosc, dlugosc, waga);
                paczka.Add(paczka1);
            }

            // Nowa lista:
            List<Paczka> paczka_new = new List<Paczka>();

            int objetosc = 1614800;
            List<List<Paczka>> HM = new List<List<Paczka>>();
            int HMS = 15;
            List<int> FP = new List<int>();            //fitness dla każdego rozwiązania
            List<int> FP_2 = new List<int>();            //fitness dla nowych rozwiązań

            List<Paczka> nowe_rozwiazania = new List<Paczka>();



            for (int x = 0; x < HMS; x++)
            {
                rozwiazania();

                List<Paczka> pomocnicza = new List<Paczka>(paczka_new);
                //dodaj rozwiązania
                FP.Add(paczka_new.Count);
                HM.Add(pomocnicza);
                paczka_new.Clear();
            }


           for(int z = 0; z < HMS; z++)
            {
                Console.WriteLine(FP[z]);
            }





            int HMCR = 70;

            int iteracje = 10000;


            List<List<Paczka>> HM_nowe = new List<List<Paczka>>();
            for (int g = 0; g < iteracje; g++)
            {
                int r1 = rand.Next(100);

                if (r1 < 70)
                {
                    //szukamy nowego rozwiązania z pamięci algorytmu
                   nowe_rozwiazania.Clear();
                   rozwiazania_z_naszego();
                   List<Paczka> pomoc = new List<Paczka>(nowe_rozwiazania);


                    int r2 = rand.Next(100);
                    if (r2 < 15)
                    {
                        mutacja();
                    }



                   HM_nowe.Add(pomoc);
                   FP_2.Add(nowe_rozwiazania.Count); 
                   
                }


                
                else
                {
                    paczka_new.Clear();
                    rozwiazania();
                    List<Paczka> pomoc2 = new List<Paczka>(paczka_new);
                    HM_nowe.Add(pomoc2);
                    FP_2.Add(paczka_new.Count);
                }

                int fitness_worst = 999;
                int jaki_index_to_najmniejszy_finess = 0;
                for (int l = 0; l < 15; l++)
                {
                    if(FP[l] < fitness_worst)
                    {
                        fitness_worst = FP[l];
                        jaki_index_to_najmniejszy_finess = l;
                    }
                }
                
                HM[jaki_index_to_najmniejszy_finess] = HM_nowe[g];
                FP[jaki_index_to_najmniejszy_finess] = FP_2[g]; 

            } 



            void rozwiazania() {

                int waga1 = 0;
                obj = 0;
                

                //POPRAWIĆ  dać IFa, żeby nie przekraczało wagi i obj.
                for (int j = 0; waga1 <= 1000 || obj < objetosc; j++)
                {
                    int losowa = rand.Next(10000);
                    paczka_new.Add(paczka[losowa]);
                    //zabezpieczenie przed dodaniem paczki przekraczającą wagę
                    if (waga1 + paczka_new[j].Waga > 1000) { break; }
                    waga1 = waga1 + paczka_new[j].Waga;
                    //zabezpieczenie przed dodaniem paczki przekraczającą objętość
                    if (obj + (paczka_new[j].Dlugosc * (paczka_new[j].Szerokosc * paczka_new[j].Wysokosc)) > 1614800) { break; }
                    obj = obj + (paczka_new[j].Dlugosc * (paczka_new[j].Szerokosc * paczka_new[j].Wysokosc));
                }
                //paczka_new.Remove(paczka_new[paczka_new.Count - 1]);
            }


            void rozwiazania_z_naszego()
            {

                int waga1 = 0;
                obj = 0;


                //POPRAWIĆ  dać IFa, żeby nie przekraczało wagi i obj.
                for (int j = 0; waga1 <= 1000 || obj < objetosc; j++)
                {
                    int losowa = rand.Next(15);
                   
                    nowe_rozwiazania.Add(HM[losowa][rand.Next(HM[losowa].Count)]);

                    //zabezpieczenie przed dodaniem paczki przekraczającą wagę
                    if (waga1 + nowe_rozwiazania[j].Waga > 1000) { break; }
                    waga1 = waga1 + nowe_rozwiazania[j].Waga;
                    //zabezpieczenie przed dodaniem paczki przekraczającą objętość
                    if (obj + (nowe_rozwiazania[j].Dlugosc * (nowe_rozwiazania[j].Szerokosc * nowe_rozwiazania[j].Wysokosc)) > 1614800) { break; }
                    obj = obj + (nowe_rozwiazania[j].Dlugosc * (nowe_rozwiazania[j].Szerokosc * nowe_rozwiazania[j].Wysokosc));
                }
                //nowe_rozwiazania.Remove(nowe_rozwiazania[nowe_rozwiazania.Count - 1]);
            }




            void mutacja()
            {
                int losowa_usun = rand.Next(nowe_rozwiazania.Count());
                nowe_rozwiazania.RemoveAt(losowa_usun);
                


                for (int temp = 0; temp>0;)
                { 
                    
                    int losowa = rand.Next(10000);

                    if ((obj + (paczka[losowa].Dlugosc * paczka[losowa].Szerokosc * paczka[losowa].Wysokosc)) < 10000)
                    {
                        nowe_rozwiazania.Add(paczka[losowa]);
                        temp = 1;
                    }
                    else temp = 0;
                }



                

            }



            Console.WriteLine("------------");
            for (int p = 0; p<FP.Count; p++)
            {
                Console.WriteLine(FP[p]);
            }


            foreach (List<Paczka> test in HM)
            {
                Console.WriteLine("---------- W PACZCE SIE ZNAJDUJĄ: ----------");
                foreach (Paczka test1 in test)
                {
                    Console.WriteLine("ROZWIĄZANIE:");
                    Console.WriteLine("dl: "+ test1.Dlugosc + " szer: " + test1.Szerokosc + " wys: " + test1.Wysokosc + " waga: " + test1.Waga);
                }
                Console.WriteLine("ILOŚĆ PACZEK:" + test.Count);
            }




        }
    }
}
