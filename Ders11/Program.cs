namespace Ders11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ devamı
            List<Ogrenci> ogrenciler = new List<Ogrenci>()
            {
                new Ogrenci{ Id = 1,  Ad = "Ali", Soyad = "Veli", Yas = 15 },
                new Ogrenci{ Id = 2,  Ad = "Ali 1", Soyad = "Veli 1", Yas = 30 },
                new Ogrenci{ Id = 3,  Ad = "Ali 2", Soyad = "Veli 2", Yas = 20 },
                new Ogrenci{ Id = 4,  Ad = "Ali", Soyad = "Veli 5", Yas = 50 },
            };

            var sorguSonucuQuery = (from o in ogrenciler
                                    where o.Ad == "Ali"
                                    //select o
                                    //select new {o.Ad, o.Soyad}
                                    select new OgrenciSonuc { Ad = o.Ad, Soyad = o.Soyad }
                              ).ToList();

            //Method Syntax'ında Select koymak zorunlu değildir! Mesela select ile tablodaki şu sütun
            //gelsin demek yerine tablodaki bütün sütunlarının gelmesini istiyorsak select kullanmamıza
            //hiç gerek yok method syntax'ında.
            var sorguSonucuMethod = ogrenciler
                .Where(x => x.Ad == "Ali")
                //.Select(x => new { x.Ad, x.Soyad })
                .Select(x => new OgrenciSonuc { Ad = x.Ad, Soyad = x.Soyad })
                .ToList();

            var sonucAdet = ogrenciler
                .Where(x => x.Yas <= 30)
                .Count();

            //Any: bu kayıt hiç var mı? Geriye True-False döner.
            var sonucAny = ogrenciler
                .Where(x => x.Yas <= 30)
                .Any();

            Console.WriteLine("Adı Ali olan tüm kayıtların Ad ve soyadları (sorguSonucuQuery):");
            foreach (var item in sorguSonucuQuery)
            {
                Console.WriteLine($"Ad: {item.Ad}, Soyad: {item.Soyad}");
            }
            Console.WriteLine("============================================");

            Console.WriteLine("\nAdı Ali olan tüm kayıtların Ad ve soyadları (sorguSonucuMethod):");
            foreach (var item in sorguSonucuMethod)
            {
                Console.WriteLine($"Ad: {item.Ad}, Soyad: {item.Soyad}");
            }
            Console.WriteLine("============================================");

            Console.WriteLine($"\nYaşı 30 veya 30'dan küçük olanların sayısı (sonucAdet): {sonucAdet}");
            Console.WriteLine($"Yaşı 30 veya 30'dan küçük olan hiç var mı? (sonucAny): {sonucAny}");
            #endregion

            //Ankaradan gelen, yaşı 25'den küçük olan, cinsiyeti de Erkek olan kaç kişi var?
            //Ispartalı, yaşı 25'den küçük olan, Bilgisayar Mühendisliğinde okuyan kaç öğrenci var?
            Console.ReadLine();
        }
    }

    public class OgrenciSonuc
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public int Yas { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}