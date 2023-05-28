namespace Ders05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meyveler = { "Armut", "Kavun", "Kivi", "Karpuz" };

            /*orderby: Collection’u küçükten büyüğe sıralar.
            ascending: küçükten büyüğe yada düz sıralama
            descending: büyükten küçüğe yada tersten sıralama
            Length: Uzunluğu bulur.*/
            var meyveListesi = from m in meyveler
                               orderby m ascending //Alfabetik sıralama
                               select m;

            Console.WriteLine("Meyve Listele:");
            foreach (var meyve in meyveListesi)
            {
                Console.WriteLine(meyve);
            }

            //Dizinin uzunluğuna göre sıralatırız. Böylece kısa kelimeden uzun kelimeye doğru sıralanır.
            string[] bisiler = { "Ayakkabıcı", "Gömlek", "İstanbul", "İzmir", "Çanakkale", "Zeytinyalılar", "UNO" };
            var bisilerListesi = from b in bisiler
                                 orderby b.Length //Dizi uzunluğuna göre sırala
                                 select b;

            Console.WriteLine("\nBisiler Listem:");
            foreach (var item in bisilerListesi)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}