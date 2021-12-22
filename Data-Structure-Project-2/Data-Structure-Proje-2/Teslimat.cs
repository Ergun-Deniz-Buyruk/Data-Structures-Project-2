using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * Ilk soruda kullanılmak uzere tasarlanan teslimat listesi
     */
    internal class Teslimat
    {
        private String yemekAdi;
        private int yemekAdedi;

        public Teslimat()
        {
            setYemekAdi("");
            setYemekAdedi(0);
        }

        public Teslimat(string yemekAdi, int yemekAdedi)
        {
            setYemekAdi(yemekAdi);
            setYemekAdedi(yemekAdedi);
        }

        public void setYemekAdi(String yemekAdi)
        {
            this.yemekAdi = yemekAdi;
        }
        public void setYemekAdedi(int yemekAdedi)
        {
            if (yemekAdedi >= 0)
            {
                this.yemekAdedi = yemekAdedi;
            }
        }
        public String getYemekAdi()
        {
            return yemekAdi;
        }
        public int getYemekAdedi()
        {
            return yemekAdedi;
        }

        public
        override String ToString()
        {
            return String.Format("Yemek Adi: {0}, Yemek Adedi: {1}", yemekAdi, yemekAdedi);
        }
    }
}
