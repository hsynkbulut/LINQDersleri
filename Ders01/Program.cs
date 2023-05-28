namespace Ders01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sayilistem = from sl in sayilar //verimizle bağlantı kurduğumuz kısım
                             where sl > 3   //koşul kısmı
                             select sl;     //değerleri okuduğumuz kısım

            Console.WriteLine("3'ten büyük sayılar");
            foreach (var degerler in sayilistem)
            {
                Console.WriteLine("Sayılar : {0}", degerler);
            }
            Console.ReadLine();
        }
    }
}