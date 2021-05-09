using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_plecakowy
{
    public class Paczka
    {
        int lp ;
        string id;
        int wysokosc;
        int szerokosc;
        int dlugosc;
        int waga;


        public Paczka(int lp, string id, int wysokosc, int szerokosc, int dlugosc, int waga)
    {
            this.Lp = lp;
            this.Id = id;
            this.Wysokosc = wysokosc;
            this.Szerokosc = szerokosc;
            this.Dlugosc = dlugosc;
            this.Waga = waga;
    }

        public int Lp { get => lp; set => lp = value; }
        public string Id { get => id; set => id = value; }
        public int Wysokosc { get => wysokosc; set => wysokosc = value; }
        public int Szerokosc { get => szerokosc; set => szerokosc = value; }
        public int Dlugosc { get => dlugosc; set => dlugosc = value; }
        public int Waga { get => waga; set => waga = value; }
    }
}
