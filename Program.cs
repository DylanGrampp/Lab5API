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
                        Console.Clear();
                        break;

                }
            } while (menuInput != 4);
        }


        public static async void MainMenu()
        {
            Console.WriteLine("\n     Chess.com API\n     Programmed by: Dylan Grampp");
            Console.WriteLine("     -----------------------------\n");
            Console.WriteLine("     1. View a profile");
            Console.WriteLine("     2. Player stats");
            Console.WriteLine("     3. Leaderboard");
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
    }
}