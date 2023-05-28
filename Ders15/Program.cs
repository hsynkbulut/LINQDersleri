namespace Ders15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Paging - Sayfalama
            var ogrenciServire = new OgrenciService();
            var ogrenciler = ogrenciServire.GetOgrenciler();

            var sayfadaGosterilecekDataSayisi = 20;
            var kacinciSayfadayiz = 1; //BURAYI DEĞİŞTİRİP KONTROL SAĞLANIR

            //Skip: atlanacak yerler, Take: Alınacak yerler
            var sayfalamaSonucu = ogrenciler
                .Skip((kacinciSayfadayiz - 1) * sayfadaGosterilecekDataSayisi)
                .Take(sayfadaGosterilecekDataSayisi)
                .ToList();

            Console.WriteLine($"*** {sayfalamaSonucu.Count} Öğrenci Sayfası ***");
            Console.WriteLine();
            foreach (var ogrenci in sayfalamaSonucu)
            {
                Console.WriteLine($"Öğrenci ID: {ogrenci.Id}, Adı Soyadı: {ogrenci.Ad} {ogrenci.Soyad}");
            }
            Console.WriteLine();

            var dersler = new DersService().GetDersler();

            var sonuc = (from d in dersler
                         from o in ogrenciler
                         select
                         new
                         {
                             d.DersAdi,
                             o.Ad
                         }).ToList();

            Console.WriteLine($"*** {sonuc.Count} Ders-Öğrenci Eşleşmesi ***");
            Console.WriteLine();
            foreach (var item in sonuc)
            {
                Console.WriteLine($"Ders Adı: {item.DersAdi}, Öğrenci Adı: {item.Ad}");
            }

            Console.ReadLine();
        }
    }

    public class Ders
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }
    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }

    public class OgrenciService
    {
        public List<Ogrenci> GetOgrenciler()
        {
            var sonuc = new List<Ogrenci>(10);
            for (int i = 0; i < 10; i++)
            {
                sonuc.Add(
                    new Ogrenci { Id = (i + 1), Ad = "Ali" + (i + 1).ToString(), Soyad = "Doğan" + (i + 1).ToString() }
                );
            }
            return sonuc;
        }

        //public PageResult<Ogrenci> GetOgrenciPaging()
        //{

        //}
    }

    public class DersService
    {
        public List<Ders> GetDersler()
        {
            var sonuc = new List<Ders>(10);
            sonuc.Add(new Ders() { Id = 1, DersAdi = "C#" });
            sonuc.Add(new Ders() { Id = 2, DersAdi = "SQL" });
            return sonuc;
        }
    }

}