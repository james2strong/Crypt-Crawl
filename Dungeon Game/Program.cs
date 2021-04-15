using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dungeon_Game
{
    public class Program
    {
        public static Random rand = new Random();
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            if(!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
            currentPlayer = Load(out bool newP);
            if (newP)
            {
                Encounters.FirstEncounter();
            }
            while (mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }
        //Start new game
        static Player NewStart(int i)
        {
            Console.Clear();
            Player p = new Player();
            //GetDate();
            Console.WriteLine("Welcome to the Crypt Crawl!");
            Console.WriteLine("Character Name: ");
            p.name = Console.ReadLine();
            Print("Class: (M)age  (A)rcher  (W)arrior");
            bool flag = false;
            while (flag == false)
            {
                flag = true;
                string input = Console.ReadLine().ToLower();
                if (input == "mage" || input == "m")
                {
                    p.currentClass = Player.PlayerClass.Mage;
                }
                else if(input == "archer" || input == "a")
                {
                    p.currentClass = Player.PlayerClass.Archer;
                }
                else if(input == "warrior" || input == "w")
                {
                    p.currentClass = Player.PlayerClass.Warrior;
                }
                else
                {
                    Console.WriteLine("Please choose an existing class!");
                    flag = false;
                }
            }
            p.id = i;
            Console.Clear();
            Console.WriteLine("You awake in a cold, dark stone room. You feel dazed and are having trouble remembering");
            Console.WriteLine("anything about your past.");

            if (p.name == "")
                Console.WriteLine("You can't even remember your own name...");
            else
                Console.WriteLine("After a moment of struggle, you remember your name is " + p.name+".");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You search around in the darkness until you find a door handle. You feel some resistance as");
            Console.WriteLine("you turn the handle, but the rusty lock breaks with little effort. You see your captor");
            Console.WriteLine("standing with his back to you outside the door.");
            return p;
        }
        //Exit game and save player
        public static void Quit()
        {
            Save();
            Environment.Exit(0);
        }      
        public static void Save()
        {
            BinaryFormatter binForm = new BinaryFormatter();
            string path = "saves/" + currentPlayer.id.ToString() + ".level";
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binForm.Serialize(file, currentPlayer);
            file.Close();
        }
        //Load saved player
        public static Player Load(out bool newP)
        {
            newP = false;
            Console.Clear();           
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            int idCount = 0;

            BinaryFormatter binForm = new BinaryFormatter();
            foreach (string p in paths)
            {
                FileStream file = File.Open(p, FileMode.Open);
                Player player = (Player)binForm.Deserialize(file);
                file.Close();
                players.Add(player);
            }
            idCount = players.Count;

            while (true)
            {
                Console.Clear();
                GetDate();
                Print("Welcome to the Crypt Crawl!", 20);
                Print("Choose your player:", 60);
                foreach (Player p in players)
                {
                    Console.WriteLine(p.id + ": " + p.name);
                }
                Print("Please input player name or id (id:# or playername). Additionally, 'create' will start a new save.", 20);                
                string[] data = Console.ReadLine().Split(':');
                try
                {
                    if (data[0] == "id")
                    {
                        if(int.TryParse(data[1], out int id))
                        {
                            foreach (Player player in players)
                            {
                                if(player.id == id)
                                {
                                    return player;
                                }
                            }
                            Console.WriteLine("There is no player with that id!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                            Console.ReadKey();
                        }
                    }
                    else if(data[0] == "create")
                    {
                        Player newPlayer = NewStart(idCount);
                        newP = true;
                        return newPlayer;                        
                    }
                    else
                    {
                        foreach (Player player in players)
                        {
                            if(player.name == data[0])
                            {
                                return player;
                            }
                        }
                        Console.WriteLine("There is no player with that name!");
                        Console.ReadKey();
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Your id needs to be a number! Press any key to continue!");
                    Console.ReadKey();
                }
            }                        
        }
        //Text scrolling method
        public static void Print(string text, int speed = 40)
        {            
            foreach (char c in text)
            { 
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }            
            Console.WriteLine();
        }
        //Level progress bar
        public static void ProgressBar(string fillerCar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for(int i=0; i<size; i++)
            {
                if (i < dif)
                    Console.Write(fillerCar);
                else
                    Console.Write(backgroundChar);
            }
        }
        //Display time until Christmas
        public static void GetDate()
        {            
            DateTime daysLeft = DateTime.Parse("12/25/2021 12:00:01 AM");
            DateTime startDate = DateTime.Now;
            
            TimeSpan t = daysLeft - startDate;
            string countDown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds", t.Days, t.Hours, t.Minutes, t.Seconds);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are " + countDown + " until Christmas.", 10);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
