using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * Ilk soruda kullanılacak olan Mahalle sınıfı.
     */
    internal class Mahalle
    {
        private String mahalleAdi;
        private int teslimatSayisi;
        // Her Mahalle listeyi referans gosterecek bir bag sahasina sahip.
        private List<Teslimat> teslimatListesi;

        public Mahalle()
        {
            setMahalleAdi("");
            setTeslimatSayisi(0);
            teslimatListesi = new List<Teslimat>();
        }

        public Mahalle(string mahalleAdi, int teslimatSayisi)
        {
            setMahalleAdi(mahalleAdi);
            setTeslimatSayisi(teslimatSayisi);
            teslimatListesi = new List<Teslimat>();
        }

        public void setMahalleAdi(String mahalleAdi)
        {
            this.mahalleAdi = mahalleAdi;
        }

        public void setTeslimatSayisi(int teslimatSayisi)
        {
            if (teslimatSayisi >= 0)
            {
                this.teslimatSayisi = teslimatSayisi;
            }
        }

        public String getMahalleAdi()
        {
            return mahalleAdi;
        }

        public int getTeslimatSayisi()
        {
            return teslimatSayisi;
        }

        public List<Teslimat> getTeslimatListesi()
        {
            return teslimatListesi;
        }
        
        public void teslimatListesineEkle(Teslimat teslimat)
        {
            teslimatListesi.Add(teslimat);
        }

        public
        override String ToString()
        {
            return String.Format("Mahalle Adi: {0}, Teslimat Sayisi: {1}", mahalleAdi, teslimatSayisi);
        }
    }
}
