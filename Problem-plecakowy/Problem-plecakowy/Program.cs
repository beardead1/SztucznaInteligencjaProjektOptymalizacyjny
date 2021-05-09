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
            int[] HM;
            int HMS = 15;




                // dodajemy do listy do wagi 1000 kg
                int waga1 = 0;
                int obj = 0;

                //POPRAWIĆ  dać IFa, żeby nie przekraczało wagi i obj.
                for (int j = 0; waga1 < 1000 && obj < objetosc; j++)
                {
                    int losowa = rand.Next(10000);
                    paczka_new.Add(paczka[losowa]);
                    waga1 = waga1 + paczka_new[j].Waga;
                    obj = obj + (paczka_new[j].Dlugosc * (paczka_new[j].Szerokosc * paczka_new[j].Wysokosc));
                }


            //wyświetlamy loswe paczki do 1000 kg
                int waga_test = 0;
                int obj_test = 0;
                for (int i = 0; i < paczka_new.Count; i++)
                {
                Console.WriteLine("ID: " + paczka_new[i].Id + " Waga: " + paczka_new[i].Waga + " Rozmiar: " + paczka_new[i].Wysokosc + "\\" + paczka_new[i].Szerokosc + "\\" + paczka_new[i].Dlugosc);
                waga_test = waga_test + paczka_new[i].Waga;
                obj_test = obj_test + paczka_new[i].Dlugosc * (paczka_new[i].Szerokosc * paczka_new[i].Wysokosc);

                }
                Console.WriteLine("Ilość paczek: ");
                Console.WriteLine(paczka_new.Count);
                Console.WriteLine("Waga razem: " + waga_test);
                Console.WriteLine("Objętość razem: " + obj_test);



        }
    }
}
