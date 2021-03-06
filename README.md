# Crypt-Crawl
Southern Indiana C# final project:

  I made a text based adventure game that lets you fight several different monsters.  You collect coins from the successful fights and can spend the coins in a shop to upgrade your weapon or armor.  You can also increase your difficulty level to make the fights harder.  The higher the difficulty level, the more coins you get from winning fights.  Your character also levels up from getting experience points for killing monsters.  I put in different fights based on your character level.  There are also three different classes of characters you can play.  The mage, warrior, and archer all have different attack codes and get bonuses to different abilities.
  
Feature list:
  1. Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program:

      --The master loop in Program.cs starting on line 24 runs the Encounters until the player chooses to quit the game or run away and arrive in the shop. You will continue to 
      get random fights until you quit or die. Use those healing potions! There are four different encounters at this time, but two of them are unlocked at character levels 2 
      and 4.
      
  2. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program:
  3. Implement a log that records errors, invalid inputs, or other important events and writes them to a text file:

      --(2&3)The player class is Serializable. When you choose to exit the game from either the shop or combat, your charater will be saved in a file created by Program.cs
        lines 84-90. The load function starts on Program.cs lines 93-110. After the first time you play the game, you can load characters off the list of saved characters. Try
        making one of each character class and playing a few levels of each. As long as you don't die, you can load them off the list of saved characters.
        
  4. Calculate and display data based on an external factor (ex: get the current date, and display how many days remaining until some event):

      --I put in a date count down function from the current day until Christmas 2021. It is Program.cs lines 194-206. I called the function at the start of the game and when 
        you enter the shop. It would be very easy to use this type of function for an in-game activity that was coming in the future. If I continue to work on this game, I will
        be putting in special event dates when you would fight creature types other than undead. It could be scheduled around holidays and themed accordingly. You could fight 
        cupid at Valentine's Day, leprechauns at St. Patrick's day, pumkins around Halloween, etc.  The date countdown function could easily be adjusted to count down to the
        start of the event or the end of the event. I can also make it appear anywhere in the game because it is written as a function.
