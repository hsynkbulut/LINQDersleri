namespace Ders02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar1 = { 1, 3, 5, 7, 9 };
            int[] sayilar2 = { 1, 5, 8, 7, 22 };

            var kiyasla = from bir in sayilar1 //verimizle bağlantı kurduğumuz kısım
                          from iki in sayilar2 //verimizle bağlantı kurduğumuz kısım
                          where bir < iki   //koşul kısmı
                          select new { bir, iki };     //değerleri okuduğumuz kısım
            
            foreach (var kiyas in kiyasla)
            {
                Console.WriteLine("Sonuç {0} < {1}", kiyas.bir, kiyas.iki);
            }
            Console.ReadLine();
        }
    }
}