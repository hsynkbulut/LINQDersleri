namespace Ders07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Range: Belirli bir aralığı verir. Range(Başlangıç indexi, Kaç adet olacağı)
            var numbers = from s in Enumerable.Range(1, 9)
                          select new { Sayı = s, tekMi = s % 2 == 1 ? "Tek Sayı" : "Çift Sayı" };

            Console.WriteLine("\nTek sayılar listem: ");
            foreach (var number in numbers)
            {
                Console.WriteLine(number + " ");
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}