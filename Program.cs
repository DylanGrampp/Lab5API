using System;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Lab5API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           await Display();
        }
        
        public static async Task Display()
        {

            int menuInput;
            do
            {
                MainMenu();
                menuInput = Convert.ToInt32(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                       await Profile();
                        break;
                    case 2:
                        await TitledPlayers();
                        break;
                    case 3:
                        await ClubProfile();
                        break;

                }
            } while (menuInput != 4);
        }


        public static async void MainMenu()
        {
            Console.WriteLine("\n     Chess.com API\n     Programmed by: Dylan Grampp");
            Console.WriteLine("     -----------------------------\n");
            Console.WriteLine("     1. View a profile");
            Console.WriteLine("     2. View titled players");
            Console.WriteLine("     3. View Club information");
            Console.WriteLine("     4. Exit program\n");
            Console.Write($"     Please enter the number of your choice: ");
        }

        public static async Task Profile()
        {
            Console.Write("\nEnter the username of the chess account you would like to lookup: ");
            string username = Console.ReadLine();

            Console.Clear();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Authentication");

            HttpResponseMessage response = await client.GetAsync($"https://api.chess.com/pub/player/{username}");

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            Players p = JsonSerializer.Deserialize<Players>(json, options);
            Console.WriteLine(p);

            Console.WriteLine("\nProfile loaded. Press Enter to return to the main menu.");
            Console.ReadLine();

            Console.Clear();
        }

        public static async Task TitledPlayers()
        {
            Console.Write("\nEnter the title abbreviation you would like to lookup (GM, WGM, IM, WIM, FM, WFM, NM, WNM, CM, WCM): ");
            string userInput = Console.ReadLine().ToUpper();

            Console.Clear();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Authentication");

            HttpResponseMessage response = await client.GetAsync($"https://api.chess.com/pub/titled/{userInput}");

            string json = await response.Content.ReadAsStringAsync();

            TitledPlayers tp = JsonSerializer.Deserialize<TitledPlayers>(json);


            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Now viewing players with the title {userInput}:\n");

            if(tp.players.Length > 0)
            foreach(string players in tp.players)
            {
                Console.WriteLine(players);
            }
            else
            {
                Console.WriteLine("No players found with the title found");
            }

            Console.WriteLine("\nPlayers loaded. Press Enter to return to the main menu.");
            Console.ReadLine();

            Console.Clear();
        }

        public static async Task ClubProfile()
        {
            Console.Write("\nEnter the club url-ID (ex. https://www.chess.com/club/ --> chess-com-developer-community): ");
            string link = Console.ReadLine();

            Console.Clear();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Authentication");

            HttpResponseMessage response = await client.GetAsync($"https://api.chess.com/pub/club/{link}");

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            Clubs c = JsonSerializer.Deserialize<Clubs>(json, options);
            Console.WriteLine(c);

            Console.WriteLine("Club information loaded. Press Enter to return to the main menu.");
            Console.ReadLine();

            Console.Clear();
        }
    }
}