namespace Ders13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DersAlisService dersAlisService = new();
            var dersAlislar = dersAlisService.GetDersAlislar();

            /*SELECT d.DersAdi FROM DersAlis d group by d.DersAdi*/
            //into g: g adında bir değişkene ata bunu demek
            var derslerQuerySyntax = (from d in dersAlislar
                                      group d by d.DersAdi into g
                                      select g.Key).ToList();
            Console.Write("Ders Adları (derslerQuerySyntax):");
            foreach ( var dersler in derslerQuerySyntax )
            {
                Console.Write(dersler + " ");
            }

            var derslerMethodSyntax = dersAlislar
                .GroupBy(x => x.DersAdi)
                .Select(x => x.Key)
                .ToList();
            Console.Write("\nDers Adları (derslerMethodSyntax):");
            foreach (var dersler in derslerMethodSyntax)
            {
                Console.Write(dersler + " ");
            }

            var derslerCinsiyetQuery = (from d in dersAlislar
                                        group d by new { d.DersAdi, d.Cinsiyet } into g
                                        select new { g.Key.DersAdi, g.Key.Cinsiyet }
                                        ).ToList();
            Console.WriteLine("\n\nDers Alan öğrencilerin cinsiyetlerine göre aldığı dersler (derslerCinsiyetQuery):");
            foreach (var dersler in derslerCinsiyetQuery)
            {
                Console.WriteLine(dersler);
            }

            var derslerCinsiyetMethod = dersAlislar
                .GroupBy(x => new { x.DersAdi, x.Cinsiyet })
                .Select(x => new { x.Key.DersAdi, x.Key.Cinsiyet })
                .ToList();
            Console.WriteLine("\n\nDers Alan öğrencilerin cinsiyetlerine göre aldığı dersler (derslerCinsiyetMethod):");
            foreach (var dersler in derslerCinsiyetMethod)
            {
                Console.WriteLine(dersler);
            }

            /*SELECT d.DersAdi, d.Cinsiyet, COUNT(d.Id) AS Adet FROM DersAlis d GROUP BY d.DersAdi, d.Cinsiyet*/
            var derslerCinsiyetAdet = (from d in dersAlislar
                                       group d by new { d.DersAdi, d.Cinsiyet } into g
                                       select new
                                       {
                                           g.Key.DersAdi,
                                           g.Key.Cinsiyet,
                                           Adet = g.Count()
                                       }
                                        ).ToList();
            Console.WriteLine("\n\nCinsiyetlerine göre dersi alan öğrenci sayıları (derslerCinsiyetAdet):");
            foreach (var dersler in derslerCinsiyetAdet)
            {
                Console.WriteLine(dersler);
            }

            var derslerCinsiyetAdetMethod = dersAlislar
                .GroupBy(x => new { x.DersAdi, x.Cinsiyet })
                .Select(x => new {
                    x.Key.DersAdi,
                    x.Key.Cinsiyet,
                    Adet = x.Count()
                })
                .ToList();
            Console.WriteLine("\n\nCinsiyetlerine göre dersi alan öğrenci sayıları (derslerCinsiyetAdetMethod):");
            foreach (var dersler in derslerCinsiyetAdetMethod)
            {
                Console.WriteLine(dersler);
            }


            /*Genellikle günlük hayatta ya bir şeyin toplamını yada adetini bulmak istediğimiz durumlarda group by'ı kullanırız!*/

            /*SELECT d.DersAdi, d.Cinsiyet, COUNT(d.Id) AS Adet, SUM(d.Yas) AS ToplamYas FROM DersAlis d GROUP BY d.DersAdi, d.Cinsiyet*/
            var derslerCinsiyetAdetToplamYas = (from d in dersAlislar
                                                group d by new { d.DersAdi, d.Cinsiyet } into g
                                                select new
                                                {
                                                    g.Key.DersAdi,
                                                    g.Key.Cinsiyet,
                                                    Adet = g.Count(),
                                                    ToplamYas = g.Sum(x => x.Yas)
                                                }
                                        ).ToList();
            Console.WriteLine("\n\nCinsiyetlerine göre dersi alan öğrencilerin toplam yaşları (derslerCinsiyetAdetToplamYas):");
            foreach (var dersler in derslerCinsiyetAdetToplamYas)
            {
                Console.WriteLine(dersler);
            }

            var derslerCinsiyetAdetToplamYasMethod = dersAlislar
                .GroupBy(x => new { x.DersAdi, x.Cinsiyet })
                .Select(x => new {
                    x.Key.DersAdi,
                    x.Key.Cinsiyet,
                    Adet = x.Count(),
                    ToplamYas = x.Sum(y => y.Yas)
                })
                .ToList();
            Console.WriteLine("\n\nCinsiyetlerine göre dersi alan öğrencilerin toplam yaşları (derslerCinsiyetAdetToplamYasMethod):");
            foreach (var dersler in derslerCinsiyetAdetToplamYasMethod)
            {
                Console.WriteLine(dersler);
            }


            var ogretmenService = new OgretmenService();
            var ogretmenler = ogretmenService.GetOgretmenler();

            /*SELECT d.Ad, d.Soyad, Cinsiyet, Yas, o.Ad + ' ' + o.Soyad AS OgretmenAdi 
             * FROM DersAlis d INNER JOIN Ogretmen o ON d.OgretmenId = o.Id*/

            //equals: eşittir demek
            var sonucQuery = (from d in dersAlislar
                              join o in ogretmenler on d.OgretmenId equals o.Id
                              select new
                              {
                                  d.Ad,
                                  d.Soyad,
                                  d.Cinsiyet,
                                  d.Yas,
                                  //OgretmenAd = o.Ad,
                                  //OgretmenSoyad = o.Soyad
                                  OgretmenAdSoyad = o.Ad + " " + o.Soyad
                              }).ToList();
            Console.WriteLine("\n\nDers alan öğrencilerin tüm bilgileri ve o dersi aldıkları Öğretmenin adı (sonucQuery):");
            foreach (var dersler in sonucQuery)
            {
                Console.WriteLine(dersler);
            }

            var sonucMethod = dersAlislar.Join(ogretmenler, d => d.OgretmenId, o => o.Id,
                (d, o) => new
                {
                    d.Ad,
                    d.Soyad,
                    d.Cinsiyet,
                    d.Yas,
                    OgretmenAdSoyad = o.Ad + " " + o.Soyad
                }).ToList();
            Console.WriteLine("\n\nDers alan öğrencilerin tüm bilgileri ve o dersi aldıkları Öğretmenin adı (sonucMethod):");
            foreach (var dersler in sonucMethod)
            {
                Console.WriteLine(dersler);
            }


            Console.ReadLine();
        }
    }

    public class Ogretmen
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }

    public class DersAlis
    {
        public string DersAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public int OgretmenId { get; set; }


        public DersAlis()
        {

        }

        public DersAlis(string ad, string soyad, int yas, string cinsiyet, string dersAdi, int ogretmenId)
        {
            Ad = ad;
            Soyad = soyad;
            Yas = yas;
            Cinsiyet = cinsiyet;
            DersAdi = dersAdi;
            OgretmenId = ogretmenId;
        }
    }

    public class DersAlisService
    {
        public List<DersAlis> GetDersAlislar()
        {
            return new List<DersAlis>()
            {
                new DersAlis() { Ad = "Ali", Soyad = "Bayram", Cinsiyet = "Erkek", DersAdi = "C#", Yas = 25, OgretmenId = 1 },
                new DersAlis("Ahmet", "Dene", 30, "Erkek", "C#", 1),
                new DersAlis("Damla", "Al", 20, "Kadın", "C#", 1),
                new DersAlis("Damla", "Al", 20, "Kadın", "Sql", 2),
                new DersAlis("Serhat", "Ver", 25, "Erkek", "Sql", 2),
                new DersAlis("Serhat", "Ver", 25, "Erkek", "C#", 3),
                new DersAlis("Mehmet", "Sobacı", 25, "Erkek", "C#", 3),
                new DersAlis("Zehra", "Sobacı", 24, "Kadın", "C#", 3),
                new DersAlis("Hüseyin", "Karabulut", 24, "Erkek", "Dart", 2),
            };
        }
    }

    public class OgretmenService
    {
        public List<Ogretmen> GetOgretmenler()
        {
            return new List<Ogretmen>()
            {
                new Ogretmen() { Id = 1, Ad = "Ahmet", Soyad = "Barın" },
                new Ogretmen() { Id = 2, Ad = "Mehmet", Soyad = "Kiraz" },
                new Ogretmen() { Id = 3, Ad = "Gülşah", Soyad = "Kiraz" },
            };
        }
    }
}