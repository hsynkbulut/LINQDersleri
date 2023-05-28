namespace Ders12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dersler = { "Matematik", "Fizik", "Kimya" };
            var sonucAll = dersler.All(x => x == "Ali"); //False
            var sonucAll2 = dersler.All(x => x.EndsWith("k")); //False
            var sonucAll3 = dersler.All(x => x.Contains("i")); //True
            Console.WriteLine("Dersler listesinin bütün elemanlarında 'Ali' var mı = " + sonucAll);
            Console.WriteLine("Dersler listesinin bütün elemanları 'k' ile bitiyor mu = " + sonucAll2);
            Console.WriteLine("Dersler listesinin bütün elemanları 'i' içeriyor mu = " + sonucAll3);

            //1.yol (kısa yol)
            var sonucContains = dersler.Contains("Kimya"); //True
            //2.yol (uzun yol)
            var sonucContains2 = dersler.Where(x => x == "Kimya").Any(); //True

            Console.WriteLine("Dersler listesinde 'Kimya' var mı = " + sonucContains);
            Console.WriteLine("Dersler listesinde hiç 'Kimya' var mı = " + sonucContains2);


            List<Ogrenci> ogrenciler = new List<Ogrenci>()
            {
                new Ogrenci{ Id = 1,  Ad = "Ali", Soyad = "Veli", Yas = 15 },
                new Ogrenci{ Id = 2,  Ad = "Ali 1", Soyad = "Veli 1", Yas = 30 },
                new Ogrenci{ Id = 3,  Ad = "Ali 2", Soyad = "Veli 2", Yas = 20 },
                new Ogrenci{ Id = 4,  Ad = "Ali", Soyad = "Veli 5", Yas = 50 },
            };

            var yaslarToplami = ogrenciler.Sum(x => x.Yas);
            var enYaslininYasi = ogrenciler.Max(x => x.Yas);
            var enGencinYasi = ogrenciler.Min(x => x.Yas);
            var yasOrtalamasi = ogrenciler.Average(x => x.Yas);
            Console.WriteLine("Öğrencilerin yaşları toplamı: " + yaslarToplami);
            Console.WriteLine("En büyük öğrencinin yaşı: " + enYaslininYasi);
            Console.WriteLine("En küçük öğrencinin yaşı: " + enGencinYasi);
            Console.WriteLine("Öğrencilerin yaş ortalaması: " + yasOrtalamasi);
            
            Console.WriteLine("=========================================================================");
            
            string[] sqlDersiAlanlar = { "Ali", "Veli", "Mehmet", "Ahmet" };
            string[] cSharpDersiniAlanlar = { "Fatma", "Ayşe", "Mehmet", "Ahmet", "Damla" };

            //Intersect(): İki kümenin kesişimi
            var ikiDersiBirdenAlanlar = sqlDersiAlanlar
                .Intersect(cSharpDersiniAlanlar)
                .ToList();
            Console.WriteLine("Intersect (Kesişim kümesi)teki ilk eleman: " + ikiDersiBirdenAlanlar[0]);

            // Sonuçları ekrana yazdırma
            Console.Write("İki dersi birden alan öğrenciler: ");
            foreach (var ogrenci in ikiDersiBirdenAlanlar)
            {
                Console.Write(ogrenci + " ");
            }

            //Except(): hariç tutar. Bu örnekte C# alanları hariç tutuyor. Fark kümesi için kullanılır.
            var sqlAlipCSharpAlmayanlar = sqlDersiAlanlar
                .Except(cSharpDersiniAlanlar)
                .ToList();
            Console.Write("\nSQL dersini alan fakat C# dersini almayan öğrenciler: ");
            foreach (var ogrenci in sqlAlipCSharpAlmayanlar)
            {
                Console.Write(ogrenci + " ");
            }

            //Union(): İki kümenin birleşimi
            var dersAlanlar = sqlDersiAlanlar
                .Union(cSharpDersiniAlanlar)
                .ToList();
            Console.Write("\nToplam ders alan öğrenciler: ");
            foreach (var ogrenci in dersAlanlar)
            {
                Console.Write(ogrenci + " ");
            }

            //AddRange(): Listeye ekleme yapar.
            var liste = sqlDersiAlanlar.ToList();
            liste.AddRange(cSharpDersiniAlanlar);
            Console.WriteLine("\n\nsqlDersiAlanlar listesine cSharpDersiniAlanlar listesinin eklenmiş hali (liste): ");
            foreach (var item in liste)
            {
                Console.Write(item + " ");
            }

            //Distinct(): Farklı olanları (yani özgün olanları) getirir.
            var ssss = liste.Distinct().ToList();
            Console.WriteLine("\n\nliste adlı listteki tekil değerler: ");
            foreach (var item in ssss)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    public class Ogrenci
    {
        public int Id { get; set; }
        public int Yas { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}