namespace Ders09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dizi Sıralama(LINQ -Yaslar tablosu için)
            #region Dizi Sıralama (LINQ - Query Syntax ve Method Syntax ile)
            List<int> yaslar = new List<int>
            {
                18,19,15,14,20,60,30,90
            };

            //SELECT * FROM Yaslar y WHERE y.Yas < 35 ORDER BY y.Yas
            var sonuc = from y in yaslar
                        where y < 35
                        orderby y
                        select y;

            //Sonucu bir liste olarak almak için;
            var sonucQuerySyntax = (from y in yaslar
                                    where y < 35
                                    orderby y
                                    select y).ToList();

            var sonucMethodSyntax = yaslar
                .Where(y => y < 35)
                .OrderBy(y => y)
                .Select(y => y) //opsiyonel, kullanmasan da olur
                .ToList();

            Console.WriteLine("sonuc:");
            foreach (var item in sonuc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============================================");

            Console.WriteLine("\nsonucQuerySyntax:");
            foreach (var item in sonucQuerySyntax)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============================================");

            Console.WriteLine("\nsonucMethodSyntax:");
            foreach (var item in sonucMethodSyntax)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============================================");
            #endregion
        }
    }
}