using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonClassLibrary;
using System.Threading;
using MonsterLibrary;


namespace DungeonApplication
{
    class Dungeon
    {
        static void Main(string[] args)
        {
            #region Weapon build

            Weapon shortSword = new Weapon(1, 10, "Short Sword", 10);
            Weapon longSword = new Weapon(5, 16, "Long Sword", 12);
            Weapon battleAxe = new Weapon(8, 25, "Battle Axe", 14);
            Weapon katana = new Weapon(13, 36, "Katana", 17);
            Weapon flamingkatana = new Weapon(20, 50, "Flaming Katana", 20);

            #endregion
            #region Title Menu

            Console.Title = "Dracula's Maze";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dracula's Maze");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Thread.Sleep(300);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(300);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Thread.Sleep(300);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Thread.Sleep(300);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Thread.Sleep(300);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t --------Dracula's Maze--------");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\tBy: Ryan Eutsler\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\tPlease open your console in full screen for best experience\n");
            Console.Write("\t\t\t\t\t\t\t\t\t\t\tPress Any Button to Start");
            Console.ReadLine();
            Console.Clear();
            #endregion

            bool isPlaying = true;

            while (isPlaying)
            {
                //TODO game story and concept intro
                Console.WriteLine("Strange Old Man: Tell me traveler, what is your name?");
                Console.Write("Type your character's name: ");
                string playerName = Console.ReadLine();
                Console.Clear();
                int treasures = 0;
                int roomsWon = 0;
                bool isAlive = true;
                Player player1 = new Player(playerName, 70, 5, 1000, 1000, 0, shortSword, 1, 1000, 10);//TODO adjust values 

                while (roomsWon <= 12 && isAlive)
                {
                   
                    Console.Title = (playerName + " | Health: " + player1.Life + "/" + player1.MaxLife + " | Weapon: " + player1.EquippedWeapon.Name +
                              " | Experience Points: " + player1.ExperiencePoints + " | Level: " + player1.PlayerLevel);
                    Console.WriteLine(playerName + " comes upon two doors: one to the left" +
                    " and one to the right. Which one will you enter? (R/L)");
                    ConsoleKey door = Console.ReadKey(true).Key;

                    Console.Clear();
                    switch (door)
                    {
                        case ConsoleKey.R:
                        case ConsoleKey.L:
                            Random rand = new Random();
                            int getEvent = rand.Next(1, 6);
                            #region Battle sequence
                            if (getEvent == 1 || getEvent == 2 || getEvent == 3 || getEvent == 4)
                            {
                                #region Monster objects

                                Bat bat = new Bat("Kinda Cute Bat", 38, 20, 38, 70, 2, 1, "Is THAT Dracula?! No.... but it's kinda cute");
                                Imp imp = new Imp("Imp", 50, 30, 50, 80, 2, 10, "Imp never quite recovered from his last break-up. His girlfriend left him for a gargole over a year ago. After a party phase and a failed go in the sales industry, Imp has been crashing on Dracula's couch while he finds himself");
                                Minotaur minotaur = new Minotaur("Minotaur", 60, 36, 60, 80, 3, 12, "It's not easy business, being a Minotaur gaurding Dracula's castle. Hours are long and he doesn't feel like he has much in common with his coworkers. But the dental benefits helped with his root canal last year and it puts bread on the table. Also has the head of a bull.");
                                DarkKnight knight = new DarkKnight("Dark Knight", 80, 45, 80, 82, 4, 20, "When he was 13 years old he told his parents \"It's not a phase,\" and boy he wasn't lying. Spending most of his time listening to old Cure, Depeche Mode and MCR (deep cuts only) records; this Dark Knight also enjoys gardening and cooking! He's not a bad guy once you get to know him.");
                                #endregion
                                #region Monster Array
                                Monster[] monsters = { imp, knight, bat, bat, knight, minotaur, imp };
                                Random randBattle = new Random();
                                int randomNbr = randBattle.Next(monsters.Length);
                                Monster monster = monsters[randomNbr];
                                #endregion

                                //loop for the menu
                                bool reload = false;

                                do
                                {
                                    Console.Title = (player1.Name + " | Health: " + player1.Life + "/" + player1.MaxLife + " | Weapon: " + player1.EquippedWeapon.Name +
                                     " | Experience Points: " + player1.ExperiencePoints + " | Level: " + player1.PlayerLevel);
                                    Console.WriteLine(monster.DisplayImage());
                                    Console.WriteLine("\nYou encountered a: " + monster.Name);
                                    #region MENU
                                    Console.WriteLine("\nWhat will you do?:\nA) Attack\nR) Run Away\nP) Player Info\nM) Monster Info\nX) Exit\n");
                                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                                    Console.Clear();

                                    switch (userChoice)
                                    {
                                        case ConsoleKey.A:
                                            //Engage battle sequence
                                            GetBattle.DoBattle(player1, monster);
                                            if (monster.Life <= 0)
                                            {
                                                //player wins
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                                Console.WriteLine("You gained {0}xp", );
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                reload = true;
                                                
                                                roomsWon++;
                                                //TODO add xp point field and properties to monsters
                                            }
                                            break;
                                        case ConsoleKey.R:
                                            Console.WriteLine("Run Away!!");
                                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                                            GetBattle.DoAttack(monster, player1); //free attack
                                            Thread.Sleep(600);
                                            reload = true;
                                            break;
                                        case ConsoleKey.P:
                                            Console.WriteLine("Player Info");
                                            //print out player info
                                            Console.WriteLine(player1);
                                            break;
                                        case ConsoleKey.M:
                                            Console.WriteLine("Monster Info");
                                            //monster info
                                            Console.WriteLine(monster);
                                            break;
                                        case ConsoleKey.X:
                                        case ConsoleKey.E: //or statements
                                            Console.WriteLine("No one likes a quitter....");
                                            isPlaying = true;//ends both do while loops and takes back to main
                                            break;

                                        default:
                                            Console.WriteLine("Thou hast chosen an improper option. Triest though again");
                                            break;
                                    }
                                    #endregion
                                    if (player1.Life <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Dude you're dead");
                                        isPlaying = false;
                                        reload = true;
                                        isAlive = false;
                                    }

                                } while (!reload);

                                Console.WriteLine("You won {0} room{1}", roomsWon, roomsWon > 1 ? "s" : "");
                                Console.Write("Press Enter to exit the room....");
                                Console.ReadLine();
                                Console.Clear();

                                #endregion
                            } //end if == 1 || 2 || 3 || 4
                            #region Treasure sequence
                            if (getEvent == 5)
                            {
                                TreasureRoom treasureRoom = new TreasureRoom();

                                ++treasures;
                                bool isTreasure = true;

                                do
                                {
                                    if (treasures == 1)
                                    {
                                        Console.WriteLine(treasureRoom.DisplayClosedChest());
                                        Console.WriteLine("You found a treasure chest!!!");
                                        Console.WriteLine("Press any button to open");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine(treasureRoom.DisplayOpenChest());
                                        player1.EquippedWeapon = longSword;
                                        Console.WriteLine("You found a Long Sword!!!!!");
                                        Thread.Sleep(3000);
                                        Console.WriteLine(player1.EquippedWeapon);
                                        Thread.Sleep(3000);
                                        player1.Life = player1.MaxLife;
                                        Console.WriteLine("Your health has also been restored!");
                                        Console.Write("Press any button to leave continue");
                                        Console.ReadLine();
                                        treasures++;
                                        Console.Clear();
                                        isTreasure = false;
                                    }
                                    if (treasures == 3)
                                    {
                                        Console.WriteLine(treasureRoom.DisplayClosedChest());
                                        Console.WriteLine("You found a treasure chest!!!");
                                        Console.WriteLine("Press any button to open");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine(treasureRoom.DisplayOpenChest());
                                        player1.EquippedWeapon = battleAxe;
                                        Console.WriteLine("You found a Battle Axe!!!!");
                                        Thread.Sleep(3000);
                                        Console.WriteLine(player1.EquippedWeapon);
                                        Thread.Sleep(3000);
                                        player1.Life = player1.MaxLife;
                                        Console.WriteLine("Your health has also been restored!");
                                        Console.Write("Press any button to leave continue");
                                        Console.ReadLine();
                                        treasures++;
                                        Console.Clear();
                                        isTreasure = false;
                                    }
                                    if (treasures == 5)
                                    {
                                        Console.WriteLine(treasureRoom.DisplayClosedChest());
                                        Console.WriteLine("You found a treasure chest!!!");
                                        Console.WriteLine("Press any button to open");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine(treasureRoom.DisplayOpenChest());
                                        player1.EquippedWeapon = katana;
                                        Console.WriteLine("You found a Katana!!!!");
                                        Thread.Sleep(3000);
                                        Console.WriteLine(player1.EquippedWeapon);
                                        Thread.Sleep(3000);
                                        player1.Life = player1.MaxLife;
                                        Console.WriteLine("Your health has also been restored!");
                                        Console.Write("Press any button to leave continue");
                                        Console.ReadLine();
                                        treasures++;
                                        Console.Clear();
                                        isTreasure = false;
                                    }
                                    if (treasures == 7)
                                    {
                                        Console.WriteLine(treasureRoom.DisplayClosedChest());
                                        Console.WriteLine("You found a treasure chest!!!");
                                        Console.WriteLine("Press any button to open");
                                        Console.ReadLine();
                                        Console.Clear();
                                        Console.WriteLine(treasureRoom.DisplayOpenChest());
                                        player1.EquippedWeapon = flamingkatana;
                                        Console.WriteLine("You found a Flaming Katana!!!!");
                                        Thread.Sleep(3000);
                                        Console.WriteLine(player1.EquippedWeapon);
                                        Thread.Sleep(3000);
                                        player1.Life = player1.MaxLife;
                                        Console.WriteLine("Your health has also been restored!");
                                        Thread.Sleep(2500);
                                        Console.Write("Press any button to leave continue");
                                        Console.ReadLine();
                                        treasures++;
                                        Console.Clear();
                                        isTreasure = false;
                                    }
                                    else { isTreasure = false; }
                                } while (isTreasure);//end isTreasure
                                #endregion
                            }//end if (getEvent == 3)
                            break;
                    }//end door switch

                }//end roomswon

                while (roomsWon == 13 && isAlive)
                {
                    //TODO 8: Dracula intro
                    Console.WriteLine("testing");
                    player1.Life = player1.MaxLife;
                    Thread.Sleep(6000);

                    Dracula dracula = new Dracula("Dracula", 200, 40, 200, 82, 5, 7, "Lord of the underworld and king of Vampires... also a total jerk.");
                   //TODO 9: DraculaBattle custom method
                    bool reload = false;

                    do
                    {
                        Console.Title = (player1.Name + " | Health: " + player1.Life + "/" + player1.MaxLife + " | Weapon: " + player1.EquippedWeapon.Name +
                         " | Experience Points: " + player1.ExperiencePoints + " | Level: " + player1.PlayerLevel);
                        Console.WriteLine(dracula.DisplayImage());
                        #region MENU
                        Console.WriteLine("\nWhat will you do?:\nA) Attack\nR) Run Away\nP) Player Info\nM) Monster Info\nX) Exit\n");
                        ConsoleKey userChoice = Console.ReadKey(true).Key;
                        Console.Clear();

                        switch (userChoice)
                        {
                            case ConsoleKey.A:
                                //Engage battle sequence
                                GetBattle.DoBattle(player1, dracula);
                                if (dracula.Life <= 0)
                                {
                                    //player wins
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nYou killed Dracula");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    reload = true;
                                    //outro = true;
                                }
                                break;
                            case ConsoleKey.R:
                                Console.WriteLine("You can't run away from Dracula, idiot");
                                Console.WriteLine($"{dracula.Name} attacks you as you flee!");
                                GetBattle.DoAttack(dracula, player1); //free attack
                                Thread.Sleep(6000);
                                break;
                            case ConsoleKey.P:
                                Console.WriteLine("Player Info");
                                Console.WriteLine(player1);
                                break;
                            case ConsoleKey.M:
                                Console.WriteLine("Monster Info");
                                Console.WriteLine(dracula);
                                break;
                            case ConsoleKey.X:
                            case ConsoleKey.E: 
                                Console.WriteLine("No one likes a quitter....");
                                isPlaying = true;//ends both do while loops and takes back to main
                                break;

                            default:
                                Console.WriteLine("Thou hast chosen an improper option. Triest though again");
                                break;
                        }
                        #endregion
                        if (player1.Life <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Dude you're dead");
                            isPlaying = false;
                            reload = true;
                            isAlive = false;
                        }

                    } while (!reload);
                    //    //TODO 10: Outro
                    //    //TODO 11: ConsoleReadKey and switch to play again or end isPlaying loop
                }//end while (roomsWon == 13 && isAlive)

            }//end isplaying

                Console.Clear();
                Console.WriteLine("Thanks for playing!\nCredits:\nCreator: Ryan Eutsler\n" +
                    "Executive Producer: Dick Wolf");

            }//end main
        }//end class
    }//end namespace

