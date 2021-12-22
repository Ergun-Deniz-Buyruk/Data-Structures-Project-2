using System;
using System.Collections.Generic;
using System.Collections;

namespace Data_Structure_Proje_2
{
    /*
     * 4. sorunun b şıkkı icin kullanilacak olan Integer Kuyruk Sinifi.
     */
    internal class MyIntPriorityQueue
    {
        private List<int> sayilistesi;

        public MyIntPriorityQueue()
        {
            sayilistesi = new List<int>();
        }

        public void add(int sayi)
        {
            sayilistesi.Add(sayi);
        }

        /*
         * Listeden eleman silmek icin once en kucuk elemani bulmamız gerekir.
         * Bulduktan sonra silebiliriz.
         */
        public int remove()
        {
            int enKucukSayi = sayilistesi[0];
            foreach (int sayi in sayilistesi)
            {
                if (sayi < enKucukSayi)
                {
                    enKucukSayi = sayi;
                }
                else if (sayi == 0 && enKucukSayi == 0)
                {
                    enKucukSayi = sayi;
                }
            }
            sayilistesi.Remove(enKucukSayi);
            return enKucukSayi;
        }

        public bool isEmpty()
        {
            return (sayilistesi.Count == 0);
        }

        public int count()
        {
            return sayilistesi.Count;
        }
    }
}
