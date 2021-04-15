using System;

namespace Dungeon_Game
{
    public class Encounters
    {
        static readonly Random rand = new Random();
        //Encounters Generic
        public static void UndeadFightEncounter()
        {
            Console.Clear();            
            Console.WriteLine("While looking for a way out, you turn the corner before you and see an undead monster...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You quietly open the door and grab a weapon off a nearby rack. You charge toward your captor.");
            Console.WriteLine("He turns...");
            Console.ReadKey();
            Combat(false, "Crypt Keeper", 1, 4);
        }       
        public static void NecromancerEncounter()
        {
            Console.Clear();            
            Console.WriteLine("The hallway ends at a door. The door slowly creaks open as you peer into the dark room. You see a tall ");
            Console.WriteLine("man with a long dark beard looking at a large tome.");
            Console.ReadKey();
            Combat(false, "Necromancer", 4, 2);
        }
        public static void MummyEncounter()
        {
            if(Program.currentPlayer.level >= 2)
            {
                Console.Clear();                
                Console.WriteLine("You open a door and the smell of rot assaults your senses.  As you swallow several times to avoid retching, ");
                Console.WriteLine("your eyes see movement accross the room.");
                Console.ReadKey();
                Combat(false, "Mummy", Program.currentPlayer.level, Program.currentPlayer.mods + Program.currentPlayer.level);
            }
            else
            {
                Console.Clear();                
                Console.WriteLine("You hope this door leads to an exit, but there is something waiting for you in the dark.");
                Console.ReadKey();
                Combat(true, "", 0, 0);
            }
        }
        public static void LichEncounter()
        {
            if (Program.currentPlayer.level >= 4)
            {
                Console.Clear();                
                Console.WriteLine("You find a laboratory with many tables scattered around the room.  Different tables are covered with books, beakers over flames, or ");
                Console.WriteLine("dead bodies that have been experimented on. A robed figure turns to face you, 'Thank you for volunteering'.");
                Console.ReadKey();
                Combat(false, "Lich", Program.currentPlayer.level + Program.currentPlayer.armorValue, Program.currentPlayer.mods + Program.currentPlayer.level + 
                    Program.currentPlayer.weaponValue);
            }
            else
            {
                Console.Clear();                
                Console.WriteLine("You are getting disoriented by the twists and turns of these corridors. The creatures don't have the same problem!");
                Console.ReadKey();
                Combat(true, "", 0, 0);
            }
        }
        //Encounter Tools
        public static void RandomMageAttack()
        {
            switch (rand.Next(0,4))
            {
                case 0:
                    Console.WriteLine("You speak strange words and raise your hands. A bold of arcane energy jumps from your fingers.");
                    break;
                case 1:
                    Console.WriteLine("You bring your wand up and point it at your enemy. Magic missles streak forward.");
                    break;
                case 2:
                    Console.WriteLine("The top of your staff glows bright red as a stream of fire engulfs your target.");
                    break;
                case 3:
                    Console.WriteLine("When you snap your fingers a bolt of lightning connects you to your target.");
                    break;
            }
        }
        public static void RandomWarriorAttack()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    Console.WriteLine("Your giant weapon drips with gore as you swing down on your enemy's head.");
                    break;
                case 1:
                    Console.WriteLine("With a mighty backstroke with your weapon bites deeply into your target's flank.");
                    break;
                case 2:
                    Console.WriteLine("You feint to the left to make them drop their guard on the right, you hear a crunch of bone.");
                    break;
                case 3:
                    Console.WriteLine("A huge uppercut nearly takes the head off your opponent.");
                    break;
            }
        }
        public static void RandomArcherAttack()
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    Console.WriteLine("Pulling the bow string taut, you aim for an eye and release the arrow.");
                    break;
                case 1:
                    Console.WriteLine("You take careful aim and hope this thing has a heart to pierce.");
                    break;
                case 2:
                    Console.WriteLine("As quick as thought, you fire and reload hoping your target stays down.");
                    break;
                case 3:
                    Console.WriteLine("Can you fire two arrows at once, you ask yourself. It's a good time to find out!");
                    break;
            }
        }
        public static void RandomEncounter()
        {
            switch (rand.Next(0,4))
            {
                case 0:
                    UndeadFightEncounter();
                    break;
                case 1:
                    NecromancerEncounter();
                    break;
                case 2:
                    MummyEncounter();
                    break;
                case 3:
                    LichEncounter();
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
                Console.WriteLine("Your advisary is a " + n + ".");
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("***************************");
                Console.WriteLine("|  (A)ttack  (D)efend    |");
                Console.WriteLine("|  (R)un     (H)eal      |");
                Console.WriteLine("***************************");
                Console.WriteLine(" (Q)uit Game");
                Console.WriteLine("Potions: " +Program.currentPlayer.potion+"   Health: "+Program.currentPlayer.health+"   Coins: "+Program.currentPlayer.coins);
                string input = Console.ReadLine();
                //Attack
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    if(Program.currentPlayer.currentClass == Player.PlayerClass.Warrior)
                    {
                        RandomWarriorAttack();
                        Console.WriteLine("As you step in for the kill, the " + n + " delivers its own attack.");
                    }
                    else if(Program.currentPlayer.currentClass == Player.PlayerClass.Mage)
                    {
                        RandomMageAttack();
                        Console.WriteLine("The " + n + " delivers its own attack at the same time.");
                    }
                    else
                    {
                        RandomArcherAttack();
                        Console.WriteLine("The " + n + " pulls the arrow from its body and stabs back at you.");
                    }                    
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, (Program.currentPlayer.level)) + ((Program.currentPlayer.currentClass == Player.PlayerClass.Warrior) ? 3:0);                    
                    if(attack >= ((Program.currentPlayer.level) + 1))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You find a weak spot in the " + n + "'s defenses! You have scored a critical hit and delt " + attack + " damage! You also suffer " + damage + " damage.");
                        Console.ResetColor();
                    }
                    else
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
                    if(Program.currentPlayer.currentClass != Player.PlayerClass.Archer && rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you turn to flee from the " + n + ", it's strike catches you in the back, sending you sprawling onto the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.health -= damage;                        
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
                        int potionV = 5 + ((Program.currentPlayer.currentClass == Player.PlayerClass.Mage)?+4:0);
                        Console.WriteLine("You gain " + potionV + " health.");
                        Program.currentPlayer.health += potionV;
                        Program.currentPlayer.potion -= 1;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                        int damage = (p / 2) - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health.");
                    }                    
                }
                //Quit in combat
                else if (input == "q" || input == "quit")
                {
                    Program.Quit();
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
            int x = Program.currentPlayer.GetXP();
            Console.WriteLine("As you stand victorious over the " + n + ", its body dissolves into " + c + " gold coins. You have gained "+x+" XP!");
            Program.currentPlayer.coins += c;
            Program.currentPlayer.xp += x;

            if (Program.currentPlayer.CanLevelUp())
            { 
                Program.currentPlayer.LevelUp();
                Program.currentPlayer.health += 15;
                Program.currentPlayer.coins += 100;
            }
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
                _ => "Crypt Keeper",
            };
        }
    }
}
