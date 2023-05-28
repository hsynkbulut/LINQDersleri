namespace Ders03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bisiler = { "ElmAa", "aRabA", "BisiLER" };

            /*ToUpper: Harflerin hepsini büyük yapar.
            ToLower: Harflerin hepsini küçük yapar.*/
            var YaziIsle = from n in bisiler
                           select new { Buyut = n.ToUpper(), Kucult = n.ToLower() };

            foreach (var deger in YaziIsle)
            {
                Console.WriteLine("Buyut : {0} - Kucult: {1}", deger.Buyut, deger.Kucult);
            }

            Console.ReadLine();
        }
    }
}