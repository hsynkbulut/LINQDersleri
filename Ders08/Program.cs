namespace Ders08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Count(): Verilerin sayısını, adedini verir.
            Sum(): Toplam
            Min(): En küçük değer
            Max(): En büyük değer
            Average(): Ortalama
            Any: Hiç, herhangi bir değer koşulu sağlıyor mu? anlamında
            All: Bütün değerler koşulu sağlıyor mu? anlamında
            Contains: İçeriyor mu içermiyor mu kontrolünü sağlar.
            Concat: Bir dizinin sonuna başka dizideki değerleri eklemeyi sağlar.
            SequenceEqual: İki listeyi karşılaştırıp birbirlerine eşit olup olmadıklarını True yada False olarak söyler.*/

            int[] sayilar = { 1, 2, 2, 2, 5, 5, 6, 7 };
            var kacSayiVar = sayilar.Distinct().Count();
            double toplamDeger = sayilar.Sum();
            var minSayi = sayilar.Min();
            var maxSayi = sayilar.Max();
            double ortalamaDeger = sayilar.Average();

            Console.WriteLine("Kaç tekil değerim var = {0}", kacSayiVar);
            Console.WriteLine("Toplam sayı değerim = {0}", toplamDeger);
            Console.WriteLine("Minimum değerim = {0}", minSayi);
            Console.WriteLine("Maximum değerim = {0}", maxSayi);
            Console.WriteLine("Ortalama değerim = {0}", ortalamaDeger);
            //--------------------------------------------------------------------------------------

            string[] bisiler = { "at", "atıcı", "atıcılar", "atımak", "deve", "horoz", "kurbağa" };
            bool varMiAny = bisiler.Any(b => b.Contains("at"));
            bool varMiAll = bisiler.All(b => b.Contains("at"));
            var kisaString = bisiler.Min(b => b.Length);
            var uzunString = bisiler.Max(b => b.Length);

            Console.WriteLine("En az birinde at harfleri var mı? = {0} ", varMiAny);
            Console.WriteLine("Hepsinde at harfleri var mı? = {0} ", varMiAll);
            Console.WriteLine("Minimum karakter sayısı = {0}", kisaString);
            Console.WriteLine("Maximum karakter sayısı = {0}", uzunString);
            //--------------------------------------------------------------------------------------

            int[] say1 = { 1, 2, 3, 4, 5 };
            int[] say2 = { 1, 5, 9, 8, 4, 7 };

            var sayilarim = say1.Concat(say2);

            Console.Write("say1 dizisinin sonuna say2 dizisi eklendi: ");
            foreach (var deger in sayilarim)
            {
                Console.Write(deger + " ");
            }

            bool esitMi = say1.SequenceEqual(say2);
            Console.WriteLine("\nListeler eşit mi: " + esitMi);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}