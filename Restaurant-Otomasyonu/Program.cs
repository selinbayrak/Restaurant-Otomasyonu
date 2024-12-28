using System.Collections;

namespace Restaurant_Otomasyonu
{
    public class Program
    {
        static public List<string> MusteriSecimleri = new List<string>();

        public static int bosmasa = 5;
        public static int KisiSayisi = 0;
        public static int Hesap;
        public static void Main(string[] args)

        {
            while (KisiSayisi != -1)
            {
                    Console.WriteLine("Merhaba Hosgeldiniz. Kaç kişi sipariş verecek?");
                    KisiSayisi = Convert.ToInt32(Console.ReadLine());
                
                    Menu.MenuYazdir(KisiSayisi);
                
                    for (int i = 1; i <= KisiSayisi; i++)
                    {
                        Console.WriteLine($"{i}. Müşteri, Bir Arzunuz Var Mı? (Evet/Hayır)");
                        string cevap = Console.ReadLine()?.ToLower();

                        while (cevap == "evet")
                        {
                            Console.WriteLine($"{i}. Müşteri, Ne Arzu Ederdiniz?");
                            string secim = Console.ReadLine();

                            if (secim.ToLower() == "bu kadar" || secim.ToLower() == "bir şey almayacagım")
                            {
                                Console.WriteLine("Tesekkür ederiz. Siparis tamamlandı.");
                                break;
                            }

                            if (Enum.TryParse(typeof(Menu.Icecekler), secim, true, out var icecek) ||
                                Enum.TryParse(typeof(Menu.AnaYemek), secim, true, out var anaYemek) ||
                                Enum.TryParse(typeof(Menu.Corba), secim, true, out var corba) ||
                                Enum.TryParse(typeof(Menu.Meze), secim, true, out var meze) ||
                                Enum.TryParse(typeof(Menu.YanLezzetler), secim, true, out var yanLezzet))
                            {
                                MusteriSecimleri.Add(secim);
                                Console.WriteLine($"{secim} sipariş edildi.");
                            }
                            else
                            {
                                Console.WriteLine("Üzgünüz, bu şu anda mevcut değil.");
                            }

                            Console.WriteLine("Başka bir arzunuz var mı? (Evet/Hayır)");
                            cevap = Console.ReadLine()?.ToLower();
                        }

                        if (cevap == "hayır")
                        {
                            Console.WriteLine("Tesekkür ederiz, sonraki müsteriye geçiliyor.");
                        }
                    }

                    Console.WriteLine("\nTüm Siparisler:");

                    foreach (var siparis in MusteriSecimleri)
                    {
                        Console.WriteLine($"- {siparis}");
                    }
                 }
        }
    }
    internal class Menu
    {
        public enum Icecekler : Int32

        {
            Kola = 35,
            Su = 10,
            Fanta = 35,
            MadenSuyu = 20,
            Cay = 15,
            MeyveSuyu = 25
        }
        public enum AnaYemek : Int32
        {

            OrmanKebabı = 190,
            Köfte = 200,
            Karniyarik = 190,
            TazeFasulye = 200,
            EtSote = 290,
            KuruFasulye = 120,
            Kavurma = 340
        }

        public enum Corba : Int32
        {
            Ezogelin = 95,
            Mercimek = 100,
            İskembe = 260,
            Tavuksuyu = 110,
            DomatesCorbasi = 150
        }

        public enum Meze : Int32
        {
            RusSalatasi = 120,
            Sarma = 120,
            Haydari = 100,
            AmerikanSalatasi = 120,
            Humus = 150
        }

        public enum YanLezzetler : Int32
        {
            Pilav = 80,
            Makarna = 100,
            Cacik = 90,
            Salata = 50,
            Tursu = 100
        }

        internal static int MenuYazdir(int KisiSayisi)
        {
            {
                for (int i = 1; i <= KisiSayisi; i++)

                {

                    Console.WriteLine($" {i}. Kisi İcin --- MENU --- ");

                    Console.WriteLine("\n Icecekler:");
                    foreach (var icecek in Enum.GetValues(typeof(Icecekler)))
                    {
                        Console.WriteLine($"{icecek}: {(int)icecek} TL");
                    }

                    Console.WriteLine("\nAna Yemekler:");
                    foreach (var yemek in Enum.GetValues(typeof(AnaYemek)))
                    {
                        Console.WriteLine($"{yemek}: {(int)yemek} TL");
                    }

                    Console.WriteLine("\nCorbalar:");
                    foreach (var corba in Enum.GetValues(typeof(Corba)))
                    {
                        Console.WriteLine($"{corba}: {(int)corba} TL");
                    }

                    Console.WriteLine("\nMezeler:");
                    foreach (var meze in Enum.GetValues(typeof(Meze)))
                    {
                        Console.WriteLine($"{meze}: {(int)meze} TL");
                    }

                    Console.WriteLine("\nYan Lezzetler:");
                    foreach (var yanLezzet in Enum.GetValues(typeof(YanLezzetler)))
                    {
                        Console.WriteLine($"{yanLezzet}: {(int)yanLezzet} TL");
                    }
                }
                return 0;
            }

        }
    }
    public class Masa : Program

    {
        public static bool MasaKontrol()
        {
            bosmasa--;

            if (bosmasa > 0 && bosmasa <= 5)
            {
                return true;
            }

            else return false;
        }
    }

}
