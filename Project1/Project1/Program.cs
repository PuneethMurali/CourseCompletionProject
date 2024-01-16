using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int PlayerAge { get; set; }
    }

    public interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class MyTeam : ITeam
    {
        public static List<Player> myTeam = new List<Player>();

        public MyTeam()
        {
            myTeam.Capacity = 11;
        }

        public void Add(Player player)
        {
            if (myTeam.Count < 11)
            {
                myTeam.Add(player);
                Console.WriteLine("Player is added successfully");
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team.");
            }
        }

        public void Remove(int playerId)
        {
            Player playerToRemove = myTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                myTeam.Remove(playerToRemove);
                Console.WriteLine("Player is removed successfully");
            }
            else
            {
                Console.WriteLine("Player not found in the team.");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return myTeam.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return myTeam.Find(p => p.PlayerName == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            return myTeam;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyTeam myTeam = new MyTeam();

            while (true)
            {
                Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Player newPlayer = new Player();
                        Console.WriteLine("Enter Player Id:");
                        newPlayer.PlayerId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Player Name:");
                        newPlayer.PlayerName = Console.ReadLine();

                        Console.WriteLine("Enter Player Age:");
                        newPlayer.PlayerAge = Convert.ToInt32(Console.ReadLine());

                        myTeam.Add(newPlayer);
                        break;
                    case 2:
                        Console.WriteLine("Enter Player Id to Remove:");
                        int idToRemove = Convert.ToInt32(Console.ReadLine());
                        myTeam.Remove(idToRemove);
                        break;
                    case 3:
                        Console.WriteLine("Enter Player Id:");
                        int idToSearch = Convert.ToInt32(Console.ReadLine());
                        Player foundById = myTeam.GetPlayerById(idToSearch);
                        if (foundById != null)
                        {
                            Console.WriteLine($"{foundById.PlayerId} {foundById.PlayerName} {foundById.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Player Name:");
                        string nameToSearch = Console.ReadLine();
                        Player foundByName = myTeam.GetPlayerByName(nameToSearch);
                        if (foundByName != null)
                        {
                            Console.WriteLine($"{foundByName.PlayerId} {foundByName.PlayerName} {foundByName.PlayerAge}");
                        }
                        else
                        {
                            Console.WriteLine("Player not found.");
                        }
                        break;
                    case 5:
                        List<Player> allPlayers = myTeam.GetAllPlayers();
                        foreach (Player player in allPlayers)
                        {
                            Console.WriteLine($"{player.PlayerId} {player.PlayerName} {player.PlayerAge}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Do you want to continue (yes/no)?");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToLower() != "yes")
                {
                    break;
                }
            }
        }
    }
}
