using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using DungeonMonsters;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "DUNGEON OF DOOM!";
            Console.WriteLine("Your journey begins...\n");

            //1 create a player
            //Need to make a weapon first because we only have a FQC that needs a weapon value
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, false);

            Player player = new Player("Leeroy Jenkins", 70, 5, 40, 40, Race.Elf, sword);
            //will also display weapon ToString() info!

            int score = 0; //do xp here for my own

            //2 create a loop for the room 

            bool exit = false;

            do
            {
                //3 create a room- write a () to get a room description
                Console.WriteLine(GetRoom());

                //4 create a monster
                //we need to learn about creating objects and then probably randomly
                //select one

                //Type Rabbit, hover over, go to Light Bulb, automatically creates using statement
                Rabbit r1 = new Rabbit();//uses the default ctor which sets some default values

                Rabbit r2 = new Rabbit("White Rabbit", 1000, 1000, 50, 20, 2, 10, "That's no ordinary rabbit!", true);

                //Since all children monsters are of type monster, we can store them in an array of monsters
                Monster[] monsters = { r1, r2, r1, r1, r2, r2 }; //Good place to put all types of monster for random battles

                //randomly select a monster from the array
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];
                
                //show monster in the room
                Console.WriteLine("\nIn this room: " + monster.Name);

                //5 create a loop for the menu
                bool reload = false;
                do
                {
                    //6 create a menu of options that tell the player what they can do
                    #region MENU
                    Console.WriteLine("\nPlease choose an action:\n" +
                    "A) Attack\nR) Run Away\nP) Player Info\nM) Monster Info\nX) Exit\n");

                    //7 catch users input               //true won't display key pressed
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    //8 Clear the Console after the user input to clean up screen
                    Console.Clear();

                    //9 Build out a switch for user choice
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            //10 Engage battle sequence
                            //11 Handle if the player wins
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                //it's dead
                                //You could put some logic here to have the player gets items, get life back or something similar
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                reload = true; //takes you back to menu
                                score++;
                            }
                        break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!");
                            //12 Handle running away and getting a new room
                            //13 Monster gets free attack
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player); //free attack
                            Console.WriteLine();
                            reload = true; //loads the new room with a new monster
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //TODO 14 Need to print out player info
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            //15 need to print monster info
                            Console.WriteLine(monster); //this will use polymorphism to get the correct ToString()
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E: //or statements
                            Console.WriteLine("No one likes a quitter....");
                            exit = true;//ends both do while loops and takes back to main
                            break;
                        
                        default:
                            Console.WriteLine("Thou hast chosen an improper option" +
                                ". Triest though again");
                            break;
                    }
                    #endregion

                    //check for the players life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude, you are dead.\a"); //\a makes a quick beep
                        exit = true; //ends external do while loop
                    }



                } while (!exit && !reload);//while exit and reload are not true 


            } while (!exit);//while exit is NOT TRUE keep looping

            Console.WriteLine($"You defeated {score} monster(s)");

        }//end main()

        private static string GetRoom()
        {
            string[] rooms = {
            "This hall is choked with corpses. The bodies of orcs and ogres lie in tangled heaps where they died, and the floor is sticky with dried blood. It looks like the orcs and ogres were fighting. Some side was the victor but you're not sure which one. The bodies are largely stripped of valuables, but a few broken weapons jut from the slain or lie discarded on the floor.",
            "This chamber of well-laid stones holds a wide bas-relief of a pastoral scene. In it you see a mountain like Mount Waterdeep, except that Castle Waterdeep and the city are missing. Instead, a small fishing village is a short way from a walled complex with several tall towers.",
            "Several white marble busts that rest on white pillars dominate this room. Most appear to be male or female humans of middle age, but one clearly bears small horns projecting from its forehead and another is spread across the floor in a thousand pieces, leaving one pillar empty.",
            "Three low, oblong piles of rubble lie near the center of this small room. Each has a weapon jutting upright from one end -- a longsword, a spear, and a quarterstaff. The piles resemble cairns used to bury dead adventurers.",
            "This chamber is clearly a prison. Small barred cells line the walls, leaving a 15-foot-wide pathway for a guard to walk. Channels run down either side of the path next to the cages, probably to allow the prisoners' waste to flow through the grates on the other side of the room. The cells appear empty but your vantage point doesn't allow you to see the full extent of them all.",
            "You push open the stone door to this room and note that the only other exit is a door made of wood. It and the table shoved against it are warped and swollen. Indeed, the table only barely deserves that description. Its surface is rippled into waves and one leg doesn't even touch the floor. The door shows signs of someone trying to chop through from the other side, but it looks like they gave up.",
            "A glow escapes this room through its open doorways. The masonry between every stone emanates an unnatural orange radiance. Glancing quickly about the room, you note that each stone bears the carving of someone's name.", //DM Note: Consider putting the name of one of your party's characters on the wall.
            "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on the floor nearby.",
            "The scent of earthy decay assaults your nose upon peering through the open door to this room. Smashed bookcases and their sundered contents litter the floor. Paper rots in mold-spotted heaps, and shattered wood grows white fungus.",
            "A skeleton dressed in moth-eaten garb lies before a large open chest in the rear of this chamber. The chest is empty, but you note two needles projecting from the now-open lock. Dust coats something sticky on the needles' points."
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length); //max random number = length of array (exculsive)

            string room = rooms[indexNbr];

            return room;

            //return rooms[new Random().Next(rooms.Length)]; also works but is less readable
        }//end GetRoom()
    }//end class
}//end namespace
