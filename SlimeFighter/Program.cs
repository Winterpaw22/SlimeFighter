using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;



namespace SlimeQuest
{
    class Program
    {
        /// <summary>
        /// 
        /// Created by John Sabins
        /// Application name: Slime fighter
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int windowHeight = 55;
            int windowWidth = 133;
            Console.SetWindowSize(windowWidth, windowHeight);
            int playTheGame = 1;
            playTheGame = MainMenu(playTheGame);
            if (playTheGame == 1)
            {
                Slime slime = new Slime();
                Player player = new Player();
                Ally ally = new Ally();
                // programmer: John Sabins
                // Program: Slime Fighter
                Console.Clear();

                ScreenWindows.DisplayTextboxMain();
                Console.SetCursorPosition(38, 14);
                Console.CursorVisible = true;
                bool nameSet = false;
                string playername = "Bob";
                while (!nameSet)
                {
                    Console.Write("What is your name young slime fighter:");
                    playername = Console.ReadLine();
                    if (playername.Length < 1)
                    {
                        Console.SetCursorPosition(38,15);
                        Console.Write("Please enter a name... ");
                        

                    }
                    else if (playername.Length >= 2)
                    {
                        nameSet = true;
                    }
                    Console.SetCursorPosition(38, 14);
                }
                
                Console.CursorVisible = false;

                #region intro
                Thread.Sleep(1000);
                Console.Clear();
                ScreenWindows.DisplayTextboxMain();
                Console.SetCursorPosition(38, 10);
                Console.WriteLine($"Welcome, {playername}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 11);
                Console.WriteLine("to an endless cave that only has slimes.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 12);
                Console.WriteLine("Slimes are said to be one of the easiest enemies. ");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 13);
                Console.WriteLine("Lets see if thats true.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 14);
                Console.WriteLine("Fight an onslaught of slimes to claim the Slime Crown.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 15);
                Console.WriteLine("A precious relic with immense healing capabilities.");
                Thread.Sleep(1000);
                #endregion

                ScreenWindows.DisplayContinuePrompt(90, 17);
                //----------------------Define player and attributes-----------


                InitializePlayer(player, playername);


                ScreenWindows.DisplayTextBoxPlayer();
                Console.SetCursorPosition(27, 32);
                Console.Write("You enter the cave and start walking down an endless corridor");
                Console.SetCursorPosition(27, 33);
                Console.Write("that you see no end to...");
                Thread.Sleep(2000);
                playTheGame = GameLoop(player, slime, ally);
            }

            if (playTheGame == 2) { Console.SetCursorPosition(55, 16); Console.WriteLine("Thanks for playing"); Thread.Sleep(2500); }
            else if (playTheGame == 3)
            {
                ScreenWindows.DisplayTextboxMain();
                Console.SetCursorPosition(59, 13);
                Console.Write("\\\\\\YOU WIN///");
                Console.SetCursorPosition(55, 14);
                Console.WriteLine("Thank you for playing");
                Console.ReadKey();

            }
        }

        /// <summary>
        /// Initializes the player
        /// </summary>
        /// <param name="player"> The player class that holds all the players stats</param>
        /// <param name="playerName"> Takes in the a name the player wants and names the player</param>
        public static void InitializePlayer(Player player, string playerName)
        {
            player.Name = playerName;
            player.Health = 100;
            player.MaxHealth = 100;
            player.Defense = 5;
            player.Damage = new int[2];
            player.Damage[0] = 1;
            player.Damage[1] = 7;
            player.Experience = 0;
        }

        static void InitializeAlly(Ally ally, Slime slime, Player player)
        {
            ally.Active = true;
            ally.Name = NameChecker();
            switch (ally.Charm)
            {
                case Ally.Charms.REDCHARM:
                    ally.Type = Ally.Effect.FIRE;
                    break;
                case Ally.Charms.BLUECHARM:
                    ally.Type = Ally.Effect.SHARPEN;
                    break;
                case Ally.Charms.PINKCHARM:
                    ally.Type = Ally.Effect.REGENERATION;
                    break;
                case Ally.Charms.GREENCHARM:
                    break;
                default:
                    break;
            }
            ally.Type = Ally.Effect.REGENERATION;
            ally.Name = NameChecker();
        }

        static string NameChecker()
        {
            bool noName = true;
            string name = "";
            while (noName)
            {
                Console.SetCursorPosition(27, 33);
                Console.Write("What would you like to name your new ally: ");
                name = Console.ReadLine();
                if (name.Length >= 3) { noName = false; }
                ScreenWindows.ClearPlayerTextBox();
                Console.SetCursorPosition(27, 34);
                Console.Write("Please use a name longer than 3 letters");
            }
            return name;
        }
        //-----------------------------Player Menu-------------------------------

        static void Player(Player player, Slime slime,Ally ally)
        {
            Random random = new Random();
            int damage = 1;
            //
            // PLAYER MENU
            //
            Console.Clear();
            ScreenWindows.DisplayGameScreen();
            ScreenWindows.DisplayTextBoxPlayer();
            int action;
            Console.CursorVisible = true;
            Console.SetCursorPosition(29, 33);
            Console.Write($" 1  Attack");
            Console.SetCursorPosition(50, 33);
            Console.Write($"{player.Name} : {player.Health}");
            Console.SetCursorPosition(29, 34);
            Console.Write($" 2  Throw a stick");
            Console.SetCursorPosition(50, 34);

            Console.Write($"Slime:{slime.Health}");
            if (ally.Active)
            {
                Console.SetCursorPosition(29, 35);
                Console.WriteLine($" 3  Ally");
            }
            Console.SetCursorPosition(34, 36);
            Console.WriteLine("Gold: " + player.Gold);
            Console.SetCursorPosition(34, 37);
            Console.WriteLine("Experience: " + player.Experience);

            int tOb = 33;
            int tObLast = 33;
            ConsoleKeyInfo keyPress;
            bool optionSelected = false;
            Console.CursorVisible = true;
            action = 1;
            Console.SetCursorPosition(26, 33);
            Console.Write("->");
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {

                    if (action == 2)
                    {
                        action--;
                        tOb--;
                    }
                    else if (action == 3)
                    {
                        action--;
                        tOb--;
                    }
                    Console.SetCursorPosition(26, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    if (action == 1)
                    {
                        action++;
                        tOb++;
                    }

                    if (ally.Active)
                    {
                        if (action == 2)
                        {
                            action++;
                            tOb++;
                        }
                    }

                    Console.SetCursorPosition(26, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }
                Console.SetCursorPosition(26,tObLast);

            }
            //
            // END PLAYER MENU
            //
            Console.CursorVisible = false;
            ScreenWindows.ClearPlayerTextBox();
            if (action == 1)
            {
                damage = random.Next(player.Damage[0], player.Damage[1]);
                //switch to visual effects (NOT DONE)
                Console.SetCursorPosition(27, 33);
                Console.Write($"You slash your sword at the slime and deal {damage} damage!");
                Thread.Sleep(1000);
                slime.Health = slime.Health - damage;
            }
            else if (action == 2)
            {
                //switch to visual effects (NOT DONE)
                Console.SetCursorPosition(27, 33);
                Console.Write("You throw a stick at the slime for no reason...");
                Console.SetCursorPosition(27, 33);
                Console.Write("It did nothing...");
                Thread.Sleep(1000);
            }
            else if (action == 3)
            {
                int healAmt = random.Next(2,10);
                player.Health = player.Health + healAmt;
                Console.SetCursorPosition(27, 33);
                Console.Write($"You let {ally.Name} heal you.");
                Console.SetCursorPosition(27, 34);
                Console.Write($"You healed for {healAmt} health!");
            }
        }

        //----------------------Slime AGRESSIVE AND ATTACKS------------------------------------

        static void SlimeATK(Player player, Slime slime)
        {
            //Setup
            ScreenWindows.ClearPlayerTextBox();
            Random random = new Random();
            int attack = random.Next(1, 2);
            int damage = 0;
            Console.SetCursorPosition(27, 34);
            //If else statement to handle what happens next
            if (attack == 1)
            {
                Console.WriteLine("The slime lunges at your face and latches on...");

                Thread.Sleep(1000);
                damage = random.Next(1, slime.Damage);
                Thread.Sleep(1000);
            }
            else if (attack == 2)
            {
                Console.WriteLine("The slime jumps at you and lands on your foot...");
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 35);
                Console.WriteLine("...");
                //SlimeType
                Thread.Sleep(1000);
            }
            else { Console.WriteLine("Error: No attack defined..."); }
            //Console.SetCursorPosition(27, 35);
            //if ()
            //{
            //    Console.WriteLine("You blocked the attack!");
            //    player.Defending = false;
            //}
            //else
            //{
            //    Console.WriteLine($"The slime deals {damage} damage.");
            //    player.Health = player.Health - damage;

            //}
            Thread.Sleep(1500);
            
        }

        //-----------------------------Slime PASSIVE-------------------------------------

        static void SlimePassive(Player player, Slime slime, Ally ally)
        {

            //Some setup
            ScreenWindows.DisplayGameScreen();
            ScreenWindows.DisplayTextBoxPlayer();
            ScreenWindows.SlimeAndChatColor(slime);
            ScreenWindows.DisplaySlime(slime);
            Random random = new Random();
            int slimePassive = random.Next(1, 4);
            bool fight = false;
            //The chances to happen
            ScreenWindows.ClearPlayerTextBox();
            if (slimePassive == 1)
            {
                Console.SetCursorPosition(27, 33);
                Console.Write("The slime slides around in a circle");
            }

            else if (slimePassive == 2)
            {
                Console.SetCursorPosition(27, 33);
                Console.Write("The slime lunges at you but misses...");

                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 34);
                Console.Write("It seems to want to play");
                Thread.Sleep(2000);
            }
            else if (slimePassive == 3)
            {
                Console.SetCursorPosition(27, 33);
                Console.Write("The slime jiggles it's body");
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 34);
                Console.Write("It seems to be taunting you");
            }
            else
            {

            }
            Thread.Sleep(2000);
            ScreenWindows.ClearPlayerTextBox();
            
            Console.SetCursorPosition(27, 31);
            Console.Write("Would you like to fight the slime minding its own buisness?");
            
            
            ConsoleKeyInfo keyPress;
            bool optionSelected = false;
            Console.CursorVisible = false;
            //Options
            Console.SetCursorPosition(33, 33);
            Console.Write("Yes");
            Console.SetCursorPosition(33, 34);
            Console.Write("No");
            ScreenWindows.DisplayTextBoxPlayer();
            fight = true;
            Console.SetCursorPosition(29, 33);
            Console.Write("->");
            int tOb = 33;
            int tObLast = 33;
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {
                    tOb = 33;
                    Console.SetCursorPosition(29, tObLast);
                    Console.Write("   ");
                    Console.SetCursorPosition(29, tOb);
                    Console.Write("-> ");
                    fight = true;
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    tOb = 34;
                    Console.SetCursorPosition(29, tObLast);
                    Console.Write("   ");
                    Console.SetCursorPosition(29, tOb);
                    Console.Write("-> ");
                    fight = false;
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }
                

            }
            ScreenWindows.ClearPlayerTextBox();

            Console.SetCursorPosition(27, 33);
            if (fight) { BattleLoop(player, slime, ally); }
            else if (!fight) { Console.Write("You continue on..."); }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //#------------------------------The actual game--------------------------
        static int GameLoop(Player player, Slime slime, Ally ally)
        {
            ScreenWindows.DisplayTextBoxPlayer();
            Random random = new Random();
            int end = 2;

            Console.Clear();
            ScreenWindows.DisplayGameScreen();
            ScreenWindows.DisplayTextBoxPlayer();
            int KingEncounter = 0;
            bool kingKilled = false;
            
            int nothing = 0;
            while ((player.Health > 0) && !kingKilled)
            {
                
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 32);
                Console.Write("You walk down a cave corridor...");

                int slimechance = random.Next(1, 4);
                Console.SetCursorPosition(27, 33);
                Thread.Sleep(2000);
                if (slimechance == 1)
                {
                    Console.Write("A slime Attacks!");
                    Thread.Sleep(1000);
                    
                    
                   

                    Slime.InitializeNewSlime(slime,ally);
                    ScreenWindows.DisplaySlime(slime);
                    BattleLoop(player, slime, ally);
                    nothing = 0;

                }
                if (slimechance == 2)
                {

                    Thread.Sleep(2000);
                    Slime.InitializeNewSlime(slime, ally);
                    Console.Write($"You have spotted a {slime.Color} slime minding its own buisness");
                    Thread.Sleep(1000);
                    ScreenWindows.DisplaySlime(slime);
                    SlimePassive(player, slime, ally);
                    nothing = 0;
                }

                else if (slimechance == 3)
                {
                    Console.Write("You got lucky and encountered no slimes");
                    Thread.Sleep(1000);
                    nothing++;
                }
                else
                {
                    Console.Write("Nothing happend and you move on");
                    nothing++;
                }

                if (nothing > 5)
                {
                    Console.WriteLine("A slime dropped onto your head and suprized you");
                    BattleLoop(player, slime, ally);
                    nothing = 0;
                }
                if (KingEncounter > 20)
                {
                    ScreenWindows.ClearPlayerTextBox();
                    Console.SetCursorPosition(27, 33);
                    Console.Write("You feel an intense presense up ahead");
                    for (int dot = 0; dot < 4; dot++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.SetCursorPosition(27, 34);
                    Console.Write("You get a glimpse of a regal slime hiding behind");
                    Console.SetCursorPosition(27, 35);
                    Console.Write("a nearby pillar... you enter the room filled with");
                    Console.SetCursorPosition(27, 36);
                    Console.Write("a powerful presence.");

                    ScreenWindows.DisplayContinuePrompt(103, 38);
                    slime.KingSlime = true;
                    Slime.InitializeNewSlime(slime, ally);
                    
                    BattleLoop(player, slime, ally);
                    kingKilled = true;
                    end = 3;
                }
                KingEncounter++;
                Thread.Sleep(2500);
                ScreenWindows.ClearPlayerTextBox();
                Console.ForegroundColor = ConsoleColor.Gray;
                ScreenWindows.ClearSlime();
            }
            return end;
        }

        static void BattleLoop(Player player, Slime slime, Ally ally)
        {
            Random random = new Random();
            do
            {
                ScreenWindows.ClearPlayerTextBox();
                if (slime.KingSlime)
                {
                    ScreenWindows.DisplayKingSlime();
                }
                else
                {
                    ScreenWindows.DisplaySlime(slime);
                }
                ScreenWindows.SlimeAndChatColor(slime);

                Player(player, slime, ally);
                Thread.Sleep(1000);
                ScreenWindows.ClearPlayerTextBox();
                if (slime.Health > 0)
                {
                    SlimeATK(player, slime);
                }
                

            } while ((player.Health > 0) && (slime.Health > 0));



            ScreenWindows.ClearPlayerTextBox();
            Console.ForegroundColor = ConsoleColor.Yellow;
            #region Gold and Experience
            int goldDrop;
            int exp;
            if (slime.KingSlime)
            {
                goldDrop = random.Next(60, 100);
                exp = random.Next(200,500);
            }
            else if (slime.Color == "red")
            {
                goldDrop = random.Next(20,30);
                exp = random.Next(100, 150);
            }
            else if (slime.Color == "blue")
            {
                goldDrop = random.Next(10, 15);
                exp = random.Next(60, 100);
            }
            else if (slime.Color == "green")
            {
                goldDrop = random.Next(4, 7);
                exp = random.Next(20, 60);
            }
            else
            {
                goldDrop = random.Next(2, 5);
                exp = random.Next(2, 30);
            }
            Console.SetCursorPosition(27, 33);
            Console.Write($"You have succeeded in battle and have recieved {goldDrop} Gold!");
            Console.SetCursorPosition(27,34);
            Console.Write($"You gained {exp} Experience Points!");
            #endregion

            

            if (slime.HasCharm)
            {
                InitializeAlly(ally, slime, player);
                Console.SetCursorPosition(27,34);
                Console.Write("You picked up a Slime charm... You put it around your neck.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 35);
                Console.Write("A little slime appears next to you and jumps on your head");
                Thread.Sleep(1000);
                switch (ally.Charm)
                {
                    case Ally.Charms.REDCHARM:
                        Console.SetCursorPosition(27, 36);
                        Console.Write("It appears the slime is wielding its own sword");
                        Thread.Sleep(2500);
                        Console.SetCursorPosition(27, 37);
                        Console.WriteLine("The slime fights along side you!");
                        Thread.Sleep(1000);
                        break;
                    case Ally.Charms.BLUECHARM:
                        Console.SetCursorPosition(27, 36);
                        Console.Write("The slime makes a small shield out of its own goo, ");
                        Thread.Sleep(2500);
                        Console.SetCursorPosition(27, 37);
                        Console.WriteLine("It seems to be trying to protect you...");
                        Thread.Sleep(1000);
                        break;
                    case Ally.Charms.PINKCHARM:
                        Console.SetCursorPosition(27, 36);
                        Console.Write("You feel your injuries heal slightly");
                        Thread.Sleep(2500);
                        Console.SetCursorPosition(27, 37);
                        Console.WriteLine("You regained 5 health!");
                        Thread.Sleep(1000);
                        player.Health = player.Health + 5;
                        if (player.Health > player.MaxHealth)
                        {
                            player.Health = player.MaxHealth;
                        }
                        break;
                    case Ally.Charms.GREENCHARM:
                        Console.SetCursorPosition(27, 36);
                        Console.Write("You start remembering more about your battle");
                        Thread.Sleep(2500);
                        Console.SetCursorPosition(27, 37);
                        Console.WriteLine("Experience boost!");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.SetCursorPosition(27, 36);
                        Console.Write("BROKEN ERROR ERROR ERROR ERROR");
                        Thread.Sleep(2500);
                        Console.SetCursorPosition(27, 37);
                        Console.WriteLine("SOME SHIT WENT DOWN NOW FIX OR WAIT A YEAR ");
                        Thread.Sleep(99999999);
                        break;
                }


                ScreenWindows.DisplayContinuePrompt(103, 38);
                ScreenWindows.ClearPlayerTextBox();

            }
            Console.ForegroundColor = ConsoleColor.Gray;
            player.Gold = player.Gold + goldDrop;
            ScreenWindows.DisplayContinuePrompt(103, 38);
        }

        static int MainMenu(int playthegame)
        {
            #region CREATETITLE
            ScreenWindows.DisplayTextboxMain();
            Console.SetCursorPosition(55, 12);
            Console.Write("-=|Slime Fighter|=-");
            Console.SetCursorPosition(59, 13);
            Console.Write("-THE GAME-");
            Console.SetCursorPosition(57, 18);
            Console.Write("By:John Sabins");
            #endregion
            //
            //------------------====MENU OPTIONS====-----------------
            //

            ConsoleKeyInfo keyPress;
            int tOb = 25;
            int tObLast = 25;
            bool optionSelected = false;
            Console.SetCursorPosition(55, 25);
            Console.Write("Start Fighting!");
            Console.SetCursorPosition(55, 27);
            Console.Write("Quit Game");
            Console.CursorVisible = false;
            Console.SetCursorPosition(52, tOb);
            Console.Write("->");
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {
                    tOb = 25;
                    Console.SetCursorPosition(52, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(52, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                    playthegame = 1;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    tOb = 27;
                    Console.SetCursorPosition(52, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(52, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                    playthegame = 2;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }
                Console.SetCursorPosition(52, tObLast);
            }
            return playthegame;
        }

        static void LevelUp(Player player)
        {
            Console.Clear();
            ScreenWindows.DisplayGameScreen();
            ScreenWindows.DisplayTextBoxPlayer();
            Console.CursorVisible = false;
            Console.SetCursorPosition(44,10);
            Console.Write("Health : " + player.MaxHealth);// left 54 for end || 57 for + 59 for health
            Console.SetCursorPosition(44, 12);
            Console.Write("Defense : " + player.Defense);// 55 for end, || 57 for + 59 for defense
            Console.SetCursorPosition(44, 14);
            Console.Write("Damage : " + player.Damage[1]);// left 54 for end || 57 for + 59 for damage
            //Options Health, Defense, Attack   
            //These will be added to the max
            int health = 0;
            int defense = 0;
            int damage = 0;
            int pointsAvlb = 3;
            //-------------------------------------
            Random random = new Random();
            int action;
            //Origin of tOb is unknown but now im calling it tOb as a reference to a tab. It works so shhhhh
            

            //Cursors current position
            int tOb = 10;
            //cursors last position
            int tObLast = 10;
            // Option Positions   28 : 17,18,19 
            ConsoleKeyInfo keyPress;
            bool optionSelected = false;
            Console.CursorVisible = true;
            action = 1;
            Console.SetCursorPosition(40, 10);
            Console.Write("->");
            while (!optionSelected)
            {

                keyPress = Console.ReadKey();
                //Movement for cursor tOb
                #region tOb movement
                if (keyPress.Key == ConsoleKey.UpArrow)
                {
                    
                    if (action == 2)
                    {
                        action--;
                        tOb--;
                        tOb--;
                    }
                    else if (action == 3)
                    {
                        action--;
                        tOb--;
                        tOb--;
                    }
                    Console.SetCursorPosition(40, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    if (action == 1)
                    {
                        action++;
                        tOb++;
                        tOb++;
                    }
                    else if (action == 2)
                    {
                        action++;
                        tOb++;
                        tOb++;
                    }

                    Console.SetCursorPosition(40, tObLast);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, tOb);
                    Console.Write("->");
                    tObLast = tOb;
                }
                #endregion

                if (keyPress.Key == ConsoleKey.RightArrow)
                {
                    if (action == 1)
                    {
                        if (pointsAvlb > 0)
                        {
                            //57 for + 59 for health
                            health++;
                            pointsAvlb--;
                            Console.SetCursorPosition(57,10);
                            Console.Write("+ " + health);
                        }
                    }
                    if (action == 2)
                    {
                        if (pointsAvlb > 0)
                        {
                            defense++;
                            pointsAvlb--;
                            Console.SetCursorPosition(57, 12);
                            Console.Write("+ " + defense);
                        }
                    }
                    if (action == 3)
                    {
                        if (pointsAvlb > 0)
                        {
                            damage++;
                            pointsAvlb--;
                            Console.SetCursorPosition(57, 14);
                            Console.Write("+ " + damage);
                        }
                    }

                }
                if (keyPress.Key == ConsoleKey.LeftArrow)
                {
                    if (action == 1)
                    {
                        if (pointsAvlb >= 0 && health != 0)
                        {
                            health--;
                            pointsAvlb++;
                            Console.SetCursorPosition(57, 10);
                            Console.Write("+ " + health);

                        }
                        else if (health <= 0)
                        {
                            Console.SetCursorPosition(57, 10);
                            Console.Write("           ");
                        }
                    }
                    if (action == 2)
                    {
                        if (pointsAvlb >= 0 && defense != 0)
                        {
                            defense--;
                            pointsAvlb++;
                            Console.SetCursorPosition(57, 12);
                            Console.Write("+ " + defense);

                        }
                        else if (defense <= 0)
                        {
                            Console.SetCursorPosition(57, 12);
                            Console.Write("           ");
                        }
                    }
                    if (action == 3)
                    {
                        if (pointsAvlb >= 0 && damage != 0)
                        {
                            damage--;
                            pointsAvlb++;
                            Console.SetCursorPosition(57, 14);
                            Console.Write("+ " + damage);

                        }
                        else if (damage <= 0)
                        {
                            Console.SetCursorPosition(57, 14);
                            Console.Write("           ");
                        }
                    }
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }
                Console.SetCursorPosition(0,0);
                Console.Write("health " + health + "| Defense " + defense + "| Damage " + damage + "| Points Available " + pointsAvlb);
                Console.SetCursorPosition(40, tObLast);

            }

            //applying the stat points to the player
            player.Health = player.Health + health;
            player.Defense = player.Defense + defense;
            player.Damage[1] = player.Damage[1] + damage;
            player.Damage[0] = player.Damage[0] + damage;
        }

       



    }
}