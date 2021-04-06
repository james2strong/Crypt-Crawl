using System;

namespace Dungeon_Game
{
    public class Encounters
    {
        static readonly Random rand = new Random();
        //Encounters Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You quietly open the door and grab a sword off a nearby rack. You charge toward your captor.");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Human Rogue", 1, 4);
        }
        public static void UndeadFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("While looking for a way out, you turn the corner before you and see an undead monster...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void NecromancerEncounter()
        {
            Console.Clear();
            Console.WriteLine("The hallway ends at a door. The door slowly creaks open as you peer into the dark room. You see a tall ");
            Console.WriteLine("man with a long dark beard looking at a large tome.");
            Console.ReadKey();
            Combat(false, "Necromancer", 4, 2);
        }
        //Encounter Tools
        public static void RandomEncounter()
        {
            switch (rand.Next(0,2))
            {
                case 0:
                    UndeadFightEncounter();
                    break;
                case 1:
                    NecromancerEncounter();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("***************************");
                Console.WriteLine("|  (A)ttack  (D)efend    |");
                Console.WriteLine("|  (R)un     (H)eal      |");
                Console.WriteLine("***************************");
                Console.WriteLine("Potions: " +Program.currentPlayer.potion+"   Health: "+Program.currentPlayer.health+"   Coins: "+Program.currentPlayer.coins);
                string input = Console.ReadLine();
                //Attack
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {                    
                    Console.WriteLine("Quick as a cat you rush forward, your weapon dancing in your hands! ");
                    Console.WriteLine("As you attack, the " + n + " strikes out at you as you pass.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);                    
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                //Defend
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {                    
                    Console.WriteLine("As the " + n + " prepares to strike, you ready your weapon in an attempt to parry.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + " health and deal " + attack + " damage.");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                //Run
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {                    
                    if(rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you turn to flee from the " + n + ", it's strike catches you in the back, sending you sprawling onto the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.health -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Legs pumping, you run until the " + n + " is out of sight and you successfully escape!");
                        Console.ReadKey();
                        Shop.LoadShop(Program.currentPlayer);
                    }
                }
                //Heal
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {                    
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.WriteLine("As you desperately grasp for a potion in your bag, all that you feel are empty glass flasks.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " takes advantage of your lowered defenses. ");
                        Console.WriteLine("The " + n + " strikes out and you lose " + damage + " health!");
                    }
                    else
                    {
                        Console.WriteLine("You reach into your bag and pull out a glowing red flask. You take a long drink.");
                        int potionV = 5;
                        Console.WriteLine("You gain " + potionV + " health.");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion -= 1;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health.");
                    }
                    Console.ReadKey();
                }
                //Death Code
                if (Program.currentPlayer.health <= 0)
                {                    
                    Console.WriteLine("You feel the last of your strength leave you as the " + n + " stands stands over you, grinning at your pain.");
                    Console.WriteLine("You have been slain by the mighty " + n + ".");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = Program.currentPlayer.GetCoins();
            Console.WriteLine("As you stand victorious over the " + n + ", its body dissolves into " + c + " gold coins.");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
        public static string GetName()
        {
            return rand.Next(0, 4) switch
            {
                0 => "Skeleton",
                1 => "Zombie",
                2 => "Ghost",
                3 => "Ghoul",
                _ => "Human Rogue",
            };
        }
    }
}
