namespace Ders04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7 };

            /*Skip: Baştan belirtilen sayıya kadar öğeyi atar, almaz! Ondan sonrakileri alır.
            Take: Baştan belirtilen sayıya kadar öğeyi alır ve geri kalanları atar, almaz!*/
            var result = sayilar
                            .Skip(2)
                            .Take(3);

            Console.WriteLine("İlk 2 sayı atladıktan sonraki ilk 3 sayı:");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}