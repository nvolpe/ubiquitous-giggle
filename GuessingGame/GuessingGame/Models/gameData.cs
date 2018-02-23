using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace GuessingGame.Models
{
    class GameData
    {
        //public Meta _meta { get; set; }
        //public List<Fixture> fixtures { get; set; }
        public List<Player> Players { get; set; }
        //public List<Team4> teams { get; set; }
    }

    public class Default
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Images
    {
        public Default @default { get; set; }
    }

    public class News
    {
        public DateTime latest { get; set; }
    }

    public class Player
    {
        public string first_name { get; set; }
        //public Fixture2 fixture { get; set; }
        public double? fppg { get; set; }
        public string id { get; set; }
        public Images images { get; set; }
        public bool injured { get; set; }
        public string injury_details { get; set; }
        public string injury_status { get; set; }
        public string last_name { get; set; }
        //public News news { get; set; }
        public int? played { get; set; }
        public string player_card_url { get; set; }
        public string position { get; set; }
        public bool removed { get; set; }
        public int salary { get; set; }
        public object starting_order { get; set; }
        //public Team3 team { get; set; }
    }
}