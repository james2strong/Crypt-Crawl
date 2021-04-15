using System;

namespace Dungeon_Game
{
    [Serializable]
    public class Player
    {    
        public string name;
        public int id;
        public int coins = 0;
        public int level = 1;
        public int xp = 0;
        public int health = 10;
        public int damage = 1;
        public int armorValue = 0;
        public int potion = 5;
        public int weaponValue = 1;
        public int mods = 0;
        public enum PlayerClass { Mage, Archer, Warrior };
        public PlayerClass currentClass = PlayerClass.Warrior;
        public int GetHealth()
        {
            int upper = (2 * mods + 5);
            int lower = (mods + 2);
            return Program.rand.Next(lower, upper);
        }
        public int GetPower()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }
        public int GetCoins()
        {
            int upper = ((15 * mods + 50) + (Program.currentPlayer.level * 3));
            int lower = ((10 * mods + 10) + (Program.currentPlayer.level * 3));
            return Program.rand.Next(lower, upper);
        }
        public int GetXP()
        {
            int upper = (20 * mods + 50);
            int lower = (15 * mods + 10);
            return Program.rand.Next(lower, upper);
        }
        public int GetLevelUpValue()
        {
            return 100 * level + 400;
        }
        public bool CanLevelUp()
        {
            if (xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }
        public void LevelUp()
        {            
            while(CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;                
            }            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Program.Print("Congrats! You are now level " + level + "!!!");
            Program.Print("You gain 15 health and 100 coins!");
            Console.ResetColor();
        }
    }    
}
