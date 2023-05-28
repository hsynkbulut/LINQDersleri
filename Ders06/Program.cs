namespace Ders06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] kaynaklar = { 1, 2, 3, 5, 5, 5, 7, 8, 8 };

            //distinc: Tüm değerleri tekil, unique olarak getirir. Birden fazla kez getirmez!
            var degerleriTekle = kaynaklar.Distinct();

            Console.Write("Sayıları tekil olarak göster: ");
            foreach (var deger in degerleriTekle)
            {
                Console.Write(deger + " ");
            }
            //-----------------------------------------------------------------------------
            int[] sayilar1 = { 1, 2, 3, 4, 5 };
            int[] sayilar2 = { 1, 2, 3, 6, 7, 8 };

            //Union: Birleşim kümesi
            var Union = sayilar1.Union(sayilar2);
            Console.Write("\nİki dizinin birleşmiş hali: ");
            foreach (var deger in Union)
            {
                Console.Write(deger + " ");
            }

            //Intersect: Kesişim kümesi
            var kesisenler = sayilar1.Intersect(sayilar2);
            Console.Write("\nİki dizinin kesişimi: ");
            foreach (var kesisme in kesisenler)
            {
                Console.Write(kesisme + " ");
            }

            //Except: Fark kümesi
            var farkKumesi = sayilar1.Except(sayilar2);
            Console.Write("\nSayilar1'in Sayilar2'den farklı olan değerleri: ");
            foreach (var fark in farkKumesi)
            {
                Console.Write(fark + " ");
            }

            //---------------------------------------------------------------------------

            /*OfType: Veri tipi olmadan her tür değeri tek bir dizide tutup, OfType ile 
            belirttiğimiz veri tiplerinin gelmesini sağlarız.*/
            object[] sayilar = { "bir", 77, "iki", 3.3, "pazartesi", 4.7, "bisiler" };
            var doubleSayılar = sayilar.OfType<double>();

            Console.Write("\nDouble (Ondalık) Sayılar: ");
            foreach (var item in doubleSayılar)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}