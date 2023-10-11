using System.ComponentModel.DataAnnotations;

namespace Lab5API
{
    internal class Players
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty; 
        public string Username { get; set; } = string.Empty;
        public int Player_ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int Joined { get; set; }
        public int Last_Online { get; set; }
        public int Followers { get; set; }
        public bool Is_Streamer { get; set; }
        public string Twitch_Url { get; set; } = string.Empty;
        public string League { get; set; } = string.Empty;


        public Players() { }

        public Players(string name, string url, string username, int player_id, string title, string status, string location, string country, int joined, int last_online, int followers, bool is_streaner, string twitch_url, string league)        
        {
            Name = name;
            Url = url;
            Username = username;
            Player_ID = player_id;
            Title = title;
            Status = status;
            Location = location;
            Country = country;
            Joined = joined;
            Last_Online = last_online;
            Followers = followers;
            Is_Streamer = is_streaner;
            Twitch_Url = twitch_url;
            League = league;
        }

        public override string ToString()
        {
            string msg = "";

            msg += "\n---------------------------------------------------\n";

            msg += $"Now viewing user: {Username} \n";
            msg += $"Last Online (GMT): {DateTime.UnixEpoch.AddSeconds(Last_Online)}\n";

            msg += $"\nPlayer name: {Name}\n";
            msg += $"Location: {Location}\n";
            msg += $"Followers: {Followers}\n";
            msg += $"Chess title: {Title}\n";
            msg += $"Current League: {League}\n";
            if (Is_Streamer == true)
            {
                msg += $"Streamer: Yes\n{Twitch_Url}\n";
            }
            else
            {
                msg += "Streamer: No\n";
            }
            //msg += $"Account status: {Status}\n";
            //msg += $"Followers: {Followers}\n";


            msg += $"\nAccount status: {Status}\n";
            msg += $"Account created (GMT): {DateTime.UnixEpoch.AddSeconds(Joined)}\n";
            /*if(Is_Streamer == true)
            {
                msg += $"Streamer: Yes\n";
            }
            else
            {
                msg += "Streamer: No\n";
            }*/
            //msg += $"Streamer: {Is_Streamer}";
            //msg += $"Last Online (GMT): {DateTime.UnixEpoch.AddSeconds(Last_Online)}\n";

            msg += "\nExtra Info\n";
            msg += $"Player ID: {Player_ID}\n";
            msg += $"Account country: {Country}\n";
            msg += $"Link to account: {Url}\n";

            msg += "---------------------------------------------------";

            /* msg += "\n     Chess.com API\n     Programmed by: Dylan Grampp";
            msg += "\n     -----------------------------\n";
            msg += "     1. View a profile\n";
            msg += "     2. Player stats\n";
            msg += "     3. Leaderboard\n";
            msg += "     4. Exit program\n";
            msg += $"     \nPlease enter the number of your choice: ";
           */

            return msg; 
        }

    }
}
