namespace Ders10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dizi Sıralama(LINQ -Query Syntax ve Method Syntax ile) 
            #region Dizi Sıralama (LINQ - Query Syntax ve Method Syntax ile) 
            List<Ogrenci> ogrenciler = new List<Ogrenci>()
            {
                new Ogrenci{ Id = 1,  Ad = "Ali", Soyad = "Veli", Yas = 15 },
                new Ogrenci{ Id = 2,  Ad = "Ali 1", Soyad = "Veli 1", Yas = 30 },
                new Ogrenci{ Id = 3,  Ad = "Ali 2", Soyad = "Veli 2", Yas = 20 },
                new Ogrenci{ Id = 4,  Ad = "Ali", Soyad = "Veli 5", Yas = 50 },
            };

            var sonucOgrenciYaslarQuery = (from o in ogrenciler
                                           where o.Yas < 25
                                           orderby o.Yas descending
                                           select o).ToList();

            var sonucOgrenciYaslarMethod = ogrenciler
                .Where(x => x.Yas < 25)
                .OrderByDescending(x => x.Yas)
                .Select(x => x)
                .ToList();

            Console.WriteLine("sonucOgrenciYaslarMethod:");
            for (int i = 0; i < sonucOgrenciYaslarMethod.Count; i++)
            {
                var seciliOgrenci = sonucOgrenciYaslarMethod[i];
                Console.WriteLine("ID: {0}, Ad: {1}, Soyad: {2}, Yas: {3}",
                    seciliOgrenci.Id, seciliOgrenci.Ad, seciliOgrenci.Soyad, seciliOgrenci.Yas);
            }
            Console.WriteLine("============================================");

            Console.WriteLine("\nsonucOgrenciYaslarQuery:");
            for (int i = 0; i < sonucOgrenciYaslarQuery.Count; i++)
            {
                var seciliOgrenci = sonucOgrenciYaslarQuery[i];
                Console.WriteLine("ID: {0}, Ad: {1}, Soyad: {2}, Yas: {3}",
                    seciliOgrenci.Id, seciliOgrenci.Ad, seciliOgrenci.Soyad, seciliOgrenci.Yas);
            }
            #endregion

            Console.ReadLine();
        }
    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public int Yas { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Ad: {1}, Soyad: {2}, Yas: {3}",
                this.Id, this.Ad, this.Soyad, this.Yas);
        }
    }
}