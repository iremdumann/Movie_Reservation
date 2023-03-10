/*  
director_name;
duration;
actor_2_name;
genres;
actor_1_name;
movie_title;
num_voted_users;
actor_3_name;
movie_imdb_link;
num_user_for_reviews;
language;country;
title_year;
imdb_score

*/
using System;
using System.Collections.Generic;
using System.IO;

namespace movie_database_lesson
{
    enum FiltreOp
    {
        Esit,
        Buyuk,
        Kucuk,
        BuyukEsit,
        KucukEsit
    }

    class Program
    {
        private static List<Movie> movies = new List<Movie>();
        private static List<string> countries = new List<string>();
        private static List<string> genres = new List<string>();
        private static List<Movie> filteredMovies = new List<Movie>();

        private static void Main()
        {
            Setup();
            // // Filtreler
            // // Yıl sayısal buyuk kucuk esit
            // // Süre sayısal buyuk kucuk esit
            // // Ulke : liste? içerir
            // // Tür : içerir // türlerin listesine 
            // if (filtreIsaretler.Contains(giris))
            // {

            //     int a = filtreIsaretler.IndexOf(giris);
            //     FiltreOp op = (FiltreOp)a;
            //     Console.WriteLine(op);
            //     Console.WriteLine("--------------------------");
            // }
            // --------------------------------------------
            bool devam = true;
            while (devam)
            {
                MenuListele();
                string giris = Console.ReadLine();
                switch (giris.ToUpper())
                {
                    case "1":
                        FiltreUlke();
                        FiltreYazdir();
                        break;
                    case "2":
                        FiltreTur();
                        FiltreYazdir();
                        break;
                    case "3":
                        FiltrelemeYillar();
                        FiltreYazdir();
                        break;
                    case "4":
                        break;
                    case "X":
                        devam = false;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Çıkış");
        }

        private static void MenuListele()
        {
            Console.WriteLine("Giriş(Çıkıs için (x)");
            Console.WriteLine("(1)Ülke");
            Console.WriteLine("(2)Tür");
            Console.WriteLine("(3)Yıl");
            Console.WriteLine("Seçim");
        }



        private static void FiltrelemeYillar()
        {

            List<string> filtreIsaretler = new List<string>{
                 "=",">","<",">=","<="
                };
            bool devam = true;
            while (devam)
            {
                Console.WriteLine("Yıl? Çıkış için (x)");
                Console.WriteLine("Giriş:");
                string giris = Console.ReadLine();
                if (giris.ToLower() == "x")
                    return;
                try
                {
                    string filtreIsaretTek = giris.Substring(0, 1);
                    string filtreIsaretIkili = giris.Substring(0, 2);
                    string girisSayi = giris;
                    FiltreOp op = (FiltreOp)filtreIsaretler.IndexOf("=");
                    int filtreUzunluk = 0;
                    //Bakar tek karakterli der <=2000
                    if (filtreIsaretler.Contains(filtreIsaretTek))
                    {
                        filtreUzunluk = 1;
                        op = (FiltreOp)filtreIsaretler.IndexOf(filtreIsaretTek);

                    }
                    //Bakar iki karakter varsa hayır iki karakter der diğer tez çürür  
                    if (filtreIsaretler.Contains(filtreIsaretIkili))
                    {
                        filtreUzunluk = 2;
                        op = (FiltreOp)filtreIsaretIkili.IndexOf(filtreIsaretIkili);
                    }
                    string filtreSayi = giris.Substring(filtreUzunluk);

                    if (!int.TryParse(filtreSayi, out int girisCevrilmisSayi))
                    {
                        throw new Exception();
                    }
                    FiltreleYil(op, girisCevrilmisSayi);
                    devam = false;
                }
                catch
                {

                    Console.WriteLine("Gecersiz giris!");
                }

            }
        }

        private static void FiltreleYil(FiltreOp op, int deger)
        {
            filteredMovies.Clear();

            foreach (var m in movies)
            {
                switch (op)
                {
                    case FiltreOp.Buyuk:
                        if (m.Title_year > deger)
                        {
                            filteredMovies.Add(m);
                        }
                        break;
                    case FiltreOp.Kucuk:
                        if (m.Title_year < deger)
                        {
                            filteredMovies.Add(m);
                        }
                        break;
                    case FiltreOp.Esit:
                        if (m.Title_year == deger)
                        {
                            filteredMovies.Add(m);
                        }
                        break;
                    case FiltreOp.BuyukEsit:
                        if (m.Title_year >= deger)
                        {
                            filteredMovies.Add(m);
                        }
                        break;
                    case FiltreOp.KucukEsit:
                        if (m.Title_year <= deger)
                        {
                            filteredMovies.Add(m);
                        }
                        break;
                    default:
                        if (m.Title_year == deger)
                            filteredMovies.Add(m);

                        break;
                }

                // if (m.Title_year == deger)
                // {
                //     filteredMovies.Add(m);
                // }

            }
            Console.WriteLine(op);
            Console.WriteLine(deger);
        }

        private static void FiltreUlke()
        {
            ListeleUlkelerUI();
            filteredMovies.Clear();
            Console.WriteLine("Ulke?");

            string ulke = Console.ReadLine();
            foreach (var m in movies)
            {
                if (m.Country == ulke)
                {
                    filteredMovies.Add(m);
                }
            }
        }

        private static void FiltreTur()
        {
            ListeleTurlerUI();
            filteredMovies.Clear();
            Console.WriteLine("Tur?");

            string tur = Console.ReadLine();
            foreach (var m in movies)
            {
                foreach (var t in m.Genres)
                {
                    if (t == tur)
                        filteredMovies.Add(m);
                }
            }
        }

        private static void ListeleUlkelerUI()
        {
            Console.Clear();
            foreach (var item in countries)
            {
                Console.Write($"| {item} ");
            }
        }

        private static void ListeleTurlerUI()
        {
            Console.Clear();
            foreach (var item in genres)
            {
                Console.Write($"| {item} ");
            }
        }

        private static void FiltreYazdir()
        {
            foreach (var item in filteredMovies)
            {
                Console.WriteLine($"{item.Country} : {item.Movie_title} : {item.Title_year}");
            }
        }

        #region  SETUP ve Yardimcilar 
        private static void Setup()
        {
            string dbDosyaAd = "movie_database.csv";
            movies = DbOKu(dbDosyaAd);
            //Test
            // foreach (var m in movies)
            //     Console.WriteLine(m.Id);
        }

        private static List<Movie> DbOKu(string dosya)
        {
            List<Movie> sonuc = new List<Movie>();
            string[] items = File.ReadAllLines(dosya);

            foreach (var i in items)
            {
                Movie movie = SatirIslem(i);
                sonuc.Add(movie);
            }

            return sonuc;
        }

        private static Movie SatirIslem(string item)
        {
            var movie = new Movie();
            string[] props = item.Split(';');

            movie.Director_name = props[0];

            if (int.TryParse(props[1], out int duration))
                movie.Duration = duration;

            movie.Actor_2_name = props[2];

            foreach (var t in TurListeEkle(props[3]))
            {
                movie.Genres.Add(t);
            }

            movie.Actor_1_name = props[4];
            movie.Movie_title = props[5];
            movie.Num_voted_users = props[6];
            movie.Actor_3_name = props[7];
            movie.Movie_imdb_link = props[8];
            movie.Num_user_for_reviews = props[9];
            movie.Language = props[10];

            //
            movie.Country = props[11];
            UlkeListeEkle(props[11]);

            if (int.TryParse(props[12], out int year))
                movie.Title_year = year;

            movie.Imdb_score = props[13];

            return movie;
        }

        private static void UlkeListeEkle(string ulke)
        {

            if (!countries.Contains(ulke) && !String.IsNullOrEmpty(ulke))
                countries.Add(ulke);
        }

        private static string[] TurListeEkle(string turler)
        {
            // "Action|Comedy|Dram"
            string[] parcalar = turler.Split('|');

            foreach (var item in parcalar)
            {
                string trimmed = item.Trim();
                if (!genres.Contains(trimmed) && !String.IsNullOrEmpty(trimmed))
                    genres.Add(trimmed);
            }

            return parcalar;
        }
        #endregion
    }
}