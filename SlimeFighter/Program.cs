using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SlimeQuest
{
    class Program
    {
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
                // programmer: John Sabins
                Console.Clear();
                DisplayTextboxMain();
                Console.SetCursorPosition(38, 14);
                Console.CursorVisible = true;
                Console.Write("What is your name young slime fighter:");
                string playername = Console.ReadLine();
                Console.CursorVisible = false;

                #region intro
                Thread.Sleep(1000);
                Console.Clear();
                DisplayTextboxMain();
                Console.SetCursorPosition(38, 10);
                Console.WriteLine($"Welcome, {playername}");
                Thread.Sleep(1000);
                Console.SetCursorPosition(38, 11);
                Console.WriteLine("to an endless cave that only has slimes.");
                Thread.Sleep(2000);
                Console.SetCursorPosition(38, 12);
                Console.WriteLine("Slimes are said to be one of the easiest");
                Thread.Sleep(2000);
                Console.SetCursorPosition(38, 13);
                Console.WriteLine("enemies. Lets see if thats true.");
                Thread.Sleep(2000);
                Console.SetCursorPosition(38, 14);
                Console.WriteLine("Fight an onslaught of slimes to claim the Slime Crown.");
                Thread.Sleep(2000);
                Console.SetCursorPosition(38, 15);
                Console.WriteLine("A precious relic with immense healing capabilities.");
                Thread.Sleep(2000);
                #endregion

                //            Console.WriteLine("You are givin a basic sword, a chunk of raw meat, a bucket of water\n" +
                //            "and 2 potions");
                //            Thread.Sleep(1500);
                DisplayContinuePrompt();
                //----------------------Define player inventory and attributes-----------
                InitializePlayer(player, playername);
                DisplayTextBoxPlayer();
                Console.SetCursorPosition(27, 32);
                Console.Write("You enter the cave and start walking down an endless corridor");
                Console.SetCursorPosition(27, 33);
                Console.Write("that you see no end to...");
                Thread.Sleep(2000);
                GameLoop(player, slime);
            }
            else { Console.SetCursorPosition(55, 16); Console.WriteLine("Thanks for playing"); Thread.Sleep(2500); }
        }

        static void InitializePlayer(Player player, string playerName)
        {
            player.Name = playerName;
            player.Health = 100;
            player.Damage = 5;
        }
        static void InitializeNewSlime(Slime slime, bool passive)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 3);

            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 2;
                slime.Color = "green";
            }
            else if (slimeType == 2)
            {
                slime.Health = 30;
                slime.Damage = 4;
                slime.Color = "blue";
            }
            else if (slimeType == 3)
            {
                slime.Health = 20;
                slime.Damage = 5;
                slime.Color = "red";
            }
            slime.Passive = passive;

        }
        //-----------------------------Player Menu-------------------------------
        static void Player(Player player, Slime slime)
        {
            //
            // PLAYER MENU
            //
            Console.Clear();
            DisplayGameScreen();
            DisplayTextBoxPlayer();
            int action;
            Console.CursorVisible = true;
            Console.SetCursorPosition(29, 33);
            Console.Write($" 1  Attack");
            Console.SetCursorPosition(50, 33);
            Console.Write($"{player.Name} : {player.Health}");
            Console.SetCursorPosition(29, 34);
            Console.Write($" 2  Defend");
            Console.SetCursorPosition(50, 34);
            Console.Write($"Slime:{slime.Health}");
            if (player.AllyPresent)
            {
                Console.SetCursorPosition(29, 35);
                Console.WriteLine($"| 3  Ally");
            }
            Console.SetCursorPosition(34, 36);
            Console.WriteLine("Gold: " + player.Gold);

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

                    if (action == 1)
                    {

                    }
                    else if (action == 2)
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
                    if (player.AllyPresent)
                    {
                        if (action == 2)
                        {
                            action++;
                            tOb++;
                        }
                    }
                    
                    else if (action == 3)
                    {
                        
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

            }
            //
            // END PLAYER MENU
            //
            Console.CursorVisible = false;

            if (action == 1)
            {
                //switch to visual effects
                Console.WriteLine($"You slash your sword at the slime and deal {player.Damage}");
                slime.Health = slime.Health - player.Damage;
            }
            else if (action == 2) { player.Defending = true; }
            else if (action == 3) { player.Health = player.Health + 2; }
        }


        //----------------------Slime AGRESSIVE AND ATTACKS------------------------------------
        static void SlimeATK(Player player, Slime slime)
        {

            //Setup
            Random random = new Random();
            int attack = random.Next(1, 2);
            int damage = 0;
            Console.SetCursorPosition(29, 33);
            //If else statement to handle what happens next
            if (attack == 1)
            {
                Console.WriteLine("The slime lunges at your face and latches on...");

                Thread.Sleep(2000);
                damage = random.Next(1, slime.Damage);
                Thread.Sleep(1000);
            }
            else if (attack == 2)
            {
                Console.WriteLine("The slime jumps at you and lands on your foot...");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                //SlimeType
                Thread.Sleep(1000);
            }
            else { Console.WriteLine("Error: No attack defined..."); }
            Console.SetCursorPosition(29, 34);
            if (player.Defending)
            {
                Console.WriteLine("You blocked the attack!");
                player.Defending = false;
            }
            else
            {
                Console.WriteLine($"The slime deals {damage} damage.");
                player.Health = player.Health - damage;

            }
            
        }


        //-----------------------------Slime PASSIVE-------------------------------------


        static void SlimePassive(Player player, Slime slime)
        {

            //Some setup
            Random random = new Random();
            int slimePassive = random.Next(1, 4);
            bool fight = false;
            SlimeAndChatColor(slime);
            Console.SetCursorPosition(29, 33);
            //The chances to happen

            if (slimePassive == 1) { Console.WriteLine("The slime slides around in a circle"); }

            else if (slimePassive == 2)
            {
                Console.WriteLine("The slime lunges at you but misses...");
                Console.WriteLine();

                Console.SetCursorPosition(29, 34);
                Thread.Sleep(1000);

                Console.WriteLine("It seems to want to play");
                Console.WriteLine();
                Thread.Sleep(2000);
            }
            else if (slimePassive == 3)
            {
                Console.WriteLine("The slime jiggles it's body");
                Thread.Sleep(1000);
                Console.SetCursorPosition(29, 34);
                Console.WriteLine("It seems to be taunting you");
                Console.WriteLine();
            }
            else
            {

            }
            Thread.Sleep(4000);
            Console.Clear();
            DisplayGameScreen();
            DisplayTextBoxPlayer();
            Console.SetCursorPosition(29, 33);
            Console.WriteLine("Would you like to fight the slime minding its own buisness?");
            
            
            ConsoleKeyInfo keyPress;
            bool optionSelected = false;
            Console.CursorVisible = false;
            //Options
            Console.SetCursorPosition(29, 33);
            Console.Write("Yes");
            Console.SetCursorPosition(29, 33);
            Console.Write("No");


            Console.SetCursorPosition(26, 33);
            Console.Write("->");
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(26, 34);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, 33);
                    Console.Write("->");
                    fight = true;

                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(26, 33);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, 34);
                    Console.Write("->");
                    fight = false;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }

            }
            if (fight) { BattleLoop(player, slime); }
            else if (fight) { Console.WriteLine("You continue on"); }
        }

        //#------------------------------The actual game--------------------------
        static void GameLoop(Player player, Slime slime)
        {
            bool doOnce = true;
            DisplayTextBoxPlayer();
            Random random = new Random();

            if (doOnce)
            {
                Console.Clear();
                DisplayGameScreen();
                DisplayTextBoxPlayer();
                doOnce = false;
            }

            while (player.Health > 0)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 32);
                Console.WriteLine("You walk down a cave corridor...");

                int slimechance = random.Next(1, 4);
                Console.SetCursorPosition(27,33);
                Thread.Sleep(2000);
                if (slimechance == 1)
                {
                    Console.SetCursorPosition(27, 33);
                    Console.WriteLine("A slime Attacks!");
                    Thread.Sleep(1000);
                    InitializeNewSlime(slime, false);
                    BattleLoop(player, slime);

                }
                else if (slimechance == 2)
                {

                    Thread.Sleep(2000);
                    Console.Clear();
                    InitializeNewSlime(slime, true);
                    Console.SetCursorPosition(27, 33);
                    Console.WriteLine($"You have spotted a {slime.Color} slime minding its own buisness");
                    SlimePassive(player, slime);
                }

                else if (slimechance == 3)
                {
                    Console.SetCursorPosition(27, 33);
                    Console.WriteLine("You got lucky and encountered no slimes");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.SetCursorPosition(27, 33);
                    Console.WriteLine("Nothing happend and you move on");
                }
                Thread.Sleep(3000);
                Console.SetCursorPosition(27, 32);
                Console.WriteLine("                                                                        ");
                Console.SetCursorPosition(27, 33);
                Console.WriteLine("                                                                        ");
            }
            
        }


        static void SlimeAndChatColor(Slime slime)
        {
            if (slime.Color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (slime.Color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (slime.Color == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        static void BattleLoop(Player player, Slime slime)
        {
            Random random = new Random();
            while (player.Health > 0 && slime.Health > 0)
            {
                Console.Clear();
                SlimeAndChatColor(slime);
                Player(player, slime);
                SlimeATK(player, slime);

            }
            int goldDrop = random.Next(2, 10);
            Console.WriteLine($"You have succeeded in battle... you recieved {goldDrop} Gold!");
            player.Gold = player.Gold + goldDrop;
            DisplayContinuePrompt();
        }


        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.SetCursorPosition(90, 18);
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
        }



        /// <summary>
        /// Enter a sentance of what kind of int number you wish to collect
        /// Data collection = Used to store the phrase
        /// Limitation      = Used to store what limitation the checker has
        /// Menu Limit      = Used for menu's that need a number for operating
        /// </summary>
        /// <param name="dataCollectionStatement">
        /// <param name="limitation">
        /// <param name="menuLimit">
        /// <returns></returns>
        static int NumberCatchandCheck(string dataCollectionStatement, string limitation, int menuLimit)
        {
            string userResponse;
            int number = 0;
            Console.Write(dataCollectionStatement);
            if (limitation == "noLimit")
            {
                userResponse = Console.ReadLine();
                while (!int.TryParse(userResponse, out number))
                {
                    Console.WriteLine("Please enter a valid number");
                    Console.Write(dataCollectionStatement);
                    userResponse = Console.ReadLine();
                }
            }
            else if (limitation == "menu")
            {
                bool withinParameters = false;
                while (!withinParameters)
                {
                    userResponse = Console.ReadLine();
                    while (!int.TryParse(userResponse, out number))
                    {
                        Console.WriteLine($"Please enter a valid number within range of 0-{menuLimit}:");
                        userResponse = Console.ReadLine();
                    }
                    if (number <= menuLimit && number > 0) withinParameters = true;
                }

            }
            else if (limitation == "byte")
            {
                bool withinParameters = false;
                while (!withinParameters)
                {


                    userResponse = Console.ReadLine();
                    while (!int.TryParse(userResponse, out number))
                    {
                        Console.WriteLine("Please enter a valid number within range of 0-255:");
                        Console.Write(dataCollectionStatement);
                        userResponse = Console.ReadLine();
                    }
                    if (number < 255 && number >= 0) withinParameters = true;
                    else Console.WriteLine("It is not within Parameters");
                }
            }
            else
            {
                //this is unused but is here to keep check and make sure the code cannot break
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("THIS DOES NOT WORK ");
                Console.WriteLine("This code has been written wrong and this method does not have the correct permissions to run correctly");
                Console.WriteLine("Please notify the developer of this problem");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Setting number to a default of 0");

            }
            return number;
        }

        static int MainMenu(int playthegame)
        {
            #region CREATETITLE
            int num = 1;
            for (int i = 0; i < 118; i++)
            {

                Console.Write(num);
                num++;
                if (num >= (10)) { Console.Write("|"); num = 1; }

            }
            num = 1;
            for (int i = 0; i < 50; i++)
            {

                Console.WriteLine(num);
                num++;
                if (num >= (10)) { Console.WriteLine("|"); num = 1; }
            }
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            int downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            Console.SetCursorPosition(34, 19);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
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
            bool optionSelected = false;
            Console.SetCursorPosition(55, 25);
            Console.Write("Start Fighting!");
            Console.SetCursorPosition(55, 27);
            Console.Write("Quit Game");
            Console.CursorVisible = false;
            Console.SetCursorPosition(52, 25);
            Console.Write("->");
            while (!optionSelected)
            {
                keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(52, 27);
                    Console.Write("  ");
                    Console.SetCursorPosition(52, 25);
                    Console.Write("->");
                    playthegame = 1;
                }
                if (keyPress.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(52, 25);
                    Console.Write("  ");
                    Console.SetCursorPosition(52, 27);
                    Console.Write("->");
                    playthegame = 2;
                }
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    optionSelected = true;
                }

            }
            return playthegame;
        }
        static void DisplayTextboxMain()
        {
            Console.Clear();
            #region Main
            int num = 1;
            for (int i = 0; i < 118; i++)
            {

                Console.Write(num);
                num++;
                if (num >= (10)) { Console.Write("|"); num = 1; }

            }
            num = 1;
            for (int i = 0; i < 50; i++)
            {

                Console.WriteLine(num);
                num++;
                if (num >= (10)) { Console.WriteLine("|"); num = 1; }
            }
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            int downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            Console.SetCursorPosition(34, 19);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            #endregion
        }

        static void DisplayTextBoxPlayer()
        {
            //top ONE
            int down = 31;
            Console.SetCursorPosition(25, 30);
            Console.Write("+");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=+");
            }

            //side left
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(25, down);
                Console.Write("|");
                down++;
            }
            down = 31;
            Console.SetCursorPosition(25, 40);
            Console.Write("+");
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=+");
            }

            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(105, down);
                Console.Write("|");
                down++;
            }
            down = 30;
        }

        static void DisplayGameScreen()
        {

            #region CREATETITLE
            //     ================TOP===========================
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            //=========================LEFT============================
            int downwardPOS = 9;
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //=========================RIGHT============================
            downwardPOS = 9;
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //=========================BOTTOM============================
            Console.SetCursorPosition(34, 27);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }

            #endregion
        }
    }
}