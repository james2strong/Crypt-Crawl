# Crypt-Crawl
Southern Indiana C# final project:

  I made a text based adventure game that lets you fight several different monsters.  You collect coins from the successful fights and can spend the coins in a shop to upgrade your weapon or armor.  You can also increase your difficulty level to make the fights harder.  The higher the difficulty level, the more coins you get from winning fights.  Your character also levels up from getting experience points for killing monsters.  I put in different fights based on your character level.  There are also three different classes of characters you can play.  The mage, warrior, and archer all have different attack codes and get bonuses to different abilities.
  
Feature list:
  1. Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program:
      --The master loop in Program.cs starting on line 24 runs the Encounters until the player chooses to quit the game or run away and arrive in the shop.
      
  2. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program:
  3. Implement a log that records errors, invalid inputs, or other important events and writes them to a text file:
      --The player class is Serializable. When you choose to exit the game from either the shop or combat, your charater will be saved in a file created by Program.cs lines 
        84-90. The load function starts is on Program.cs lines 93-110. After the first time you play the game, you can load characters off the list of saved characters. Try
        making one of each character class and playing a few levels of each. As long as you don't die, you can load them off the list of saved characters.
        
  4. Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event):
      --I put in a date count down function from the current day until Christmas 2021. It is Program.cs lines 194-206. I called the function at the start of the game and when 
        you enter the shop.
