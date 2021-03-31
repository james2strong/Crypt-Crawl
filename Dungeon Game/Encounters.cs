using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Game
{
    class Encounters
    {
        static Random rand = new Random();
        //Encounters Generic


        //Encounters
        public static void FirstEncounter()
        {
            Console.WriteLine("You throw open the door and grab a rusty metal sword while charging toward your captor.");
            Console.WriteLine("He turns...");
            Console.ReadKey();
        }


        //Encounter Tools
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {

            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h > 0)
            { 
                Console.WriteLine("***************************");
                Console.WriteLine("|  (A)ttack  (D)efend    |");
                Console.WriteLine("|  (R)un     (H)eal      |");
                Console.WriteLine("***************************");
                Console.WriteLine("Potions: " +Program.currentPlayer.potions+"   Health: "+Program.currentPlayer.health);
                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("With haste you surge forth, your sword dancing in your hands! As you pass, the " + n + "strikes out at you as you pass.");
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1,4);                    
                    Console.WriteLine("You lose "+ damage + "health and deal " + attack + "damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine("As the " + n + "prepares to strike, you ready your sword in a defensive stance.");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + "health and deal " + attack + "damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if(rand.Next(0, 2) == 0);
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", it's strike cathes you in the back, sending you sprawling onto the ground.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + "health and are unable to escape.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape!");
                        Console.ReadKey();
                        //go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                }
                Console.ReadKey();
            }

        }
    }
}
