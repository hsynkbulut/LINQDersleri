namespace Ders14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DersAlisService dersAlisService = new();
            var dersAlislar = dersAlisService.GetDersAlislar();

            var ogretmenService = new OgretmenService();
            var ogretmenler = ogretmenService.GetOgretmenler();

            /*
            select d.Ad, d.Soyad, d.Cinsiyet, d.DersAdi,
            isnull(o.Ad + ' ' + o.Soyad, 'Tanımlanmamış') as [Öğretmen Adı]
            from DersAlis d
            left join Ogretmen o on o.Id = d.OgretmenId */

            //join işlemini yap equals ile eşitlemesini falan yap ve bunu into ile ol adındaki değişkene al!
            var sonucLeftJoin = (from d in dersAlislar
                                 join o in ogretmenler on d.OgretmenId equals o.Id into ol
                                 from ogretmen in ol.DefaultIfEmpty() //left join için DefaultIfEmpty() kullandık.
                                 select new
                                 {
                                     d.Ad,
                                     d.Soyad,
                                     d.Cinsiyet,
                                     d.Yas,
                                     OgretmenAdSoyad = ogretmen is not null ? ogretmen.TamAd : "Tanımlanmamış"
                                     //OgretmenAdSoyad = ogretmen is not null ? ogretmen.Ad + " " + ogretmen.Soyad : "Tanımlanmamış"
                                 }).ToList();
            Console.WriteLine("\nDers alan öğrencilerin bilgileri ve dersi aldıkları öğretmenleri: ");
            foreach (var ogrenci in sonucLeftJoin)
            {
                Console.WriteLine(ogrenci);
            }


            /*First: belirtilen koşula uyan birden fazla data varsa bu durumlardan ilkini getirir.
             
            First ile FirstOrDefault'un farkı: Eğer listenizde/veri setinizde o datanın olduğundan 
            eminseniz First kullanın. Emin değilseniz yani olmayadabilir ise FirstOrDefault'u kullanın.
            First kullandığınızda o data yoksa Exception hatasını fırlatır size. FirstOrDefault'ta ise 
            o data yoksa bile Exception hatasını fırlatmaz!
            */
            var arananOgretmen = ogretmenler.Where(x => x.Cinsiyet == "Erkek").First();
            var arananOgretmen2 = ogretmenler.Where(x => x.Cinsiyet == "Erkek2").FirstOrDefault();
            Console.WriteLine("\nListedeki ilk erkek öğretmen: {0}", arananOgretmen.TamAd);
            //Console.WriteLine("\nListedeki ilk erkek2 öğretmen: {0}", arananOgretmen2.TamAd);


            /*Single: Belirtilen koşula uyan bir data varsa bu durumu getirir. Birden fazla data varsa 
            Exception hatası fırlatır.
            Single ile SingleOrDefault'un farkı: Eğer listenizde/veri setinizde o datanın olduğundan 
            eminseniz Single kullanın. Emin değilseniz yani olmayadabilir ise SingleOrDefault'u kullanın.
            Single kullandığınızda o data yoksa Exception hatasını fırlatır size. SingleOrDefault'ta ise 
            o data yoksa bile Exception hatasını fırlatmaz. AMA koşul olarak birden fazla datası olan bir 
            ifade girerseniz her ikisinde de hata verir!
            */
            var arananOgretmen3 = ogretmenler.Where(x => x.Cinsiyet == "Kadın2").SingleOrDefault();
            var arananOgretmen4 = ogretmenler.Where(x => x.Cinsiyet == "Kadın").Single();
            Console.WriteLine("\nListedeki kadın sayısı 1 tane ise getir bilgilerini: {0}", arananOgretmen4.TamAd);


            /*Last: Belirtilen koşula uyan birden fazla data varsa bu durumlardan sonuncusunu getirir. 
            En son sisteme kim kayıt edilmiş gibi durumlarda kullanılır.
            
            Last ile LastOrDefault'un farkı: Eğer listenizde/veri setinizde o datanın olduğundan 
            eminseniz Last kullanın. Emin değilseniz yani olmayadabilir ise LastOrDefault'u kullanın.
            Last kullandığınızda o data yoksa Exception hatasını fırlatır size. LastOrDefault'ta ise 
            o data yoksa bile Exception hatasını fırlatmaz!
             */
            var arananOgretmen5 = ogretmenler.Where(x => x.Cinsiyet == "Erkek").Last();
            var arananOgretmen6 = ogretmenler.Where(x => x.Cinsiyet == "Erkek2").LastOrDefault();
            Console.WriteLine("\nListedeki son erkek öğretmen: {0}", arananOgretmen5.TamAd);

            /*ElementAt: İstediğim indisteki/sıradaki datayı getirir.
            
            ElementAt ile ElementAtOrDefault'un farkı: Eğer listenizde/veri setinizde o indiste herhangi bir 
            datanın olduğundan eminseniz ElementAt kullanın. Emin değilseniz yani olmayadabilir ise 
            ElementAtOrDefault'u kullanın. ElementAt kullandığınızda indiste o data yoksa Exception hatasını 
            fırlatır size. ElementAtOrDefault'ta ise o data yoksa bile Exception hatasını fırlatmaz!
             */
            var arananOgretmen7 = ogretmenler.Where(x => x.Cinsiyet == "Erkek").ElementAt(0);
            var arananOgretmen8 = ogretmenler.Where(x => x.Cinsiyet == "Erkek").ElementAtOrDefault(3);
            Console.WriteLine("\nListedeki 0.indexteki Erkek öğretmen: {0}", arananOgretmen7.TamAd);

            var derslerim = new DersService().GetDersler();
            var secmeliDersler = derslerim.OfType<SecmeliDers>().ToList();
            var dersler2 = derslerim.OfType<Ders>().ToList();

            var lisansUstuDersler = derslerim.OfType<LisansUstuDers>().ToList();

            Console.ReadLine();
        }
    }

    public class Ders
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }
        public int DersSaati { get; set; }
    }

    public class SecmeliDers : Ders
    {
        public int Kontenjan { get; set; }
    }

    public class LisansUstuDers : Ders
    {
        public string MyProperty { get; set; }
    }

    public class Ogretmen
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcKimlikNo { get; set; }
        public string Cinsiyet { get; set; }
        public string TamAd => Ad + " " + Soyad;
    }

    public class DersAlis
    {
        public string DersAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public int? OgretmenId { get; set; }

        public DersAlis()
        {

        }

        public DersAlis(string ad, string soyad, int yas, string cinsiyet, string dersAdi, int? ogretmenId)
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
                new DersAlis("Özge", "Test", 25, "Kadın", "Flutter", null),
            };
        }
    }

    public class OgretmenService
    {
        public List<Ogretmen> GetOgretmenler()
        {
            return new List<Ogretmen>()
            {
                new Ogretmen() { Id = 1, Ad = "Ahmet", Soyad = "Barın", Cinsiyet = "Erkek", TcKimlikNo = "12345678912" },
                new Ogretmen() { Id = 2, Ad = "Mehmet", Soyad = "Kiraz", Cinsiyet = "Erkek", TcKimlikNo = "12378912378" },
                new Ogretmen() { Id = 3, Ad = "Gülşah", Soyad = "Kiraz", Cinsiyet = "Kadın", TcKimlikNo = "999999999"},
            };
        }
    }

    public class DersService
    {
        public List<Ders> GetDersler()
        {
            return new List<Ders>()
            {
                new Ders() { Id = 1, DersAdi = "Deneme"},
                new Ders() { Id = 2, DersAdi = "Deneme"},
                new SecmeliDers() { Id = 3, DersAdi = "Deneme"},
                new LisansUstuDers() { Id = 4, DersAdi = "Deneme"},
            };
        }
    }

}