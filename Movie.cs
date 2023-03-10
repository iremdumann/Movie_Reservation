using System.Collections.Generic;

namespace movie_database_lesson
{
    class Movie
    {
        private static int sayac;
        //   public int _id;
        public int Id { get; private set; }
        public string Director_name { get; set; }
        public int Duration { get; set; }
        public string Actor_2_name { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        // public string Genres { get; set; }
        public string Actor_1_name { get; set; }
        public string Movie_title { get; set; }
        public string Num_voted_users { get; set; }
        public string Actor_3_name { get; set; }
        public string Movie_imdb_link { get; set; }
        public string Num_user_for_reviews { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public int Title_year { get; set; }
        public string Imdb_score { get; set; }
        public Movie()
        {
            sayac++;
            Id = sayac;
        }
    }
}

