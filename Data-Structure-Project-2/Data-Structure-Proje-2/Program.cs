using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structure_Proje_2
{
    internal class Program
    {
        // Dokumanda verilen mahalleler.
        static String[] mahalleler = { "Özkanlar", "Evka 3", "Atatürk",
                "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene" };

        // Dokumanda verilen teslimat sayilari
        static int[] teslimatSayisi = { 5, 2, 7, 2, 7, 3, 0, 1 };

        //Rastgele yemekler
        static String[] yemekler = { "Türlü", "Pizza", "Hamburger", "Pilav", "Börek", "Simit", "Kızartma" };

        public static Random random = new Random();
        static void Main(string[] args)
        {
            ArrayList motoKuryeListesi = BilesikVeriYapisiOlusturma(); // Arraylisti olustur.

            //Console.BackgroundColor = ConsoleColor.White;
            //Console.Clear();
            //Console.ForegroundColor = ConsoleColor.Black;

            // Motokurye listesindeki mahalle ve teslimat sayısını bul ve ekrana yaz.
            mahalleVeTeslimatSayisiniBulupEkranaYazdir(motoKuryeListesi);

            mahalleStackOlustur(motoKuryeListesi); // Stack
            
            mahalleQueueOlustur(motoKuryeListesi); // Queue

            azalanSiradaKuyrukOlustur(motoKuryeListesi); // Priority Queue

            islemTamamlanmaSureleriniHesapla(); // Islem suresini hesapla.

            oncelikliIslemTamamlanmaSureleriniHesapla(); // Oncelikli islem suresini hesapla.

            Console.ReadLine();
        }

        /*
         * Projenin 1. sorusunun b şıkkında istenen metot.
         */
        public static ArrayList BilesikVeriYapisiOlusturma()
        {
            // içerisinde Mahalleleri tutacak olan ArrayListemizi yarat.
            ArrayList motoKuryeListesi = new ArrayList();
            
            /* 
             * Mahalle sayisi kadar donen ve her bir turda mahalle nesnesini ve ilgili teslimatları olusturup
             * Arraylisteye ekleyen for dongusu.
             */
            for (int i = 0; i < mahalleler.Length; i++)
            {
                // Mahalle Nesnesini yarat.
                Mahalle mahalle = new Mahalle(mahalleler[i], teslimatSayisi[i]);

                /* O mahalleye kac tane teslimat gidecekse o kadar donen ve her turda teslimat nesnelerini
                 * yaratıp Generic listeye ekleyen bir for dongusu.
                 */
                for (int j = 0; j < mahalle.getTeslimatSayisi(); j++)
                {
                    String yemek = yemekler[random.Next(yemekler.Length)]; // rastgele yemek seç.
                    Teslimat teslimat = new Teslimat(yemek, random.Next(10)); // Teslimat nesnesini olustur.
                    mahalle.teslimatListesineEkle(teslimat); // Teslimat nesnesini Listeye ekle.
                }
                // Artık en son olusan mahallemizi Arraylisteye ekleyelim.
                motoKuryeListesi.Add(mahalle); 
            }
            return motoKuryeListesi;
        }

        /*
         * Dokumandaki 1. sorunun c şıkkındaki işlemi yapan metot.
         */
        public static void mahalleVeTeslimatSayisiniBulupEkranaYazdir(ArrayList motoKuryeListesi)
        {
            int toplamTeslimatSayisi = 0;
            /*
             * Tum teslimat sayisini bulmak icin mahalle mahalle bak. Her mahallenin 
             * teslimat sayisini topla.
             */
            for (int i = 0; i < motoKuryeListesi.Count; i++)
            {
                Mahalle mahalle = (Mahalle) motoKuryeListesi[i];
                toplamTeslimatSayisi += mahalle.getTeslimatSayisi();
            }

            // Arraylistin eleman sayisi mahalle sayisina esittir.
            Console.WriteLine("Toplam Mahalle (Liste) sayisi: " + motoKuryeListesi.Count);

            // Bulunan toplam teslimat sayisini ekrana yazdir.
            Console.WriteLine("Toplam Teslimat Sayisi: " + toplamTeslimatSayisi);
            Console.WriteLine();
        }

        /*
         * Dokumandaki 2.sorunun a şıkkı işlemini yapan metot.
         */
        public static void mahalleStackOlustur(ArrayList motoKuryeListesi)
        {
            // Stack sınıfından 100 elemanlı bir stack olustur.
            MyStack myStack = new MyStack(100);

            // Arraylistteki mahalleleri tek tek stacke at.
            for (int i = 0; i < motoKuryeListesi.Count; i++)
            {
                myStack.push((Mahalle) motoKuryeListesi[i]);
            }

            /*
             * Her mahalle icin teslimat listelerini gezerek teslimatlarını ekrana yazdir.
             */
            while (!myStack.isEmpty())
            {
                Mahalle mahalle = myStack.pop();
                Console.WriteLine(mahalle);
                for (int i = 0; i < mahalle.getTeslimatListesi().Count; i++)
                {
                    Teslimat teslimat = mahalle.getTeslimatListesi()[i];
                    Console.WriteLine(teslimat);
                }
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine();
        }

        /*
         * Dokumandaki 2. sorudaki b şıkkı işlemini yapan metot.
         */
        public static void mahalleQueueOlustur(ArrayList motoKuryeListesi)
        {
            // Queue sınıfından bir nesne yarat.
            MyQueue myQueue = new MyQueue(100);

            // Arraylistteki mahalleleri tek tek stacke at 
            for (int i = 0; i < motoKuryeListesi.Count; i++)
            {
                myQueue.insert((Mahalle)motoKuryeListesi[i]);
            }

            /*
             * Her mahalle icin teslimat listelerini gezerek teslimatlarını ekrana yazdir.
             */
            while (!myQueue.isEmpty())
            {
                Mahalle mahalle = myQueue.remove();
                Console.WriteLine(mahalle);
                for (int i = 0; i < mahalle.getTeslimatListesi().Count; i++)
                {
                    Teslimat teslimat = mahalle.getTeslimatListesi()[i];
                    Console.WriteLine(teslimat);
                }
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine();
        }

        /*
         * Dokumandaki 3. sorudaki a şıkkı işlemini yapan metot.
         */
        public static void azalanSiradaKuyrukOlustur(ArrayList motoKuryeListesi)
        {
            // Oncelikli Kuyruğumuzu yaratalım.
            PriorityQueue priorityQueue = new PriorityQueue();

            // Ornegimizdeki Listede bulunan mahalle nesnelerini kuyruğa ekle.
            foreach(Mahalle mahalle in motoKuryeListesi)
            {
                priorityQueue.add(mahalle);
            }

            // Kuyruktan buyukten kucuge dogru elemanları tek tek sil ve Konsola yazdir.
            while (!priorityQueue.isEmpty())
            {
                Mahalle mahalle = priorityQueue.remove();
                Console.WriteLine(mahalle);
            }
            Console.WriteLine();
        }

        /*
         * Dokumandaki 4. sorunun a şıkkını yapan metot.
         */
        public static void islemTamamlanmaSureleriniHesapla()
        {
            // Queue sınıfından bir nesne yaratalım.
            MyIntQueue myQueue = new MyIntQueue(25);

            // Dokumanda verilen urun sayılari:
            int[] urunSayisi = { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 };

            // Listedeki urun sayilarını queue'ye ekle.
            foreach (int urun in urunSayisi)
            {
                myQueue.insert(urun);
            }

            int count = 0;
            int musterininToplamSuresi = 0;
            int tumMusterilerinToplamSuresi = 0;
            while (!myQueue.isEmpty())
            {
                // Her urun 3 saniyede okutuldugu icin 3 ile carp.
                int islemSuresi = 3 * myQueue.remove();
                count++;
                musterininToplamSuresi += islemSuresi;
                tumMusterilerinToplamSuresi += musterininToplamSuresi;
                Console.WriteLine(String.Format("{0}. musterinin işlem tamamlanma süresi: {1}",
                    count, musterininToplamSuresi)); // Ekrana yaz.
            }
            // Ortalamayı bul ve ekrana yaz.
            double ortalamaSure = tumMusterilerinToplamSuresi / (double) count;
            Console.WriteLine(String.Format("Kasanın ortalama işlem tamamlanma süresi: {0}", ortalamaSure));
            Console.WriteLine();
        }

        /*
         * Dokumandaki 4 sorunun b şıkkını yapan metot.
         */
        public static void oncelikliIslemTamamlanmaSureleriniHesapla()
        {
            // MyIntPriorityQueue sınıfından bir nesne yaratalım.
            MyIntPriorityQueue myPriorityQueue = new MyIntPriorityQueue();

            // Dokumanda verilen urun sayılari:
            int[] urunSayisi = { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 };

            // Listedeki urun sayilarını oncelikli kuyruga ekle.
            foreach (int urun in urunSayisi)
            {
                myPriorityQueue.add(urun);
            }

            int count = 0;
            int musterininToplamSuresi = 0;
            int tumMusterilerinToplamSuresi = 0;
            while (!myPriorityQueue.isEmpty())
            {
                // Her urun 3 saniyede okutuldugu icin 3 ile carp.
                int islemSuresi = 3 * myPriorityQueue.remove();
                count++;
                musterininToplamSuresi += islemSuresi;
                tumMusterilerinToplamSuresi += musterininToplamSuresi;
                Console.WriteLine(String.Format("{0}. musterinin işlem tamamlanma süresi: {1}",
                    count, musterininToplamSuresi)); // Ekrana yaz.
            }
            // Ortalamayı bul ve ekrana yaz.
            double ortalamaSure = tumMusterilerinToplamSuresi / (double)count;
            Console.WriteLine(String.Format("Kasanın ortalama işlem tamamlanma süresi: {0}", ortalamaSure));
        }
    }
}
