using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5API
{
    internal class Clubs
    {
        public string Name { get; set; }
        public int Club_ID { get; set; }
        public string URL { get; set; }
        public int Average_Daily_Rating { get; set; }
        public int Members_Count { get; set; }
        public double Created { get; set; }
        public double Last_Activity { get; set; }
        public string Join_Request { get; set; }
        public string[] admin { get; set; }

        public Clubs() { }

        public Clubs(string name, int club_id, string url, int average_daily_rating, int members_count, double created, double last_activity, string join_request)
        {
            Name = name;
            Club_ID = club_id;
            URL = url;
            Average_Daily_Rating = average_daily_rating;
            Members_Count = members_count;
            Created = created;
            Last_Activity = last_activity;
            Join_Request = join_request;
        }

        public override string ToString()
        {
            string msg = "";

            msg += "---------------------------------------------------\n";

            msg += $"Now viewing club: {Name}\n";
            msg += $"Club URL: {URL}\n";

            msg += $"\nTotal members: {Members_Count}\n";
            msg += $"Average DAILY rating: {Average_Daily_Rating}\n";
            msg += $"Created: {DateTime.UnixEpoch.AddSeconds(Created)}\n";
            msg += $"Last active: {DateTime.UnixEpoch.AddSeconds(Last_Activity)}\n";

            msg += "\nAdmins:\n";
            foreach (var a in admin)
            {
                msg += $"{a}\n";
            }

            msg += "\nExtra Info\n";
            msg += $"Club ID: {Club_ID}\n";
            msg += $"Join request URL: {Join_Request}\n";

            msg += "---------------------------------------------------\n";

            return msg;
        }
    }
}
