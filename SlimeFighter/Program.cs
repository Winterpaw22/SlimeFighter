﻿using System;
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
                
                DisplayTextboxMain();
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
                DisplayTextboxMain();
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

                DisplayContinuePrompt(90, 17);
                //----------------------Define player and attributes-----------
                InitializePlayer(player, playername);
                DisplayTextBoxPlayer();
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
                DisplayTextboxMain();
                Console.SetCursorPosition(59, 13);
                Console.Write("\\\\\\YOU WIN///");
                Console.SetCursorPosition(55, 14);
                Console.WriteLine("Thank you for playing");
                Console.ReadKey();

            }
        }

        static void InitializePlayer(Player player, string playerName)
        {
            player.Name = playerName;
            player.Health = 100;
            player.Damage = new int[2];
            player.Damage[0] = 1;
            player.Damage[1] = 7;
            player.Experience = 0;
        }

        private void InitializeAlly(Ally ally, string charm)
        {
            ally.Active = true;
            ally.Name = NameChecker();
            ally.Charm = true;
            ally.Type = Ally.Effect.REGENERATION;
            ally.Name = NameChecker();
        }

        public string NameChecker()
        {
            bool noName = true;
            string name = "";
            while (noName)
            {
                Console.SetCursorPosition(27, 33);
                Console.Write("What would you like to name your new ally: ");
                name = Console.ReadLine();
                if (name.Length >= 3) { noName = false; }
                ClearPlayerTextBox();
                Console.SetCursorPosition(27, 34);
                Console.Write("Please use a name longer than 3 letters");
            }
            return name;
        }

        static void InitializeNewSlime(Slime slime, bool passive, Player player, Ally ally)
        {
            //A random system to handle the slime
            Random random = new Random();
            int slimeType = random.Next(1, 5);

            if (slimeType == 1)
            {
                slime.Health = 20;
                slime.Damage = 2;
                slime.Color = "green";
                slime.AllyCharm = false;
            }
            else if (slimeType == 2)
            {
                slime.Health = 30;
                slime.Damage = 4;
                slime.Color = "blue";
                slime.AllyCharm = false;
            }
            else if (slimeType == 3)
            {
                slime.Health = 20;
                slime.Damage = 5;
                slime.Color = "red";
                slime.AllyCharm = false;
            }
            else if (slimeType == 4)
            {
                if (ally.Active)
                {
                    slime.Health = 45;
                    slime.Damage = 3;
                    slime.Color = "pink";
                    slime.AllyCharm = true;
                }

            }
            else
            {
                //just in case something goes wrong a slime is still initialized, although a weak one
                slime.Health = 10;
                slime.Damage = 1;
                slime.Color = "pine";
                slime.AllyCharm = false;

            }
            if (slime.KingSlime)
            {
                slime.AllyCharm = false;
                slime.Health = 55;
                slime.Damage = 10;
                slime.Color = "purple";
            }
            slime.Passive = passive;

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
            if (ally.Charm)
            {
                Console.SetCursorPosition(29, 35);
                Console.WriteLine($" 3  Ally");
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
            ClearPlayerTextBox();
            if (action == 1)
            {
                damage = random.Next(player.Damage[0], player.Damage[1]);
                //switch to visual effects (NOT DONE)
                Console.SetCursorPosition(27, 33);
                Console.Write($"You slash your sword at the slime and deal {damage} damage!");
                Thread.Sleep(1000);
                slime.Health = slime.Health - damage;
            }
            //else if (action == 2) { player.Defending = true; }
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
            ClearPlayerTextBox();
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
            DisplayGameScreen();
            DisplayTextBoxPlayer();
            SlimeAndChatColor(slime);
            DisplaySlime(slime);
            Random random = new Random();
            int slimePassive = random.Next(1, 4);
            bool fight = false;
            //The chances to happen
            ClearPlayerTextBox();
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
            ClearPlayerTextBox();
            
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
            DisplayTextBoxPlayer();
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
            ClearPlayerTextBox();

            Console.SetCursorPosition(27, 33);
            if (fight) { BattleLoop(player, slime, ally); }
            else if (!fight) { Console.Write("You continue on..."); }
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //#------------------------------The actual game--------------------------
        static int GameLoop(Player player, Slime slime, Ally ally)
        {
            DisplayTextBoxPlayer();
            Random random = new Random();
            int end = 2;

            Console.Clear();
            DisplayGameScreen();
            DisplayTextBoxPlayer();
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
                    
                    InitializeNewSlime(slime, false, player,ally);
                    DisplaySlime(slime);
                    BattleLoop(player, slime, ally);
                    nothing = 0;

                }
                if (slimechance == 2)
                {

                    Thread.Sleep(2000);
                    InitializeNewSlime(slime, true, player, ally);
                    Console.Write($"You have spotted a {slime.Color} slime minding its own buisness");
                    Thread.Sleep(1000);
                    DisplaySlime(slime);
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
                    ClearPlayerTextBox();
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
                    DisplayContinuePrompt(103, 38);
                    slime.KingSlime = true;
                    InitializeNewSlime(slime, false, player, ally);
                    
                    BattleLoop(player, slime, ally);
                    kingKilled = true;
                    end = 3;
                }
                KingEncounter++;
                Thread.Sleep(2500);
                ClearPlayerTextBox();
                Console.ForegroundColor = ConsoleColor.Gray;
                ClearSlime();
            }
            return end;
        }

        static void BattleLoop(Player player, Slime slime, Ally ally)
        {
            Random random = new Random();
            do
            {
                ClearPlayerTextBox();
                if (slime.KingSlime)
                {
                    DisplayKingSlime();
                }
                else
                {
                    DisplaySlime(slime);
                }
                SlimeAndChatColor(slime);

                Player(player, slime, ally);
                Thread.Sleep(1000);
                ClearPlayerTextBox();
                if (slime.Health > 0)
                {
                    SlimeATK(player, slime);
                }
                

            } while ((player.Health > 0) && (slime.Health > 0));

            ClearPlayerTextBox();
            Console.ForegroundColor = ConsoleColor.Yellow;
            int goldDrop;

            if (slime.KingSlime)
            {
                goldDrop = random.Next(5, 20);
            }
            else
            {
                goldDrop = random.Next(2, 10);
            }
            Console.SetCursorPosition(27, 33);
            Console.WriteLine($"You have succeeded in battle and have recieved {goldDrop} Gold!");
            if (slime.AllyCharm)
            {
                Console.SetCursorPosition(27,34);
                Console.Write("You picked up a Slime charm... You put it aroudn your neck.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 35);
                Console.Write("A little slime appears next to you and jumps on your head");
                Thread.Sleep(1000);
                Console.SetCursorPosition(27, 36);
                Console.Write("You feel your injuries heal slightly");
                Thread.Sleep(2500);
                Console.SetCursorPosition(27, 37);
                Console.WriteLine("You regained 5 health!");
                Thread.Sleep(1000);
                player.Health = player.Health + 5;
                DisplayContinuePrompt(103, 38);
                ClearPlayerTextBox();

            }
            Console.ForegroundColor = ConsoleColor.Gray;
            player.Gold = player.Gold + goldDrop;
            DisplayContinuePrompt(103, 38);
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt(int across, int down)
        {
            Console.WriteLine();
            Console.SetCursorPosition(across, down);
            Console.CursorVisible = true;
            Console.ReadKey();
            Console.CursorVisible = false;
            Console.SetCursorPosition(27, 33);
        }

        static int MainMenu(int playthegame)
        {
            #region CREATETITLE
            DisplayTextboxMain();
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

        /// <summary>
        /// Displays the mainscreen textbox
        /// </summary>
        static void DisplayTextboxMain()
        {
            Console.Clear();
            #region Main
            //Across Top
            Console.SetCursorPosition(34, 8);
            Console.Write("+");
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=+");
            }
            //Down Left
            int downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(34, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //Down Right
            downwardPOS = 9;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(94, downwardPOS);
                Console.WriteLine("|");
                downwardPOS++;

            }
            //Across Bottom
            Console.SetCursorPosition(34, 19); //90  // 16
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
            //Across bottom
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

        static private void DisplaySlime(Slime slime)
        {
            SlimeAndChatColor(slime);
            Console.SetCursorPosition(35, 16);
            Console.Write("                      =======                             ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                  ====       ====                         ");
            Console.SetCursorPosition(35, 18);
            Console.Write("               ===              ===                       ");
            Console.SetCursorPosition(35, 19);
            Console.Write("             ==     v       v     ==                      ");
            Console.SetCursorPosition(35, 20);
            Console.Write("           ===     (6)     (9)     ===                    ");
            Console.SetCursorPosition(35, 21);
            Console.Write("          ===       ^       ^       ===                   ");
            Console.SetCursorPosition(35, 22);
            Console.Write("         ====                       ====                  ");
            Console.SetCursorPosition(35, 23);
            Console.Write("          ===                       ===                   ");
            Console.SetCursorPosition(35, 24);
            Console.Write("            ====-               -====                     ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                 ==============                           ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static private void DisplayKingSlime()
        {

            Console.Write("                   __    _    __                          ");
            Console.SetCursorPosition(35, 14);
            Console.Write("                   |  \\_/ \\_/  |                         ");
            Console.SetCursorPosition(35, 15);
            Console.Write("                   +++++++++++++                          ");
            Console.SetCursorPosition(35, 16);
            Console.Write("                      =======                             ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                  ====       ====                         ");
            Console.SetCursorPosition(35, 18);
            Console.Write("               ===              ===                       ");
            Console.SetCursorPosition(35, 19);
            Console.Write("             ==     v       v     ==                      ");
            Console.SetCursorPosition(35, 20);
            Console.Write("           ===     (6)     (9)     ===                    ");
            Console.SetCursorPosition(35, 21);
            Console.Write("          ===       ^       ^       ===                   ");
            Console.SetCursorPosition(35, 22);
            Console.Write("         ====                       ====                  ");
            Console.SetCursorPosition(35, 23);
            Console.Write("          ===                       ===                   ");
            Console.SetCursorPosition(35, 24);
            Console.Write("            ====-               -====                     ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                 ==============                           ");

        }

        static private void ClearPlayerTextBox()
        {
            Console.SetCursorPosition(26, 31);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 32);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 33);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 34);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 35);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 36);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(26, 37);
            Console.WriteLine("                                                                             ");

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
            else if (slime.Color == "pink")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (slime.Color == "purple")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (slime.Color == "pine")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
        }

        static private void ClearSlime()
        {

            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 14);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 15);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 16);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 17);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 18);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 19);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 20);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 21);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 22);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 23);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 24);
            Console.Write("                                                          ");
            Console.SetCursorPosition(35, 25);
            Console.Write("                                                          ");

        }

    }
}