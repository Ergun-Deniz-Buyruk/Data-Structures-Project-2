using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    /*
     * 3. sorunun a şıkkı icin kullanilacak olan Azalan Oncelikli Kuyruk Sinifi.
     */
    internal class PriorityQueue
    {
        private List<Mahalle> mahallelistesi;
        
        public PriorityQueue()
        {
            mahallelistesi = new List<Mahalle>();
        }

        public void add(Mahalle mahalle)
        {
            mahallelistesi.Add(mahalle);
        }

        /*
         * Listeden eleman silmek icin once en buyuk elemani bulmamız gerekir.
         * Bulduktan sonra silebiliriz.
         */
        public Mahalle remove()
        {
            Mahalle enYuksekMahalle = new Mahalle();
            foreach(Mahalle mahalle in mahallelistesi)
            {
                if(mahalle.getTeslimatSayisi() > enYuksekMahalle.getTeslimatSayisi())
                {
                    enYuksekMahalle = mahalle;
                } 
                else if (mahalle.getTeslimatSayisi() == 0 
                    && enYuksekMahalle.getTeslimatSayisi() == 0)
                {
                    enYuksekMahalle = mahalle;
                }
            }
            mahallelistesi.Remove(enYuksekMahalle);
            return enYuksekMahalle;
        }

        public bool isEmpty()
        {
            return (mahallelistesi.Count == 0);
        }

        public int count()
        {
            return mahallelistesi.Count;
        }
    }
}
